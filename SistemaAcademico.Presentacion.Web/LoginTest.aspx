<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginTest.aspx.cs" Inherits="SistemaAcademico.Presentacion.Web.LoginTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <fieldset class="form-horizontal">
        <legend>Iniciar Sesion</legend>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label class="label-form col-md-4">Usuario: </label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>                    
                </div>
                <div class="form-group">
                    <label class="label-form col-md-4">Contraseña: </label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>                    
                </div>
                <div class="form-group">
                    <asp:Label ID="lblMensaje" runat="server" Text="[mensaje]" CssClass="label-form col-md-12 text-danger "></asp:Label>              
                </div>
                <div class="form-group">
                    <div class="col-md-12">
                        <asp:Button ID="btnLogin" runat="server" Text="Inicar Sesión" CssClass="btn btn-primary" />         
                    </div>                    
                </div>
            </div>

        </div>
        

    </fieldset>

</asp:Content>
