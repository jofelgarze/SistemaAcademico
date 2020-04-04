<%@ Page Title="Consulta Matriculacion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsutaMatriculacion.aspx.cs" Inherits="SistemaAcademico.Presentacion.Web.Administracion.ConsutaMatriculacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>.</h2>
    <h4>Estudiantes registrados</h4>

    <div class="row">
        <div class="col-md-offset-1 col-md-10">
            <asp:GridView ID="grvEstudianes" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover" HeaderStyle-CssClass="thead-dark">
                <Columns>
                    <asp:BoundField AccessibleHeaderText="Código Matricula" DataField="CodigoEstudiante" HeaderText="Cod." ReadOnly="True" />
                    <asp:BoundField AccessibleHeaderText="Apellidos" DataField="Apellidos" HeaderText="Apellidos" ReadOnly="True" />
                    <asp:BoundField AccessibleHeaderText="Nombres" DataField="Nombres" HeaderText="Nombres" ReadOnly="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
