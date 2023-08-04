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
    public class GetAllClaimQuery : IRequest<IEnumerable<ClaimDTO>>
    {
    }
    public class GetAllClaimQueryHandler : IRequestHandler<GetAllClaimQuery, IEnumerable<ClaimDTO>>
    {
        private readonly IClaimRepository<Claim> _repository;
        private readonly IMapper _mapper;

        public GetAllClaimQueryHandler(IClaimRepository<Claim> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClaimDTO>> Handle(GetAllClaimQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ClaimDTO>>(entities);
        }
    }
}
