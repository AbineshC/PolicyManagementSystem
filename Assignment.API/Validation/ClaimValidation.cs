using Assignment.Core.Handlers.Queries.PolicyQueries;
using AutoMapper.Configuration;
using MediatR;

namespace Assignment.API.Validation
{
    public class ClaimValidation
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public ClaimValidation(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }
        public void IsValid(int id)
        {
            var query = new GetPolicyByIdQuery(id);
            var response =  _mediator.Send(query);
        }
    }
}
