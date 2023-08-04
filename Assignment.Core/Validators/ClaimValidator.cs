using Assignment.Contracts.DTO;
using Assignment.Core.Handlers.Queries.PolicyQueries;
using AutoMapper.Configuration;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Core.Validators
{
    public class ClaimValidator : AbstractValidator<ClaimDTO>
    {
        private readonly IMediator _mediator;

        public ClaimValidator(IMediator mediator)
        {
            this._mediator = mediator;
            ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;
            RuleFor(x => x).Must((obj) => CheckInsuredAmount(this._mediator, obj)).WithMessage("Claim Amount should be less than or equal to Insured Amount");

        }
        public  static bool CheckInsuredAmount(IMediator mediator,ClaimDTO claimDTO)
        {
            var result =  mediator.Send(new GetPolicyByIdQuery(claimDTO.PolicyID));
            if(result.Result.InsuredAmount < claimDTO.ClaimAmount)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
