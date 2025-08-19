using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using System.Collections.Generic;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IProvinceAggregate
    {
        IEnumerable<ProvinceResponse> GetAll();
        ProvinceResponse Find(string provinceCode);
    }
}