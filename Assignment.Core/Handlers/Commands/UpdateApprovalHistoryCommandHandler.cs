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

namespace Assignment.Core.Handlers.Commands
{
    public class UpdateApprovalHistoryCommand : IRequest<int>
    {
        public ApprovalHistoryDTO Id { get; set; }
        public UpdateApprovalHistoryCommand(ApprovalHistoryDTO id)
        {
            Id = id;
        }
    }
    public class UpdateApprovalHistoryCommandHandler : IRequestHandler<UpdateApprovalHistoryCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public UpdateApprovalHistoryCommandHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateApprovalHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ApprovalHistory>(request.Id);
            if (entity != null)
            {
                return await _repository.ApprovalHistory.Update(entity);
            }
            return 0;
        }
    }
}
