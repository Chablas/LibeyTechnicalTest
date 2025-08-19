namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO
{
    public record UbigeoResponse
    {
        public string UbigeoCode { get; init; }
        public string UbigeoDescription { get; init; }
        public RegionResponse Region { get; init; }
        public ProvinceResponse Province { get; init; }
    }
}