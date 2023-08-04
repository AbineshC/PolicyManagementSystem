using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Infrastructure.Data.Repositories
{
    public class ClaimRepository : IClaimRepository<Claim>
    {
        private readonly DatabaseContext _databaseContext;
        //public PolicyRepository(DatabaseContext context) : base(context)
        //{

        //}
        public ClaimRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<int> Add(Claim entity)
        {
            Claim claim = new Claim()
            {
                
                ClaimID = entity.ClaimID,
                PolicyID = entity.PolicyID,
                ClaimAmount = entity.ClaimAmount,
                ClaimReason = entity.ClaimReason,
                ClaimDescription = entity.ClaimDescription,
                ClaimDate = entity.ClaimDate,
                IsActive = entity.IsActive,
                StatusOfClaim = entity.StatusOfClaim,
        };

            _databaseContext.Claims.Add(claim);
            await _databaseContext.SaveChangesAsync();

            var approvalHistory = new ApprovalHistory()
            {
                EntityID = claim.ClaimID,
                EntityType = "claim",
                ApprovalStatus = entity.StatusOfClaim,
                ApprovedBy = "abinesh",
                ApprovedDate = DateTime.Now,
                Comments = "Approved/Rejected",
                IsApproval = true
            };
            
            _databaseContext.ApprovalHistory.Add(approvalHistory);
            await _databaseContext.SaveChangesAsync();
            return claim.ClaimID;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(int id)
        {
            var result = 0;
            var output = _databaseContext.Claims.Where(x => x.ClaimID == id && x.IsActive).FirstOrDefaultAsync();
            if (output != null)
            {
                 output.Result.IsActive = false;
                _databaseContext.Claims.Update(output.Result);
                result = await _databaseContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Claim> Get(int id)
        {
            var result = await _databaseContext.Claims.Where(x => x.ClaimID == id && x.IsActive).FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Claim>> GetAll()
        {
            return await _databaseContext.Claims.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<int> Update(Claim model)
        {
            var result = 0;
            var output = _databaseContext.Claims.Where(x => x.ClaimID == model.ClaimID).FirstOrDefaultAsync();
            if (output != null)
            {
                output.Result.ClaimID = model.ClaimID;
                output.Result.PolicyID = model.PolicyID;
                output.Result.ClaimAmount = model.ClaimAmount;
                output.Result.ClaimReason = model.ClaimReason;
                output.Result.ClaimDescription = model.ClaimDescription;
                output.Result.ClaimDate = model.ClaimDate;
                output.Result.IsActive = true;
                output.Result.StatusOfClaim = model.StatusOfClaim;

                var approvalHistory = new ApprovalHistory()
                {
                    EntityID = model.ClaimID,
                    EntityType = "claim",
                    ApprovalStatus = model.StatusOfClaim,
                    ApprovedBy = "abinesh",
                    ApprovedDate = DateTime.Now,
                    Comments = "Approved/Rejected",
                    IsApproval = true
                };
                _databaseContext.Claims.Update(output.Result);
                _databaseContext.ApprovalHistory.Add(approvalHistory);
                _databaseContext.Entry(output.Result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                result = await _databaseContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
