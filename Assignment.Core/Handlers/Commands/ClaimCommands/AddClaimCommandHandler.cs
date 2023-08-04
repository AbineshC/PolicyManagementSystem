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

namespace Assignment.Core.Handlers.Commands.ClaimCommands
{
    public class AddClaimCommand : IRequest<int>
    {
        public ClaimDTO Model { get; }
        public AddClaimCommand(ClaimDTO model)
        {
            Model = model;
        }
    }
    public class AddClaimCommandHandler : IRequestHandler<AddClaimCommand, int>
    {
        private readonly IClaimRepository<Claim> _claimRepository;
        private readonly IMapper _mapper;

        public AddClaimCommandHandler(IClaimRepository<Claim> claimRepository, IMapper mapper)
        {
            _claimRepository = claimRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddClaimCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Claim>(request.Model);
            return await _claimRepository.Add(entity);
            
        }
    }
}
