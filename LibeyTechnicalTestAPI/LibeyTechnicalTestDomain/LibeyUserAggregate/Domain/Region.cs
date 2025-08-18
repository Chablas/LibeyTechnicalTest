using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using System.ComponentModel.DataAnnotations;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain
{
    public class Region
    {
        public string RegionCode { get; set; }
        public string RegionDescription { get; set; }
    }
}
