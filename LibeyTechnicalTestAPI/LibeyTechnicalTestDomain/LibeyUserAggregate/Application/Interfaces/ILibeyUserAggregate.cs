using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using System.Collections.Generic;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserAggregate
    {
        // Create
        void Create(UserCreateCommand command);

        // Read
        IEnumerable<LibeyUserResponse> GetAll();
        LibeyUserResponse FindResponse(string documentNumber);

        // Update
        void Update(string documentNumber, UserUpdateCommand command);

        // Delete
        void Delete(string documentNumber);
    }
}