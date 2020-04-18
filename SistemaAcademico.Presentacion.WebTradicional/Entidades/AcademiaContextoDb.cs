namespace SistemaAcademico.Presentacion.WebTradicional.Entidades
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AcademiaContextoDb : DbContext
    {
        public AcademiaContextoDb()
            : base("SistemaAcademicoConnectionDb")
        {
        }

        public DbSet<Entidades.Estudiante> Estudiantes { get; set; }
        
    }

}