using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Datos.Entidades
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(150)]
        [Required]
        public String Nombres { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(150)]
        [Required]
        public String Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Activo { get; set; }
    }
}
