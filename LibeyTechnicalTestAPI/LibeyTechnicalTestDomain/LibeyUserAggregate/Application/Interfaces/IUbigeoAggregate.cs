using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using System.Collections.Generic;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IUbigeoAggregate
    {
        IEnumerable<UbigeoResponse> GetAll();
        UbigeoResponse Find(string ubigeoCode);
    }
}