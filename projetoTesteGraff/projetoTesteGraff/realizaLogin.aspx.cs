using Graff.Business;
using Graff.Database.Model;
using System;
using Graff.Shared.Extension;

namespace projetoTesteGraff
{
    public partial class realizaLogin : System.Web.UI.Page
    {
        private testeRodrigo_USUARIO UsuarioLogado => Session.GetValue<testeRodrigo_USUARIO>("usuarioLogado");
        private readonly CadastraUsuarioBusiness cadastraUsuarioBusiness;

        public realizaLogin()
        {
            cadastraUsuarioBusiness = new CadastraUsuarioBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            testeRodrigo_USUARIO u = new testeRodrigo_USUARIO();
            u.DS_EMAIL_USUARIO = txtEmailUsuario.Text;
            u.DS_SENHA_USUARIO = txtSenha.Text;

            u = cadastraUsuarioBusiness.getConfirmaLoginSenha(u.DS_EMAIL_USUARIO, u.DS_SENHA_USUARIO);

            if(u != null)
            {   
                Session.Add("usuarioLogado", u);
                Response.Redirect("Home.aspx", true);
            }
            else
            {
                ltErro.Text = $@"<div class='alert alert-danger'>Dados Invalidos</div>";
            }
        }
    }
}