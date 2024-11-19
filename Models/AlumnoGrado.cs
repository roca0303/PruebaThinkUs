using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaThinkUs.Models
{
    public class AlumnoGrado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Alumno es obligatorio")]
        public int AlumnoId { get; set; }

        [ForeignKey("AlumnoId")]
        public Alumno? Alumno { get; set; }

        [Required(ErrorMessage = "El Grado es obligatorio")]
        public int GradoId { get; set; }

        [ForeignKey("GradoId")]
        public Grado? Grado { get; set; }

        [Required(ErrorMessage = "El Grupo es obligatorio")]
        public required string Grupo { get; set; }

    }
}
