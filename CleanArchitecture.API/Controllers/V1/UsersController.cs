using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;
using CleanArchitecture.API.Controllers.Base;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Requests;
using CleanArchitecture.Application.Responses;

namespace CleanArchitecture.API.Controllers.V1
{
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("users")]
        [SwaggerOperation("Adiciona um cliente")]
        [SwaggerResponse(200, "Retorno de cliente cadastrado", typeof(UserResponse))]
        [SwaggerResponse(400, "Retorno de cliente não cadastrado", null)]
        public IActionResult Add([FromBody] AddUserRequest userRequest)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Add(userRequest);
                return Ok(user);
            }
            else
                return BadRequest();
        }

        [HttpPatch("users/{userId:long}")]
        [SwaggerOperation("Atualiza dados básicos um cliente")]
        [SwaggerResponse(200, "Retorno de cliente atualizado", typeof(UserResponse))]
        [SwaggerResponse(400, "Retorno de cliente não atualizado.", null)]
        public IActionResult Update(long userId, [FromBody] UpdateUserRequest userRequest)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Update(userId, userRequest);
                return Accepted(user);
            }
            else
                return BadRequest();
        }

        [HttpGet("users")]
        [SwaggerOperation("Recupera uma lista de clientes")]
        [SwaggerResponse(200, "Retorno de uma lista de clientes", typeof(IEnumerable<UserResponse>))]
        [SwaggerResponse(404, type: null)]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();

            if (users is not null)
                return Ok(users);
            else
                return NotFound();
        }

        [HttpGet("users/{userId:long}")]
        [SwaggerOperation("Recupera um cliente pelo identificador")]
        [SwaggerResponse(200, "Retorno de um cliente", typeof(UserResponse))]
        [SwaggerResponse(404, type: null)]
        public IActionResult GetById(long userId)
        {
            var user = _userService.GetById(userId);

            if (user is not null)
                return Ok(user);
            else
                return NotFound();
        }

        [HttpDelete("users/{userId:long}")]
        [SwaggerOperation("Exclui um cliente")]
        [SwaggerResponse(200, "Retorno de sucesso para remoção de um cliente", null)]
        public IActionResult DeleteById(long userId)
        {
            _userService.DeleteById(userId);
            return Ok();
        }
    }
}
