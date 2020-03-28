using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaAcademico.Datos;
using SistemaAcademico.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Datos.Test
{
    [TestClass]
    public class PruebaEstudianteCRUD
    {
        [TestMethod]
        public void TestCreacionEstudiante()
        {
            //Inicializar el contexto de la base de datos
            AcademiaContextoDb contextoDb = new AcademiaContextoDb();

            //Generar un registro de producto en c#
            Estudiante estudiante = new Estudiante();
            //producto.Id - es autoincremental, po lo que no se la debe usar al crear un registro
            estudiante.Apellidos = "Prueba Apellido";
            estudiante.Nombres = "Prueba Nombre";
            estudiante.FechaNacimiento= DateTime.UtcNow.AddYears(-18);
            estudiante.Activo = true;

            //Agregar el productio al contexto inicializado
            contextoDb.Estudiantes.Add(estudiante);

            //Guardar los cambios en ,la DB
            contextoDb.SaveChanges();

            //Consultar registro de producto en la DB - que tenga mismo nombre y precio
            var estudianteDb = contextoDb.Estudiantes.Where(x => x.Nombres == estudiante.Nombres && x.Apellidos == estudiante.Apellidos).SingleOrDefault();

            //Validar que se trate del mismi registro
            Assert.IsTrue(estudianteDb != null, "El estudiante se creo con el codigo" + estudianteDb.Id);
        }

        [TestMethod]
        public void TestModificarEstudiante()
        {
            //Inicializar el contexto de la base de datos
            AcademiaContextoDb contextoDb = new AcademiaContextoDb();

            //Consultar en la base de datos el registro a modificar
            var estudianteDb = contextoDb.Estudiantes
                .Where(item => item.Nombres == "Prueba Nombre")
                .SingleOrDefault();

            //Modificar las propiedades deseadas
            estudianteDb.Nombres = "Nombre modificado";
            estudianteDb.Apellidos = "Apellido modificado";

            //Guardar los cambios en la Base de Datos
            contextoDb.SaveChanges();

            //Validar que se modifico correctamente el registro
            Assert.IsNotNull(contextoDb.Estudiantes.Where(p => p.Nombres == estudianteDb.Nombres).SingleOrDefault());

        }

        [TestMethod]
        public void TestEliminarEstudiante()
        {
            //Inicializar el contexto de la base de datos
            AcademiaContextoDb contextoDb = new AcademiaContextoDb();

            //Consultar en la base de datos el registro a modificar
            var estudianteDb = contextoDb.Estudiantes.Where(item => item.Nombres == "Nombre modificado").ToList();

            //Modificar las propiedades deseadas
            contextoDb.Estudiantes.RemoveRange(estudianteDb);

            //Guardar los cambios en la Base de Datos
            var sa = contextoDb.SaveChanges();

            //Validar que se modifico correctamente el registro
            Assert.IsNotNull(sa > 0 ? "Registo eliminado" : "Registo no eliminado");

        }
    }
}
