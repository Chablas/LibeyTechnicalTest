using System.ComponentModel.DataAnnotations;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO
{
    public record UserCreateCommand
    {
        [Required(ErrorMessage = "El campo Número de Documento es obligatorio")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El Número de Documento debe tener 8 dígitos numéricos")]
        public string DocumentNumber { get; init; }

        [Required(ErrorMessage = "El campo Tipo de Documento es obligatorio")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El Id del Tipo de Documento debe ser un número")]
        public int DocumentTypeId { get; init; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo Nombre solo puede tener 20 caracteres como máximo")]
        public string Name { get; init; }

        [Required(ErrorMessage = "El campo Apellido Paterno es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo Apellido Paterno solo puede tener 20 caracteres como máximo")]
        public string FathersLastName { get; init; }

        [Required(ErrorMessage = "El campo Apellido Materno es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo Apellido Materno solo puede tener 20 caracteres como máximo")]
        public string MothersLastName { get; init; }

        [Required(ErrorMessage = "El campo Dirección es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo Dirección solo puede tener 20 caracteres como máximo")]
        public string Address { get; init; }

        [Required(ErrorMessage = "El campo Celular es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo Celular solo puede tener 20 caracteres como máximo")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Celular debe contener solo dígitos numéricos")]
        public string Phone { get; init; }

        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo Email solo puede tener 20 caracteres como máximo")]
        [EmailAddress(ErrorMessage = "El campo Email no tiene un formato de correo válido")]
        public string Email { get; init; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo Contraseña solo puede tener 20 caracteres como máximo")]
        public string Password { get; init; }

        [Required(ErrorMessage = "El campo Región es obligatorio")]
        [RegularExpression(@"^\d{2}$", ErrorMessage = "El campo código de Región debe tener 2 dígitos numéricos")]
        public string RegionCode { get; set; }

        [Required(ErrorMessage = "El campo Provincia es obligatorio")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "El campo código de Provincia debe tener 4 dígitos numéricos")]
        public string ProvinceCode { get; set; }

        [Required(ErrorMessage = "El campo Ubigeo es obligatorio")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "El campo código de Ubigeo debe tener 6 dígitos numéricos")]
        public string UbigeoCode { get; init; }

    }
    public record UserUpdateCommand
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo Nombre solo puede tener 20 caracteres como máximo")]
        public string Name { get; init; }

        [Required(ErrorMessage = "El campo Apellido Paterno es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo Apellido Paterno solo puede tener 20 caracteres como máximo")]
        public string FathersLastName { get; init; }

        [Required(ErrorMessage = "El campo Apellido Materno es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo Apellido Materno solo puede tener 20 caracteres como máximo")]
        public string MothersLastName { get; init; }

        [Required(ErrorMessage = "El campo Dirección es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo Dirección solo puede tener 20 caracteres como máximo")]
        public string Address { get; init; }

        [Required(ErrorMessage = "El campo Celular es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo Celular solo puede tener 20 caracteres como máximo")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Celular debe contener solo dígitos numéricos")]
        public string Phone { get; init; }

        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo Email solo puede tener 20 caracteres como máximo")]
        [EmailAddress(ErrorMessage = "El campo Email no tiene un formato de correo válido")]
        public string Email { get; init; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo Contraseña solo puede tener 20 caracteres como máximo")]
        public string Password { get; init; }

        [Required(ErrorMessage = "El campo Región es obligatorio")]
        [RegularExpression(@"^\d{2}$", ErrorMessage = "El campo código de Región debe tener 2 dígitos numéricos")]
        public string RegionCode { get; set; }

        [Required(ErrorMessage = "El campo Provincia es obligatorio")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "El campo código de Provincia debe tener 4 dígitos numéricos")]
        public string ProvinceCode { get; set; }

        [Required(ErrorMessage = "El campo Ubigeo es obligatorio")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "El campo código de Ubigeo debe tener 6 dígitos numéricos")]
        public string UbigeoCode { get; init; }

        [Required(ErrorMessage = "El campo Activo es obligatorio")]
        public bool Active { get; set; }

    }
}