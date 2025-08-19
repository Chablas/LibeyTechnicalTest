using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using System.ComponentModel.DataAnnotations;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain
{
    public class DocumentType
    {
        public int DocumentTypeId { get; set; }
        public string DocumentTypeDescription { get; set; }
    }
}
