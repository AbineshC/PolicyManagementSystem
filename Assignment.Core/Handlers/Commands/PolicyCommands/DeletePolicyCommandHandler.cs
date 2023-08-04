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

namespace Assignment.Core.Handlers.Commands.PolicyCommands
{
    
        public class DeletePolicyCommand : IRequest<int>
        {
        public int PolicyId { get; }
        public DeletePolicyCommand(int policyId)
        {
            PolicyId = policyId;
        }
    }
        public class DeletePolicyCommandHandler : IRequestHandler<DeletePolicyCommand, int>
        {
            private readonly IUnitOfWork _repository;
            private readonly IMapper _mapper;

            public DeletePolicyCommandHandler(IUnitOfWork repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<int> Handle(DeletePolicyCommand request, CancellationToken cancellationToken)
            {
            
                return await _repository.Policy.Delete(request.PolicyId);
            }
           
        
        }
    }

