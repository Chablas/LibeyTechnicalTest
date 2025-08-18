using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class RegionRepository : IRegionRepository
    {
        private readonly Context _context;
        public RegionRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<RegionResponse> GetAll()
        {
            return _context.Regions.Select(region => new RegionResponse
            {
                RegionCode = region.RegionCode,
                RegionDescription = region.RegionDescription,
            }).ToList();
        }
        public RegionResponse Find(string regionCode)
        {
            var q = from region in _context.Regions.Where(x => x.RegionCode.Equals(regionCode))
                    select new RegionResponse()
                    {
                        RegionCode = region.RegionCode,
                        RegionDescription = region.RegionDescription,
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new RegionResponse();
        }
    }
}