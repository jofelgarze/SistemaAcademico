namespace SistemaAcademico.Datos
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AcademiaContextoDb : DbContext
    {
        public AcademiaContextoDb()
            : base("AcademiaContextoDb")
        {
        }

        public DbSet<Entidades.Estudiante> Estudiantes { get; set; }
        
    }

}