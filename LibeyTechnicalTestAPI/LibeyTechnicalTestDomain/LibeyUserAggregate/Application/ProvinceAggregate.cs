using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class ProvinceAggregate : IProvinceAggregate
    {
        private readonly IProvinceRepository _repository;
        public ProvinceAggregate(IProvinceRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProvinceResponse> GetAll()
        {
            return _repository.GetAll();
        }

        public ProvinceResponse Find(string provinceCode)
        {
            return _repository.Find(provinceCode);
        }
    }
}