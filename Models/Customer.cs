using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Models
{

    // EF Core needs a C# class to represent a row: each property is a column and each
    // instance is one row. This class is the shared vocabulary of the whole app. The
    // controller receives it, EF Core saves it, and it is converted to JSON for the UI
    // (the property Name automatically becomes name in JSON).

    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string Phone { get; set; } = string.Empty;
    }
}