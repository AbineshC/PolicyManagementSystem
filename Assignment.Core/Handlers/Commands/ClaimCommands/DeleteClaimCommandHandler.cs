using Assignment.Contracts.Data;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Core.Handlers.Commands.ClaimCommands
{
    public class DeleteClaimCommand : IRequest<int>
    {
        public int ClaimId { get; }
        public DeleteClaimCommand(int claimId)
        {
            ClaimId = claimId;
        }
    }
    public class DeleteClaimCommandHandler  : IRequestHandler<DeleteClaimCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public DeleteClaimCommandHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(DeleteClaimCommand request, CancellationToken cancellationToken)
        {

            return await _repository.Claim.Delete(request.ClaimId);
        }
    }
}
