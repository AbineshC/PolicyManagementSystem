using Assignment.Contracts.Data;
using Assignment.Contracts.Data.Entities;
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
    public class UpdateClaimCommand : IRequest<int>
    {
        public ClaimDTO ClaimId { get; set; }
        public UpdateClaimCommand(ClaimDTO claimId)
        {
            ClaimId = claimId;
        }
    }
    public class UpdateClaimCommandHandler : IRequestHandler<UpdateClaimCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public UpdateClaimCommandHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateClaimCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Claim>(request.ClaimId);
            if (entity != null)
            {
                return await _repository.Claim.Update(entity);
            }
            return 0;
        }
    }
}
