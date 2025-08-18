using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using System.Collections.Generic;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserAggregate
    {
        void Create(UserCreateCommand command);
        IEnumerable<LibeyUserResponse> GetAll();
        LibeyUserResponse FindResponse(string documentNumber);
        void Update(string documentNumber, UserUpdateCommand command);
        void Delete(string documentNumber);
    }
}