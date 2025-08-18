using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class RegionAggregate : IRegionAggregate
    {
        private readonly IRegionRepository _repository;
        public RegionAggregate(IRegionRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<RegionResponse> GetAll()
        {
            return _repository.GetAll();
        }

        public RegionResponse Find(string regionCode)
        {
            return _repository.Find(regionCode);
        }
    }
}