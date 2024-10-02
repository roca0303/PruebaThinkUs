using System.ComponentModel.DataAnnotations;

namespace PruebaThinkUs.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La posición es obligatoria")]
        public string? Posicion { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool? Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

    }
}
