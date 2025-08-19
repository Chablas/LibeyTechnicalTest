using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System.Collections.Generic;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IUbigeoRepository
    {
        IEnumerable<UbigeoResponse> GetAll();
        UbigeoResponse Find(string ubigeoCode);
    }
}