using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }

        public void Create(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Add(libeyUser);
            _context.SaveChanges();
        }

        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var q = from libeyUser in _context.LibeyUsers.Where(x => x.DocumentNumber.Equals(documentNumber))
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone,
                        UbigeoCode = libeyUser.UbigeoCode,
                        Region = _context.Regions
                            .Where(r => r.RegionCode == libeyUser.RegionCode)
                            .Select(r => new RegionResponse
                            {
                                RegionCode = r.RegionCode,
                                RegionDescription = r.RegionDescription
                            }).FirstOrDefault(),
                        ProvinceCode = libeyUser.ProvinceCode
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new LibeyUserResponse();
        }

        public IEnumerable<LibeyUserResponse> GetAll()
        {
            var q = from user in _context.LibeyUsers
                    join region in _context.Regions
                        on user.RegionCode equals region.RegionCode
                    select new LibeyUserResponse
                    {
                        DocumentNumber = user.DocumentNumber,
                        Active = user.Active,
                        Address = user.Address,
                        DocumentTypeId = user.DocumentTypeId,
                        Email = user.Email,
                        FathersLastName = user.FathersLastName,
                        MothersLastName = user.MothersLastName,
                        Name = user.Name,
                        Password = user.Password,
                        Phone = user.Phone,
                        UbigeoCode = user.UbigeoCode,
                        ProvinceCode = user.ProvinceCode,
                        Region = new RegionResponse
                        {
                            RegionCode = region.RegionCode,
                            RegionDescription = region.RegionDescription
                        }
                    };

            return q.ToList();
        }

        public void Update(string documentNumber, LibeyUser user)
        {
            var existing = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == documentNumber);
            if (existing != null)
            {
                existing.Name = user.Name;
                existing.FathersLastName = user.FathersLastName;
                existing.MothersLastName = user.MothersLastName;
                existing.Address = user.Address;
                existing.UbigeoCode = user.UbigeoCode;
                existing.RegionCode = user.RegionCode;
                existing.ProvinceCode = user.ProvinceCode;
                existing.Phone = user.Phone;
                existing.Email = user.Email;
                existing.Password = user.Password;
                existing.Active = user.Active;
                _context.SaveChanges();
            }
        }

        public void Delete(string documentNumber)
        {
            var user = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == documentNumber);
            if (user != null)
            {
                _context.LibeyUsers.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}