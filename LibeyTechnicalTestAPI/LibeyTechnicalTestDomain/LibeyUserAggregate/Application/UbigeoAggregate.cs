using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class UbigeoAggregate : IUbigeoAggregate
    {
        private readonly IUbigeoRepository _repository;
        public UbigeoAggregate(IUbigeoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UbigeoResponse> GetAll()
        {
            return _repository.GetAll();
        }

        public UbigeoResponse Find(string ubigeoCode)
        {
            return _repository.Find(ubigeoCode);
        }
    }
}