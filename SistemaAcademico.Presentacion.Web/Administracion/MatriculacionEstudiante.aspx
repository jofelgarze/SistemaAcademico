<%@ Page Title="Matricular Estudiante" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MatriculacionEstudiante.aspx.cs" Inherits="SistemaAcademico.Presentacion.Web.Administracion.MatriculacionEstudiante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h4>Datos personales del apirante</h4>
    <div class="form-horizontal">
        <div class="row">
            <asp:Panel ID="pnlMensaje" runat="server" Visible="false">
                <asp:Label ID="lblMensaje" runat="server" Text="[mensaje]"></asp:Label>
            </asp:Panel>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="control-label col-sm-4">Apellidos:</label>
                    <div class="col-sm-8"> 
                        <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-4">Nombres:</label>
                    <div class="col-sm-8"> 
                        <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-4"></label>
                    <div class="col-sm-8"> 
                        <div class="checkbox">
                            <label>
                                <asp:CheckBox ID="chkPagoRealizado" runat="server" /> Pago Realizado
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-4 col-sm-8">
                        <asp:Button ID="btnMatricular" runat="server" CssClass="btn btn-success" Text="Matricular" OnClick="btnMatricular_Click" />
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" />
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label class="control-label">
                        <asp:RequiredFieldValidator ID="rfvApellidos" runat="server" ErrorMessage="Debe ingresar sus apellidos..."
                            ControlToValidate="txtApellidos" CssClass="text-danger" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </label>
                </div>
                <div class="form-group">
                    <label class="control-label">
                        <asp:RequiredFieldValidator ID="rfvNombres" runat="server" ErrorMessage="Debe ingresar sus Nombres..."
                            ControlToValidate="txtNombres" CssClass="text-danger" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </label>
                </div>
            </div>
        </div>
    </div>    
</asp:Content>
