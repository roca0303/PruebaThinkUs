using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaThinkUs.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        public string? Apellidos { get; set; }

        [Required(ErrorMessage = "Genero es obligatorio")]
        public string? Genero { get; set; }

        [Required(ErrorMessage = "Fecha de nacimiento es obligatorio")]
        public DateTime? FechaNacimiento { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime FechaCreacion { get; set; }

    }
}
