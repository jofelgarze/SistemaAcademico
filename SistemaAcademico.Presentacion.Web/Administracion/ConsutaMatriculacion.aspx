<%@ Page Title="Consulta Matriculacion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsutaMatriculacion.aspx.cs" Inherits="SistemaAcademico.Presentacion.Web.Administracion.ConsutaMatriculacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>.</h2>
    <h4>Estudiantes registrados</h4>

    <div class="row">
        <div class="col-md-offset-1 col-md-10">
             <asp:Panel ID="pnlMensaje" runat="server" Visible="false">
                <asp:Label ID="lblMensaje" runat="server" Text="[mensaje]"></asp:Label>
            </asp:Panel>
            <asp:GridView ID="dgvMatriculas" runat="server" AutoGenerateColumns="False" DataSourceID="odsMatriculacion"
                 CssClass="table table-striped table-hover" AllowPaging="True" OnRowDeleting="dgvMatriculas_RowDeleting" >
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"  OnClientClick="return confirm('¿Desea eliminar el registro?')" Text="Eliminar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="Nombres" HeaderText="Nombres" SortExpression="Nombres" />
                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" SortExpression="FechaNacimiento" ReadOnly="True" Visible="False" />
                    <asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" />
                </Columns>
             </asp:GridView>
            <asp:ObjectDataSource ID="odsMatriculacion" runat="server" SelectMethod="consultarTodos" 
                TypeName="SistemaAcademico.Presentacion.Web.Models.MatriculacionBL" 
                DataObjectTypeName="SistemaAcademico.Presentacion.Web.Models.Estudiante" 
                DeleteMethod="eliminar"  InsertMethod="insertar" UpdateMethod="modificar">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
             </asp:ObjectDataSource>
        </div>
    </div>

</asp:Content>
