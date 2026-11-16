using System;
using System.ComponentModel.DataAnnotations;

namespace Clientes.Models
{
    public class ClienteModel
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "La cédula es obligatoria")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Ingrese 10 caracteres")]
        public string cedula { get; set; } = "";

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Los nombres son obligatorios")]
        [StringLength(100)]
        public string nombre { get; set; } = "";

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(100)]
        public string apellido { get; set; } = "";

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(200)]
        public string direccion { get; set; } = "";

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(20)]
        public string telefono { get; set; } = "";

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese un correo válido")]
        [StringLength(150)]
        public string mail { get; set; } = "";

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "La ciudad es obligatoria")]
        [StringLength(100)]
        public string ciudad { get; set; } = "";

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "La provincia es obligatoria")]
        [StringLength(100)]
        public string provincia { get; set; } = "";

        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime fechaNacimiento { get; set; } = DateTime.Today;

        [Display(Name = "Activo")]
        public bool activo { get; set; } = true;
    }
}
