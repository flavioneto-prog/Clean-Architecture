using CleanArchitecture.API.Controllers.Base;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Requests;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();

            if (users is not null)
                return Ok(users);
            else
                return NotFound();
        }

        [HttpGet("users/{id:long}")]
        public IActionResult GetById(long id)
        {
            var user = _userService.GetById(id);

            if (user is not null)
                return Ok(user);
            else
                return NotFound();
        }

        [HttpDelete("users/{id:long}")]
        public IActionResult DeleteById(long id)
        {
            _userService.DeleteById(id);
            return Ok();
        }

    }
}
