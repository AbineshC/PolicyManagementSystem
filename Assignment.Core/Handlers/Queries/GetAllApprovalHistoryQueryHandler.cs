using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Core.Handlers.Queries.PolicyQueries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Core.Handlers.Queries
{
    public class GetAllApprovalHistoryQuery : IRequest<IEnumerable<ApprovalHistoryDTO>>
    {
    }
    public class GetAllApprovalHistoryQueryHandler : IRequestHandler<GetAllApprovalHistoryQuery, IEnumerable<ApprovalHistoryDTO>>
    {
        private readonly IApprovalHistoryRepository<ApprovalHistory> _repository;
        private readonly IMapper _mapper;

        public GetAllApprovalHistoryQueryHandler(IApprovalHistoryRepository<ApprovalHistory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApprovalHistoryDTO>> Handle(GetAllApprovalHistoryQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ApprovalHistoryDTO>>(entities);
        }
    }
}
