using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly Context _context;
        public DocumentTypeRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<DocumentTypeResponse> GetAll()
        {
            return _context.DocumentTypes.Select(documentType => new DocumentTypeResponse
            {
                DocumentTypeId = documentType.DocumentTypeId,
                DocumentTypeDescription = documentType.DocumentTypeDescription,
            }).ToList();
        }
        public DocumentTypeResponse Find(int documentTypeId)
        {
            var q = from documentType in _context.DocumentTypes.Where(x => x.DocumentTypeId.Equals(documentTypeId))
                    select new DocumentTypeResponse()
                    {
                        DocumentTypeId = documentType.DocumentTypeId,
                        DocumentTypeDescription = documentType.DocumentTypeDescription,
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new DocumentTypeResponse();
        }
    }
}