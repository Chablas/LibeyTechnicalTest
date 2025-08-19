using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Region
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeAggregate _aggregate;

        public DocumentTypeController(IDocumentTypeAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var documentTypes = _aggregate.GetAll();
            return Ok(documentTypes);
        }

        [HttpGet("{documentTypeId}")]
        public IActionResult Get(int documentTypeId)
        {
            var documentType = _aggregate.Find(documentTypeId);
            if (documentType == null || documentType.DocumentTypeId <= 0)
                return NotFound();
            return Ok(documentType);
        }
    }
}
