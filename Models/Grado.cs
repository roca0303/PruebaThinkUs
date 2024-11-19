using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PruebaThinkUs.Models
{
    public class Grado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El Profesor es obligatorio")]
        public int ProfesorId { get; set; }

        [ForeignKey("ProfesorId")]
        
        public Profesor? Profesor { get; set; }


    }
}
