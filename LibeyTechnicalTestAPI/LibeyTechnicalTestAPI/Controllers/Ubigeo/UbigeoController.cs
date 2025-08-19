using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Region
{
    [ApiController]
    [Route("api/[controller]")]
    public class UbigeoController : ControllerBase
    {
        private readonly IUbigeoAggregate _aggregate;

        public UbigeoController(IUbigeoAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ubigeos = _aggregate.GetAll();
            return Ok(ubigeos);
        }

        [HttpGet("{ubigeoCode}")]
        public IActionResult Get(string ubigeoCode)
        {
            var ubigeo = _aggregate.Find(ubigeoCode);
            if (ubigeo == null || string.IsNullOrEmpty(ubigeo.UbigeoCode))
                return NotFound();
            return Ok(ubigeo);
        }
    }
}
