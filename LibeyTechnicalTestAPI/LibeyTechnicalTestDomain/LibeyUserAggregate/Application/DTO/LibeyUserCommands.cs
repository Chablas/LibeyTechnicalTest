namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO
{
    public record UserCreateCommand
    {
        public string DocumentNumber { get; init; }
        public int DocumentTypeId { get; init; }
        public string Name { get; init; }
        public string FathersLastName { get; init; }
        public string MothersLastName { get; init; }
        public string Address { get; init; }
        public string UbigeoCode { get; init; }
        public string Phone { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string RegionCode { get; set; }
        public string ProvinceCode { get; set; }
    }
    public record UserUpdateCommand
    {
        public string Name { get; init; }
        public string FathersLastName { get; init; }
        public string MothersLastName { get; init; }
        public string Address { get; init; }
        public string UbigeoCode { get; init; }
        public string Phone { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string RegionCode { get; set; }
        public string ProvinceCode { get; set; }
        public bool Active { get; set; }
    }
}