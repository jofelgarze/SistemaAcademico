<%@ Page Title="Matricular Estudiante" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MatriculacionEstudiante.aspx.cs" Inherits="SistemaAcademico.Presentacion.Web.Administracion.MatriculacionEstudiante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h4>Datos personales del apirante</h4>
    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label class="control-label col-sm-4" for="pwd">Nombre:</label>
                    <div class="col-sm-8"> 
                        <input type="text" class="form-control" id="nombre" placeholder="Primer Nombre..." autocomplete="off">
                    </div>
                </div>
            </div>
        </div>
    </div>    
</asp:Content>
