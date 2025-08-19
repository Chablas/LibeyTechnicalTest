using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class DocumentTypeAggregate : IDocumentTypeAggregate
    {
        private readonly IDocumentTypeRepository _repository;
        public DocumentTypeAggregate(IDocumentTypeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<DocumentTypeResponse> GetAll()
        {
            return _repository.GetAll();
        }

        public DocumentTypeResponse Find(int documentTypeId)
        {
            return _repository.Find(documentTypeId);
        }
    }
}