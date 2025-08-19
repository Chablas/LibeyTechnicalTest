namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO
{
    public record LibeyUserResponse
    {
        public string DocumentNumber { get; init; }
        public DocumentTypeResponse DocumentType { get; init; }
        public string Name { get; init; }
        public string FathersLastName { get; init; }
        public string MothersLastName { get; init; }
        public string Address { get; init; }
        public RegionResponse Region { get; init; }
        public ProvinceResponse Province { get; init; }
        public UbigeoResponse Ubigeo { get; init; }
        public string Phone { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public bool Active { get; init; }
    }
}