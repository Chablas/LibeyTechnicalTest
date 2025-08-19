using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using System.ComponentModel.DataAnnotations;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain
{
    public class Province
    {
        public string ProvinceCode { get; set; }
        public string RegionCode { get; set; }
        public string ProvinceDescription { get; set; }
    }
}
