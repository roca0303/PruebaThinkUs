using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaThinkUs.Models
{
    public class Profesor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        public string? Apellidos { get; set; }

        [Required(ErrorMessage = "Genero es obligatorio")]
        public string? Genero { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime FechaCreacion { get; set; }

    }
}
