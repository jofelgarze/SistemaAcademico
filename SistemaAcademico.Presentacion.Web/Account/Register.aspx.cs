using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SistemaAcademico.Presentacion.Web;
using SistemaAcademico.Presentacion.Web.Models;

namespace SistemaAcademico.Presentacion.Web.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = txtUsuario.Text, Email = Email.Text, Identificacion = txtIdentificacion.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {                
                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}