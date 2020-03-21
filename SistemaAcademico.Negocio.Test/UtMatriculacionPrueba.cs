using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaAcademico.Negocio.Dto;

namespace SistemaAcademico.Negocio.Test
{
    /// <summary>
    /// Descripción resumida de UnitTest1
    /// </summary>
    [TestClass]
    public class UtMatriculacionPrueba
    {
        private static UtMatriculacion matriculacion;

        public UtMatriculacionPrueba()
        {

        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) {
            matriculacion = new UtMatriculacion();
        }

        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        [ClassCleanup()]
        public static void MyClassCleanup() {
            matriculacion.Dispose();
        }

        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        [TestInitialize()]
        public void MyTestInitialize() { }

        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        [TestCleanup()]
        public void MyTestCleanup() { }

        #endregion

        [TestMethod]
        public void PruebaMatriculacionEstudianteNuevo_Existoso()
        {
            var datos = new MatriculacionEstudianteDto()
            {
                PrimerNombre = "Josue",
                SegundoNombre = "Felix",
                PrimerApellido = "García",
                SegundoApellido = "Zelaya",
                FechaNacimiento = DateTime.Parse("1989-01-30"),
                PagoRealizado = true
            };

            var resultado = matriculacion.MatricularEstudianteNuevo(datos);

            

            Assert.AreEqual(datos.PrimerNombre + " " + datos.SegundoNombre, resultado.Nombres);
            Assert.IsTrue(resultado.CodigoEstudiante > 0);

        }

        [TestMethod]
        public void PruebaConsutlaEstudianteMatriculado_Existoso()
        {
            var resultado = matriculacion.ConsultarRegistroEstudiante(1);

            Assert.AreEqual("Josue Felix", resultado.Nombres);
            Assert.IsTrue(resultado.CodigoEstudiante > 0);

        }
    }
}
