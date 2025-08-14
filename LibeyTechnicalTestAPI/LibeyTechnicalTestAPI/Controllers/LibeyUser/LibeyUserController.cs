using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibeyUserController : ControllerBase
    {
        private readonly ILibeyUserAggregate _aggregate;

        public LibeyUserController(ILibeyUserAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _aggregate.GetAll();
            return Ok(users);
        }

        [HttpGet("{documentNumber}")]
        public IActionResult Get(string documentNumber)
        {
            var user = _aggregate.FindResponse(documentNumber);
            if (user == null || string.IsNullOrEmpty(user.DocumentNumber))
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserCreateCommand command)
        {
            _aggregate.Create(command);
            return CreatedAtAction(nameof(Get), new { documentNumber = command.DocumentNumber }, command);
        }

        [HttpPut("{documentNumber}")]
        public IActionResult Update(string documentNumber, [FromBody] UserUpdateCommand command)
        {
            _aggregate.Update(documentNumber, command);
            return NoContent();
        }

        [HttpDelete("{documentNumber}")]
        public IActionResult Delete(string documentNumber)
        {
            _aggregate.Delete(documentNumber);
            return NoContent();
        }
    }
}