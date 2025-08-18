using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Region
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionAggregate _aggregate;

        public RegionController(IRegionAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _aggregate.GetAll();
            return Ok(regions);
        }

        [HttpGet("{regionCode}")]
        public IActionResult Get(string regionCode)
        {
            var region = _aggregate.Find(regionCode);
            if (region == null || string.IsNullOrEmpty(region.RegionCode))
                return NotFound();
            return Ok(region);
        }
    }
}
