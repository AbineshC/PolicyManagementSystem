using Assignment.Contracts.Data;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Core.Handlers.Queries.PolicyQueries
{
    
    public class GetPolicyByIdQuery : IRequest<PolicyDTO>
    {
        public int PolicyId { get; }
        public GetPolicyByIdQuery(int policyId)
        {
            PolicyId = policyId;
        }
    }
    public class GetPolicyByIdQueryHandler : IRequestHandler<GetPolicyByIdQuery,PolicyDTO>
    {
        private readonly IPolicyRepository<Policy> _repository;
        private readonly IMapper _mapper;

        public GetPolicyByIdQueryHandler(IPolicyRepository<Policy> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PolicyDTO> Handle(GetPolicyByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.Get(request.PolicyId);
            return _mapper.Map<PolicyDTO>(entities);
        }
    }
}
