﻿using Microsoft.AspNetCore.Mvc;
using Application.Application.Users.Commands;
using Application.Application.Users.Queries;
using Application.WebUI.Shared.AccessControl;
using Application.WebUI.Shared.Authorization;

namespace Application.WebUI.Server.Controllers.Admin;

[Route("api/Admin/[controller]")]
public class UsersController : ApiControllerBase
{
    // GET: api/Admin/Users
    [HttpGet]
    [Authorize(Permissions.ViewUsers | Permissions.ManageUsers)]
    public async Task<ActionResult<UsersVm>> GetUsers()
    {
        return await Mediator.Send(new GetUsersQuery());
    }

    // GET: api/Admin/Users/5
    [HttpGet("{id}")]
    [Authorize(Permissions.ViewUsers)]
    public async Task<ActionResult<UserDetailsVm>> GetUser(string id)
    {
        return await Mediator.Send(new GetUserQuery(id));
    }

    // PUT: api/Admin/Users/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Permissions.ManageUsers)]
    public async Task<IActionResult> PutUser(string id, UserDto updatedUser)
    {
        if (id != updatedUser.Id) return BadRequest();

        await Mediator.Send(new UpdateUserCommand(updatedUser));

        return NoContent();
    }
}
