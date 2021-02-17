using Graff.Database.Model;
using Graff.Shared.Extension;
using System;

namespace projetoTesteGraff
{
    public partial class Sair : System.Web.UI.Page
    {
        private testeRodrigo_USUARIO UsuarioLogado => Session.GetValue<testeRodrigo_USUARIO>("usuarioLogado");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UsuarioLogado != null)
            {
                Session.Remove("usuarioLogado");
                Response.Redirect("realizaLogin.aspx", true);
            }
        }
    }
}