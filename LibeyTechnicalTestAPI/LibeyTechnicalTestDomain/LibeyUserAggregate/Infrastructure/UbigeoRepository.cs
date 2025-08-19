using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly Context _context;
        public UbigeoRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<UbigeoResponse> GetAll()
        {
            var q = from ubigeo in _context.Ubigeos
                    join region in _context.Regions
                        on ubigeo.RegionCode equals region.RegionCode
                    join province in _context.Provinces
                        on ubigeo.ProvinceCode equals province.ProvinceCode
                    select new UbigeoResponse
                    {
                        UbigeoCode = ubigeo.UbigeoCode,
                        UbigeoDescription = ubigeo.UbigeoDescription,
                        Region = new RegionResponse
                        {
                            RegionCode = region.RegionCode,
                            RegionDescription = region.RegionDescription
                        },
                        Province = new ProvinceResponse
                        {
                            ProvinceCode = province.ProvinceCode,
                            ProvinceDescription = province.ProvinceDescription
                        }
                    };

            return q.ToList();
        }
        public UbigeoResponse Find(string ubigeoCode)
        {
            var q = from ubigeo in _context.Ubigeos.Where(x => x.UbigeoCode == ubigeoCode)
                    select new UbigeoResponse
                    {
                        UbigeoCode = ubigeo.UbigeoCode,
                        UbigeoDescription = ubigeo.UbigeoDescription,

                        Region = _context.Regions
                            .Where(r => r.RegionCode == ubigeo.RegionCode)
                            .Select(r => new RegionResponse
                            {
                                RegionCode = r.RegionCode,
                                RegionDescription = r.RegionDescription
                            })
                            .FirstOrDefault(),

                        Province = _context.Provinces
                            .Where(p => p.ProvinceCode == ubigeo.ProvinceCode)
                            .Select(p => new ProvinceResponse
                            {
                                ProvinceCode = p.ProvinceCode,
                                ProvinceDescription = p.ProvinceDescription
                            })
                            .FirstOrDefault()
                    };

            return q.FirstOrDefault() ?? new UbigeoResponse();
        }
    }
}