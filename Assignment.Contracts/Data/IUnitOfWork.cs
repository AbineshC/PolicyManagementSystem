using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;

namespace Assignment.Contracts.Data
{
    public interface IUnitOfWork
    {
        IAppRepository App { get; }
        IUserRepository User { get; }
        IPolicyRepository<Policy> Policy { get; }
        IClaimRepository<Claim> Claim { get; }
        IApprovalHistoryRepository<ApprovalHistory> ApprovalHistory { get; }
        Task CommitAsync();
    }
}