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
    public class ApprovalHistoryRepository : IApprovalHistoryRepository<ApprovalHistory>
    {
        private readonly DatabaseContext _databaseContext;

        public ApprovalHistoryRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<int> Add(ApprovalHistory entity)
        {
            _databaseContext.ApprovalHistory.AddAsync(entity);
            return await _databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApprovalHistory>> GetAll()
        {
            return await _databaseContext.ApprovalHistory.Where(x => x.IsApproval == true).ToListAsync();
        }

        public async Task<int> Update(ApprovalHistory entity)
        {
            var result = 0;
            var output = _databaseContext.ApprovalHistory.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
            if (output != null)
            {
                output.Result.Comments = entity.Comments;
                output.Result.IsApproval = entity.IsApproval;
                output.Result.ApprovedBy = entity.ApprovedBy;
                output.Result.ApprovedDate = entity.ApprovedDate;

                _databaseContext.ApprovalHistory.Update(output.Result);
                result = await _databaseContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
