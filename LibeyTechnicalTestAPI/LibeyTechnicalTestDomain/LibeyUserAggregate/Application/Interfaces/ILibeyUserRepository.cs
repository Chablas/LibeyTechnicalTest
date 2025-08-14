using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System.Collections.Generic;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserRepository
    {
        LibeyUserResponse FindResponse(string documentNumber);
        IEnumerable<LibeyUserResponse> GetAll();
        void Create(LibeyUser libeyUser);
        void Update(string documentNumber, LibeyUser libeyUser);
        void Delete(string documentNumber);
    }
}