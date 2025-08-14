using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        public LibeyUserAggregate(ILibeyUserRepository repository)
        {
            _repository = repository;
        }
        public void Create(UserCreateCommand command)
        {
            var user = new LibeyUser(
                command.DocumentNumber,
                command.DocumentTypeId,
                command.Name,
                command.FathersLastName,
                command.MothersLastName,
                command.Address,
                command.UbigeoCode,
                command.RegionCode,
                command.ProvinceCode,
                command.Phone,
                command.Email,
                command.Password
                );
            _repository.Create(user);
        }

        public IEnumerable<LibeyUserResponse> GetAll()
        {
            return _repository.GetAll();
        }

        public LibeyUserResponse FindResponse(string documentNumber)
        {
            return _repository.FindResponse(documentNumber);
        }

        public void Update(string documentNumber, UserUpdateCommand command)
        {
            var user = new LibeyUser(
                command.Name,
                command.FathersLastName,
                command.MothersLastName,
                command.Address,
                command.UbigeoCode,
                command.RegionCode,
                command.ProvinceCode,
                command.Phone,
                command.Email,
                command.Password,
                command.Active
            );
            _repository.Update(documentNumber, user);
        }

        public void Delete(string documentNumber)
        {
            _repository.Delete(documentNumber);
        }
    }
}