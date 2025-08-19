using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using System.Collections.Generic;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IDocumentTypeAggregate
    {
        IEnumerable<DocumentTypeResponse> GetAll();
        DocumentTypeResponse Find(int documentTypeId);
    }
}