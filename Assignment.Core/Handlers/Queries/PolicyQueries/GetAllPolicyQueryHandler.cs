using Assignment.Contracts.DTO;
using Assignment.Providers.Handlers.Queries;
using MediatR;
using Assignment.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.Data.Entities;

namespace Assignment.Core.Handlers.Queries.PolicyQueries
{
    public class GetAllPolicyQuery : IRequest<IEnumerable<PolicyDTO>>
    {
    }
    public class GetAllPolicyQueryHandler : IRequestHandler<GetAllPolicyQuery, IEnumerable<PolicyDTO>>
    {
        private readonly IPolicyRepository<Policy> _repository;
        private readonly IMapper _mapper;

        public GetAllPolicyQueryHandler(IPolicyRepository<Policy> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PolicyDTO>> Handle(GetAllPolicyQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll();
            return _mapper.Map<IEnumerable<PolicyDTO>>(entities);
        }

    }
}
