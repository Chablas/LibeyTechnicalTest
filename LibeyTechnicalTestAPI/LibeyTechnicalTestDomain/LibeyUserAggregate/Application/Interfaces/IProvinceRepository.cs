using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System.Collections.Generic;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IProvinceRepository
    {
        IEnumerable<ProvinceResponse> GetAll();
        ProvinceResponse Find(string provinceCode);
    }
}