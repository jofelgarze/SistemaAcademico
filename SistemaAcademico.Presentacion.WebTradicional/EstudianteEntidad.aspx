<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstudianteEntidad.aspx.cs" Inherits="SistemaAcademico.Presentacion.WebTradicional.EstudianteEntidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h4>Estudiantes</h4>
    <hr />
    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <div class="col-md-8">
                    <div class="form-group">
                        <label class="label-form col-md-4">Nombres</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="label-form col-md-4">Apellidos</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="label-form col-md-4">Fecha Nac.</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtFechaNac" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="label-form col-md-4">Activo</label>
                        <div class="col-md-8">
                            <asp:CheckBox ID="chkActivo" runat="server"  CssClass="label-form"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-4 col-md-8">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="dgvEstudiantes" runat="server" 
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="odsEstudiante"
                    CssClass="table table-stripped" OnRowCommand="dgvEstudiantes_RowCommand">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandArgument='<%# Bind("Id") %>' CommandName="Borrar" Text="Eliminar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="Nombres" HeaderText="Nombres" SortExpression="Nombres" />
                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" SortExpression="FechaNacimiento" />
                    <asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsEstudiante" runat="server" 
                DataObjectTypeName="SistemaAcademico.Presentacion.WebTradicional.Entidades.Estudiante" 
                InsertMethod="crear" 
                SelectMethod="consultarTodo" 
                TypeName="SistemaAcademico.Presentacion.WebTradicional.Entidades.RepEstudiantes" 
                UpdateMethod="modificar">
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
