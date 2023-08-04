using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Core.Handlers.Commands.ClaimCommands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Core.Handlers.Commands
{
    public class AddApprovalHistoryCommand : IRequest<int>
    {
        public ApprovalHistoryDTO Model { get; }
        public AddApprovalHistoryCommand(ApprovalHistoryDTO model)
        {
            Model = model;
        }
    }
    public class AddApprovalHistoryCommandHandler : IRequestHandler<AddApprovalHistoryCommand, int>
    {
        private readonly IApprovalHistoryRepository<ApprovalHistory> _approvalHistoryRepository;
        private readonly IMapper _mapper;

        public AddApprovalHistoryCommandHandler(IApprovalHistoryRepository<ApprovalHistory> approvalHistoryRepository, IMapper mapper)
        {
            _approvalHistoryRepository = approvalHistoryRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddApprovalHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ApprovalHistory>(request.Model);
            return await _approvalHistoryRepository.Add(entity);

        }
    }
}
