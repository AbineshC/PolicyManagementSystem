using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Assignment.API.Validation;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Core.Exceptions;
using Assignment.Core.Handlers.Commands.PolicyCommands;
using Assignment.Core.Handlers.Queries.PolicyQueries;
using Assignment.Infrastructure.Data.Repositories;
using Assignment.Migrations;
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
public class PolicyController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;
    private readonly IPolicyRepository<Policy> PolicyRepository;
    public PolicyController(IMediator mediator, IConfiguration configuration, ILogger logger)
    {
        _mediator = mediator;
        _configuration = configuration;
        _logger = logger;

     }

    [HttpGet]  
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var query = new GetAllPolicyQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        catch (ArgumentNullException exception)
        {
            _logger.LogError($"PolicyController:GetAll()-{exception.Message}{exception.StackTrace}");
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"PolicyController:GetAll()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(PolicyDTO policy)
    {
        try
        {
            if (ModelState.IsValid)
            {
                PolicyValidation.IsPolicyValid(policy);
                var result = await _mediator.Send(new AddPolicyCommand(policy));
                if (result > 0)
                {
                    policy.PolicyID = result;
                    return Created("Data Added Successfully", policy);
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
            _logger.LogError($"PolicyController : Create()-{exception.Message}{exception.StackTrace}");
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError($"PolicyController : Create()-{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
        }
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetId(int id)
    {
        try
        {
            var result = await _mediator.Send(new GetPolicyByIdQuery(id));
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        catch (ArgumentNullException exception)
        {
            _logger.LogError($"PolicyController:GetAll()-{exception.Message}{exception.StackTrace}");
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"PolicyController:GetAll()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update( PolicyDTO policy)
    {

        try
        {

            if (ModelState.IsValid)
            {
                PolicyValidation.IsPolicyValid(policy);
                var result = await _mediator.Send(new UpdatePolicyCommand(policy));

                if (result > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        catch (ArgumentNullException exception)
        {
            _logger.LogError($"PolicyController : Update()-{exception.Message}{exception.StackTrace}");
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError($"PolicyController : Update()-{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _mediator.Send(new DeletePolicyCommand(id));

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
            _logger.LogError($"PolicyController : Delete()-{exception.Message}{exception.StackTrace}");
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError($"PolicyController : Delete()-{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
        }
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<PolicyDTO>>> Search(string title, DateTime date, int typesofPolicy)
    {
        try
        {
            var result = await _mediator.Send(new SearchPolicyQuery(title, date, typesofPolicy ));

            if (result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
        }
    }
}
  