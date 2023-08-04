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
   
        public class UpdatePolicyCommand : IRequest<int>
        {
        public PolicyDTO PolicyId { get; set; }
        public UpdatePolicyCommand(PolicyDTO policyId)
        {
            PolicyId = policyId;
        }
    }
        public class UpdatePolicyCommandHandler : IRequestHandler<UpdatePolicyCommand, int>
        {
            private readonly IUnitOfWork _repository;
            private readonly IMapper _mapper;

            public UpdatePolicyCommandHandler(IUnitOfWork repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<int> Handle(UpdatePolicyCommand request, CancellationToken cancellationToken)
            {
              var entity =  _mapper.Map<Policy>(request.PolicyId);
              if (entity != null) {
               return await _repository.Policy.Update(entity);
              }
            return 0;
            }
        }
 }
