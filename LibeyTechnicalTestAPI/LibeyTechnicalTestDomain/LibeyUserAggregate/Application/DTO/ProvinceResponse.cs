namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO
{
    public record ProvinceResponse
    {
        public string ProvinceCode { get; init; }
        public string ProvinceDescription { get; init; }
        public RegionResponse Region { get; init; }
    }
}