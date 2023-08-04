using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Assignment.API.Validation;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;
using Assignment.Core.Exceptions;
using Assignment.Core.Handlers.Commands.ClaimCommands;
using Assignment.Core.Handlers.Commands.PolicyCommands;
using Assignment.Core.Handlers.Queries.ClaimQuries;
using Assignment.Core.Handlers.Queries.PolicyQueries;
using Assignment.Core.Validators;
using Assignment.Providers.Handlers.Commands;
using Assignment.Providers.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;


[Route("api/[controller]")]
[ApiController]
public class ClaimController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;
    public ClaimController(IMediator mediator, IConfiguration configuration, ILogger logger)
    {
        _mediator = mediator;
        _configuration = configuration;
        _logger = logger;

    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllClaimQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ClaimDTO claim)
    {
        try
        {
            if (new ClaimValidator(_mediator).Validate(claim).IsValid)
            {
                var result = await _mediator.Send(new AddClaimCommand(claim));
                if (result > 0)
                {
                    claim.ClaimID = result;
                    return Created("Data Added Successfully", claim);
                }
            }
            return BadRequest("Claim Amount should be less than or equal to Insured Amount");
        }
        catch (ArgumentNullException exception)
        {
            _logger.LogError($"ClaimController : Create()-{exception.Message}{exception.StackTrace}");
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError($"ClaimController : Create()-{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
        }
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetId(int id)
    {
        try
        {
            var result = await _mediator.Send(new GetClaimByIdQuery(id));
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        catch (ArgumentNullException exception)
        {
            _logger.LogError($"ClaimController : GetId()-{exception.Message}{exception.StackTrace}");
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError($"ClaimController : GetId()-{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(ClaimDTO claim)
    {
        try
        {
            if (new ClaimValidator(_mediator).Validate(claim).IsValid)
            {
                var result = await _mediator.Send(new UpdateClaimCommand(claim));

                if (result > 0)
                {
                    return Ok();
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
        catch (ArgumentNullException exception)
        {
            _logger.LogError($"ClaimController : Update()-{exception.Message}{exception.StackTrace}");
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError($"ClaimController : Update()-{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _mediator.Send(new DeleteClaimCommand(id));

            if (result > 0)
            {
                return Ok("Deleted Successfully");
            }
            else if (result == 0)
            {
                return NotFound();
            }
            return BadRequest("Something Went Wrong");
        }
        catch (ArgumentNullException exception)
        {
            _logger.LogError($"ClaimController : Delete()-{exception.Message}{exception.StackTrace}");
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError($"ClaimController : Delete()-{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
        }

    }

   
}
