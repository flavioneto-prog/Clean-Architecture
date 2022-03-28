using CleanArchitecture.API.Controllers.Base;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Requests;
using CleanArchitecture.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

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
        [SwaggerOperation("Adicionar Cliente.")]
        [SwaggerResponse(200, "Retorno de cliente cadastrado.", typeof(UserResponse))]
        [SwaggerResponse(400, "Retorno de cliente não cadastrado.", null)]
        public IActionResult Add([FromBody] AddUserRequest userRequest)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Add(userRequest);
                return Accepted(user);
            }
            else
                return BadRequest();
        }

        [HttpPut("users/{id:long}")]
        [SwaggerOperation("Atualizar Cliente.")]
        [SwaggerResponse(200, "Retorno de cliente atualizado.", typeof(UserResponse))]
        [SwaggerResponse(400, "Retorno de cliente não atualizado.", null)]
        public IActionResult Update(long id, [FromBody] UpdateUserRequest userRequest)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Update(id, userRequest);
                return Accepted(user);
            }
            else
                return BadRequest();
        }

        [HttpGet("users")]
        [SwaggerOperation("Obter Clientes.")]
        [SwaggerResponse(200, "Retorno de uma lista de clientes.", typeof(IEnumerable<UserResponse>))]
        [SwaggerResponse(404, type: null)]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();

            if (users is not null)
                return Ok(users);
            else
                return NotFound();
        }

        [HttpGet("users/{id:long}")]
        [SwaggerOperation("Obter Cliente.")]
        [SwaggerResponse(200, "Retorno de um cliente.", typeof(UserResponse))]
        [SwaggerResponse(404, type: null)]
        public IActionResult GetById(long id)
        {
            var user = _userService.GetById(id);

            if (user is not null)
                return Ok(user);
            else
                return NotFound();
        }

        [HttpDelete("users/{id:long}")]
        [SwaggerOperation("Deletar Cliente.")]
        [SwaggerResponse(200, "Retorno de sucesso para remoção de um cliente.", null)]
        public IActionResult DeleteById(long id)
        {
            _userService.DeleteById(id);
            return Ok();
        }
    }
}
