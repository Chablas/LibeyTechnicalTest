using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly Context _context;
        public ProvinceRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<ProvinceResponse> GetAll()
        {
            var q = from province in _context.Provinces
                    join region in _context.Regions
                        on province.RegionCode equals region.RegionCode
                    select new ProvinceResponse
                    {
                        ProvinceCode = province.ProvinceCode,
                        ProvinceDescription = province.ProvinceDescription,
                        Region = new RegionResponse
                        {
                            RegionCode = region.RegionCode,
                            RegionDescription = region.RegionDescription
                        }
                    };

            return q.ToList();
        }

        public ProvinceResponse Find(string provinceCode)
        {
            var q = from province in _context.Provinces.Where(x => x.ProvinceCode.Equals(provinceCode))
                    select new ProvinceResponse()
                    {
                        ProvinceCode = province.ProvinceCode,
                        ProvinceDescription = province.ProvinceDescription,
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new ProvinceResponse();
        }
    }
}