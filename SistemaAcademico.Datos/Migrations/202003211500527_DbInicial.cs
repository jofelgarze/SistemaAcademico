namespace SistemaAcademico.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(maxLength: 150, unicode: false),
                        Apellidos = c.String(maxLength: 150, unicode: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Estudiantes");
        }
    }
}
