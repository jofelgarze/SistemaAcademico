<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estudiante.aspx.cs" Inherits="SistemaAcademico.Presentacion.WebTradicional.Estudiante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h4>Estudiantes</h4>
    <hr />
    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <div class="col-md-8">
                     <div class="form-group">
                        <label class="label-form col-md-4">Tipo Doc.</label>
                        <div class="col-md-8">                       
                            <asp:DropDownList ID="ddlTipoDoc" runat="server"  CssClass="form-control" DataSourceID="sdsCatalogo"
                                DataTextField="Descripcion" DataValueField="Id"></asp:DropDownList>
                            
                        </div>
                    </div>
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
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="sdsEstudiantes"
                    CssClass="table table-stripped">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Nombres" HeaderText="Nombres" SortExpression="Nombres" />
                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" SortExpression="FechaNacimiento" />
                    <asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" />
                    <asp:TemplateField HeaderText="Tipo Doc." SortExpression="TipoDocumentoId">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" DataSourceID="sdsCatalogo" DataTextField="Descripcion" DataValueField="Id" SelectedValue='<%# Bind("TipoDocumentoId") %>'>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" DataSourceID="sdsCatalogo" DataTextField="Descripcion" DataValueField="Id" Enabled="False" SelectedValue='<%# Bind("TipoDocumentoId") %>'>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="sdsEstudiantes" runat="server" ConnectionString="<%$ ConnectionStrings:SistemaAcademicoConnectionDb %>" DeleteCommand="DELETE FROM [Estudiantes] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Estudiantes] ([Nombres], [Apellidos], [FechaNacimiento], [Activo]) VALUES (@Nombres, @Apellidos, @FechaNacimiento, @Activo)" SelectCommand="SELECT * FROM [Estudiantes]" UpdateCommand="UPDATE [Estudiantes] SET [Nombres] = @Nombres, [Apellidos] = @Apellidos, [FechaNacimiento] = @FechaNacimiento, [Activo] = @Activo WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:ControlParameter ControlID="txtNombres" Name="Nombres" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="txtApellidos" Name="Apellidos" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="txtFechaNac" Name="FechaNacimiento" PropertyName="Text" Type="DateTime" />
                    <asp:ControlParameter ControlID="chkActivo" Name="Activo" PropertyName="Checked" Type="Boolean" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Nombres" Type="String" />
                    <asp:Parameter Name="Apellidos" Type="String" />
                    <asp:Parameter Name="FechaNacimiento" Type="DateTime" />
                    <asp:Parameter Name="Activo" Type="Boolean" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsCatalogo" runat="server" ConnectionString="<%$ ConnectionStrings:SistemaAcademicoConnectionDb %>" DeleteCommand="DELETE FROM [Catalogo] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Catalogo] ([Descripcion]) VALUES (@Descripcion)" SelectCommand="SELECT * FROM [Catalogo]" UpdateCommand="UPDATE [Catalogo] SET [Descripcion] = @Descripcion WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Descripcion" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Descripcion" Type="String" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </div>

</asp:Content>
