using Assignment.Contracts.Data;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Core.Exceptions;
using Assignment.Providers.Handlers.Commands;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Core.Handlers.Commands.PolicyCommands
{
    public class AddPolicyCommand : IRequest<int>
    {
        public PolicyDTO Model { get; }
        public AddPolicyCommand(PolicyDTO model)
        {
            Model = model;
        }
    }
    public class AddPolicyCommandHandler : IRequestHandler<AddPolicyCommand, int>
    {
        private readonly IPolicyRepository<Policy> _policyRepository;
        private readonly IMapper _mapper;

        public AddPolicyCommandHandler(IPolicyRepository<Policy> policyRepository, IMapper mapper)
        {
            _policyRepository = policyRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddPolicyCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Policy>(request.Model);
            return await _policyRepository.Add(entity);
           
        }
    }
}
