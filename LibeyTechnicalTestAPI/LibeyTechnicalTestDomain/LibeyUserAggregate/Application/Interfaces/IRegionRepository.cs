using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System.Collections.Generic;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IRegionRepository
    {
        RegionResponse Find(string regionCode);
        IEnumerable<RegionResponse> GetAll();
    }
}