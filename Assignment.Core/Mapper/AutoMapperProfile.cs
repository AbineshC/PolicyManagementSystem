using AutoMapper;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;
using Assignment.Core.Handlers.Commands.PolicyCommands;
using Policy_Management_System_API;

namespace Assignment.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<App, AppDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<Policy, PolicyDTO>().ReverseMap();
            CreateMap<Claim, ClaimDTO>().ReverseMap();
            CreateMap<ApprovalHistory, ApprovalHistoryDTO>().ReverseMap();
        }
    }
}
