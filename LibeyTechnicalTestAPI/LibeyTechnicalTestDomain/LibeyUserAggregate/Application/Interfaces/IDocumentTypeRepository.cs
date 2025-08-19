using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System.Collections.Generic;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IDocumentTypeRepository
    {
        IEnumerable<DocumentTypeResponse> GetAll();
        DocumentTypeResponse Find(int documentTypeId);
    }
}