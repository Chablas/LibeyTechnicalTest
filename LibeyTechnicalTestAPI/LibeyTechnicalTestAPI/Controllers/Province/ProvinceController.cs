using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Region
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceAggregate _aggregate;

        public ProvinceController(IProvinceAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var provinces = _aggregate.GetAll();
            return Ok(provinces);
        }

        [HttpGet("{provinceCode}")]
        public IActionResult Get(string provinceCode)
        {
            var province = _aggregate.Find(provinceCode);
            if (province == null || string.IsNullOrEmpty(province.ProvinceCode))
                return NotFound();
            return Ok(province);
        }
    }
}
