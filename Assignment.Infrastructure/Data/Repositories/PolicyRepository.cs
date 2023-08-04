using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Migrations;
using MediatR;
using Assignment.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Assignment.Contracts.DTO;

namespace Assignment.Infrastructure.Data.Repositories
{
    public class PolicyRepository :  IPolicyRepository<Policy>
    {
        private readonly DatabaseContext _databaseContext;
        
        public PolicyRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<int> Add(Policy entity)
        {
            Policy policyDetails = new Policy()
            {
                PolicyID = entity.PolicyID,
                Description = entity.Description,
                Title = entity.Title,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Premium = entity.Premium,
                Duration = entity.Duration,
                InsuredAmount = entity.InsuredAmount,
                InsurerName = entity.InsurerName,
                InsurerHolderAge = entity.InsurerHolderAge,
                PolicyTypeId = entity.PolicyTypeId,
                VehicleNumber = entity.VehicleNumber,
                Model = entity.Model,
                HouseAddress = entity.HouseAddress,
                AssetValue = entity.AssetValue,
                Coverage = entity.Coverage,
                Status = entity.Status,
                StatusOfPolicy = entity.StatusOfPolicy,

            };
            var claimDetails = new List<Claim>();
            foreach (var x in entity.Claims)
            {
                claimDetails.Add(x);
            }
            _databaseContext.PolicyInformation.Add(policyDetails);

             await _databaseContext.SaveChangesAsync();

            foreach (var claim in claimDetails)
            {
                _databaseContext.Claims.Add(claim);
            }
            var approvalHistory = new ApprovalHistory()
            {
                EntityID = policyDetails.PolicyID,
                EntityType = "policy",
                ApprovalStatus = entity.StatusOfPolicy,
                ApprovedBy = "abinesh",
                ApprovedDate = DateTime.Today,
                Comments = "Approved/Rejected",
                IsApproval = true
            };
            _databaseContext.ApprovalHistory.Add(approvalHistory);


            await _databaseContext.SaveChangesAsync();
            return policyDetails.PolicyID;
            //var x = _databaseContext.PolicyInformation!
            //       .Include(p => p.Claims)

            //       .ToList();

            //return await _databaseContext.SaveChangesAsync();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(int id)
        {
            var result = 0;
            var output = _databaseContext.PolicyInformation.Where(x => x.PolicyID == id ).FirstOrDefaultAsync();
            if (output != null)
            {
                output.Result.Status = false;
                _databaseContext.PolicyInformation.Update(output.Result);
                result = await _databaseContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Policy> Get(int id)
        {
            //var result = await _databaseContext.PolicyInformation.Where(x => x.PolicyID == id && x.Status).FirstOrDefaultAsync();
            //var result2 = await _databaseContext.Claims.Where(x => x.IsActive == true).ToListAsync();            
            //var claimList = result2.Where(y => y.PolicyID == id).ToList();
            //result.Claims = claimList;         
            //return result;
            Policy policy = new Policy();
            policy = _databaseContext.PolicyInformation.Include(s => s.Claims).Single(s => s.PolicyID == id);
            return policy;

        }

        public async Task<IEnumerable<Policy>> GetAll()
        {
            //var result = await _databaseContext.PolicyInformation.Where(x => x.Status == true).ToListAsync();
            //var result2 = await _databaseContext.Claims.Where(x => x.IsActive == true).ToListAsync();
            //foreach (var x in result)
            //{
            //    var claimList = result2.Where(y => y.PolicyID == x.PolicyID).ToList();
            //    x.Claims = claimList;
            //}
            //return result;
            List<Policy> policy = new List<Policy>();
            Claim claim = new Claim();
            policy = _databaseContext.PolicyInformation.Include(s => s.Claims).Where(x => x.Status == true).ToList();
            return policy;

        }

        public async Task<int> Update(Policy model)
        {
            var result = 0;
            var output = _databaseContext.PolicyInformation.Where(x => x.PolicyID == model.PolicyID ).FirstOrDefaultAsync();
            if (output.Result != null)
            {
                output.Result.PolicyID = model.PolicyID;
                output.Result.Description = model.Description;
                output.Result.Title = model.Title;
                output.Result.StartDate = model.StartDate;
                output.Result.EndDate = model.EndDate;
                output.Result.Premium = model.Premium;
                output.Result.Duration = model.Duration;
                output.Result.InsuredAmount = model.InsuredAmount;
                output.Result.InsurerName = model.InsurerName;
                output.Result.InsurerHolderAge = model.InsurerHolderAge;
                output.Result.Coverage = model.Coverage;
                output.Result.PolicyTypeId = model.PolicyTypeId;
                output.Result.Status = model.Status;
                output.Result.VehicleNumber = model.VehicleNumber;
                output.Result.Model = model.Model;
                output.Result.HouseAddress = model.HouseAddress;
                output.Result.AssetValue = model.AssetValue;
                output.Result.StatusOfPolicy = model.StatusOfPolicy;

                _databaseContext.PolicyInformation.Update(output.Result);
               
                var approvalHistory = new ApprovalHistory()
                {
                    EntityID = model.PolicyID,
                    EntityType = "policy",
                    ApprovalStatus = model.StatusOfPolicy,
                    ApprovedBy = "abinesh",
                    ApprovedDate = DateTime.Now,
                    Comments = "Approved/Rejected",
                    IsApproval = true


                };
              //  _databaseContext.ApprovalHistory.Add(approvalHistory);



                _databaseContext.PolicyInformation.Update(output.Result);

                _databaseContext.ApprovalHistory.Add(approvalHistory);

                _databaseContext.Entry(output.Result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                var result1=_databaseContext.SaveChangesAsync();

                result = result1.Result;
             // result = await _databaseContext.SaveChangesAsync();
            }
            return result;

        }
    

        public IEnumerable<Policy> Search(string title, DateTime? date, int typesofPolicy)
        {
            IQueryable<Policy> query = _databaseContext.PolicyInformation;

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(e => e.Title.ToLower().Contains(title.ToLower()));
            }
            if (date.HasValue)
            {
                query = query.Where(e => e.StartDate.Equals(date));
            }
            if (typesofPolicy >= 1 && typesofPolicy <= 3)
            {
                query = query.Where(e => e.PolicyTypeId.Equals(typesofPolicy));
            }

            return query.ToList();
        }


    }
}
