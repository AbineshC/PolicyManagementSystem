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

namespace Assignment.Core.Handlers.Queries.ClaimQuries
{
    public class GetClaimByIdQuery : IRequest<ClaimDTO>
    {
        public int ClaimId { get; }
        public GetClaimByIdQuery(int claimId)
        {
            ClaimId = claimId;
        }
    }
    public class GetClaimByIdQueryHandler : IRequestHandler<GetClaimByIdQuery, ClaimDTO>
    {
        private readonly IClaimRepository<Claim> _repository;
        private readonly IMapper _mapper;

        public GetClaimByIdQueryHandler(IClaimRepository<Claim> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClaimDTO> Handle(GetClaimByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.Get(request.ClaimId);
            return _mapper.Map<ClaimDTO>(entities);
        }
    }
}
