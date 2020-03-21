namespace SistemaAcademico.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterEstudiante_nombres_apellidos_obligatorios : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Estudiantes", "Nombres", c => c.String(nullable: false, maxLength: 150, unicode: false));
            AlterColumn("dbo.Estudiantes", "Apellidos", c => c.String(nullable: false, maxLength: 150, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Estudiantes", "Apellidos", c => c.String(maxLength: 150, unicode: false));
            AlterColumn("dbo.Estudiantes", "Nombres", c => c.String(maxLength: 150, unicode: false));
        }
    }
}
