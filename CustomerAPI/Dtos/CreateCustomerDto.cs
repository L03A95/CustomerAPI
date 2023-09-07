using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.Dtos
{
    public class CreateCustomerDto
    {
        [Required (ErrorMessage = "El nombre es requerido")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El apellido es requerido")]
        public string LastName { get; set; }
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Ingresa un formato de Email valido")]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

    }
}
