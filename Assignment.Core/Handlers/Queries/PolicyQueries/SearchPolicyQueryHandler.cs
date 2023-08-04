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
    public class SearchPolicyQuery : IRequest<IEnumerable<PolicyDTO>>
    {
        public string Title { get; }
        public DateTime Date { get; }
        public int policyType { get; }
        public SearchPolicyQuery(string title, DateTime date, int typesofPolicy)
        {
            Title = title;
            Date = date;
            policyType = typesofPolicy;
        }
    }
    public class SearchPolicyQueryHandler : IRequestHandler<SearchPolicyQuery, IEnumerable<PolicyDTO>>
    {
        private readonly IPolicyRepository<Policy> _repository;
        private readonly IMapper _mapper;

        public SearchPolicyQueryHandler(IPolicyRepository<Policy> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PolicyDTO>> Handle(SearchPolicyQuery request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult( _repository.Search(request.Title, request.Date, request.policyType));
            return _mapper.Map<IEnumerable<PolicyDTO>>(entities);
        }

    }

}
