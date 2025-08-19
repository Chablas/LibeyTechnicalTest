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
            var q =
        from user in _context.LibeyUsers
        join documentType in _context.DocumentTypes
            on user.DocumentTypeId equals documentType.DocumentTypeId
        join region in _context.Regions
            on user.RegionCode equals region.RegionCode
        join province in _context.Provinces
            on user.ProvinceCode equals province.ProvinceCode
        join ubigeo in _context.Ubigeos
            on user.UbigeoCode equals ubigeo.UbigeoCode
        where user.DocumentNumber == documentNumber
        select new LibeyUserResponse
        {
            DocumentNumber = user.DocumentNumber,
            Active = user.Active,
            Address = user.Address,
            Email = user.Email,
            FathersLastName = user.FathersLastName,
            MothersLastName = user.MothersLastName,
            Name = user.Name,
            Password = user.Password,
            Phone = user.Phone,

            DocumentType = new DocumentTypeResponse
            {
                DocumentTypeId = documentType.DocumentTypeId,
                DocumentTypeDescription = documentType.DocumentTypeDescription
            },

            Region = new RegionResponse
            {
                RegionCode = region.RegionCode,
                RegionDescription = region.RegionDescription
            },

            Province = new ProvinceResponse
            {
                ProvinceCode = province.ProvinceCode,
                ProvinceDescription = province.ProvinceDescription
            },

            Ubigeo = new UbigeoResponse
            {
                UbigeoCode = ubigeo.UbigeoCode,
                UbigeoDescription = ubigeo.UbigeoDescription
            }
        };

            return q.FirstOrDefault() ?? new LibeyUserResponse();
        }

        public IEnumerable<LibeyUserResponse> GetAll()
        {
            var q = from user in _context.LibeyUsers
                    join region in _context.Regions
                        on user.RegionCode equals region.RegionCode
                    join province in _context.Provinces
                        on user.ProvinceCode equals province.ProvinceCode
                    join ubigeo in _context.Ubigeos
                        on user.UbigeoCode equals ubigeo.UbigeoCode
                    join docType in _context.DocumentTypes
                        on user.DocumentTypeId equals docType.DocumentTypeId
                    select new LibeyUserResponse
                    {
                        DocumentNumber = user.DocumentNumber,
                        Active = user.Active,
                        Address = user.Address,
                        Email = user.Email,
                        FathersLastName = user.FathersLastName,
                        MothersLastName = user.MothersLastName,
                        Name = user.Name,
                        Password = user.Password,
                        Phone = user.Phone,

                        Region = new RegionResponse
                        {
                            RegionCode = region.RegionCode,
                            RegionDescription = region.RegionDescription
                        },
                        Province = new ProvinceResponse
                        {
                            ProvinceCode = province.ProvinceCode,
                            ProvinceDescription = province.ProvinceDescription
                        },
                        Ubigeo = new UbigeoResponse
                        {
                            UbigeoCode = ubigeo.UbigeoCode,
                            UbigeoDescription = ubigeo.UbigeoDescription
                        },
                        DocumentType = new DocumentTypeResponse
                        {
                            DocumentTypeId = docType.DocumentTypeId,
                            DocumentTypeDescription = docType.DocumentTypeDescription
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