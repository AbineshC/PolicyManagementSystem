using Assignment.API.Validation;
using Assignment.Contracts.DTO;
using Assignment.Core.Handlers.Commands;
using Assignment.Core.Handlers.Queries;
using AutoMapper.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;
      //  private readonly IConfiguration _configuration;
        public ApprovalHistoryController(IMediator mediator)
        {
            _mediator = mediator;
          //  _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllApprovalHistoryQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApprovalHistoryDTO entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new AddApprovalHistoryCommand(entity));
                if (result > 0)
                {
                    return Created("Data Added Successfully", entity);
                }
            }
            else
            {
                return BadRequest(ModelState);

            }
            return BadRequest("Something Went Wrong");
        }

        [HttpPut]
        public async Task<IActionResult> Update(ApprovalHistoryDTO entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new UpdateApprovalHistoryCommand(entity));

                if (result > 0)
                {
                    return Ok("Updated Successfully");
                }
                else if (result == 0)
                {
                    return NotFound();
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
            return BadRequest("Something Went Wrong");
        }
    }
}
