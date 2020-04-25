<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarRoles.aspx.cs" Inherits="SistemaAcademico.Presentacion.Web.Seguridad.AsignarRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Asignación de Roles</h4>
    <hr />
    <div class="row">
        <div class="col-xs-12 col-md-6">
            <div class="form-group">
                <label class="form-label">Roles registrados</label>
            </div>            
            <asp:GridView ID="dgvRoles" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                DataKeyNames="Id" DataSourceID="sdsRoles" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Código" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-xs-12 col-md-6">
            <div class="form-inline">
                <div class="form-group">
                    <label class="form-label col-md-4">Usuarios:</label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlUsuarios" runat="server" CssClass="form-control" DataSourceID="sdsUsuariosDDL" DataTextField="UserName" DataValueField="Id"></asp:DropDownList>
                        <asp:SqlDataSource ID="sdsUsuariosDDL" runat="server" ConnectionString="Data Source=.\SQLEXPRESS01;Initial Catalog=SistemaAcademico;Integrated Security=True;MultipleActiveResultSets=True;Application Name=SistemaAcademico_Data" InsertCommand="INSERT INTO AspNetUserRoles(UserId, RoleId) VALUES (@Id, @RoleId)" ProviderName="System.Data.SqlClient" SelectCommand="SELECT AspNetUsers.Id, AspNetUsers.UserName, AspNetUserRoles.RoleId FROM AspNetUsers LEFT OUTER JOIN AspNetUserRoles ON AspNetUsers.Id = AspNetUserRoles.UserId WHERE (AspNetUserRoles.RoleId IS NULL) OR (AspNetUserRoles.RoleId &lt;&gt; @RoleId)">
                            <InsertParameters>
                                <asp:ControlParameter ControlID="ddlUsuarios" DefaultValue="0" Name="Id" PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="dgvRoles" DefaultValue="0" Name="RoleId" PropertyName="SelectedValue" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:ControlParameter ControlID="dgvRoles" DefaultValue="0" Name="RoleId" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div> 
                <div class="form-group">
                    <asp:Button ID="btnAsignarUsuario" runat="server" Text="Asignar" CssClass="btn btn-default" OnClick="btnAsignarUsuario_Click" />
                </div>                
            </div>
            <asp:GridView ID="dgvUsuarios" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                DataKeyNames="UserId,RoleId" DataSourceID="sdsUsuarios" CssClass="table table-striped" OnRowDeleted="dgvUsuarios_RowDeleted">
                <Columns>
                    <asp:BoundField DataField="UserId" HeaderText="UserId" ReadOnly="True" SortExpression="UserId" Visible="False" />
                    <asp:BoundField DataField="RoleId" HeaderText="RoleId" SortExpression="RoleId" ReadOnly="True" Visible="False" />
                    <asp:BoundField DataField="UserName" HeaderText="Usuario" SortExpression="UserName" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>


<asp:SqlDataSource ID="sdsRoles" runat="server" 
    ConnectionString="Data Source=.\SQLEXPRESS01;Initial Catalog=SistemaAcademico;Integrated Security=True;MultipleActiveResultSets=True;Application Name=SistemaAcademico_Data" 
    ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [AspNetRoles]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsUsuarios" runat="server" ConnectionString="Data Source=.\SQLEXPRESS01;Initial Catalog=SistemaAcademico;Integrated Security=True;MultipleActiveResultSets=True;Application Name=SistemaAcademico_Data" ProviderName="System.Data.SqlClient" SelectCommand="SELECT AspNetUserRoles.UserId, AspNetUserRoles.RoleId, AspNetUsers.UserName FROM AspNetUserRoles INNER JOIN AspNetUsers ON AspNetUserRoles.UserId = AspNetUsers.Id WHERE (AspNetUserRoles.RoleId = @RoleId)" DeleteCommand="DELETE FROM AspNetUserRoles WHERE (UserId = @UserId) AND (RoleId = @RoleId)">
        <DeleteParameters>
            <asp:Parameter Name="UserId" />
            <asp:Parameter Name="RoleId" />
        </DeleteParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="dgvRoles" DefaultValue="0" Name="RoleId" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
