﻿using SistemaAcademico.Negocio.Dto;
using SistemaAcademico.Presentacion.Servicios.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SistemaAcademico.Presentacion.Servicios.Administracion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMatriculacionService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMatriculacionService
    {
        [OperationContract]
        Respuesta<int> RegistrarEstudianteNuevo(MatriculacionEstudianteDto Datos);

        [OperationContract]
        Respuesta<List<MatriculacionEstudianteRespDto>> ConsultarEstudiantesMatriculados();
        
        [OperationContract]
        Respuesta<MatriculacionEstudianteRespDto> ConsultarEstudianteMatriculado(int Identificacion);

        [OperationContract]
        Respuesta<MatriculacionEstudianteRespDto> ModificarEstudianteMatriculado(int Identificacion, MatriculacionEstudianteDto Datos);

        [OperationContract]
        Respuesta<string> EliminarEstudianteMatriculado(int Identificacion);
    }
}
