using Graff.Business;
using Graff.Database.Model;
using System;

namespace projetoTesteGraff
{
    public partial class cadastraUsuario : System.Web.UI.Page
    {
        private readonly CadastraUsuarioBusiness cadastraUsuarioBusiness;

        public cadastraUsuario()
        {
            cadastraUsuarioBusiness = new CadastraUsuarioBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            testeRodrigo_USUARIO u = new testeRodrigo_USUARIO();
            u.DS_NOME_USUARIO = txtNomeUsuario.Text;
            u.DT_NASCIMENTO_USUARIO = Convert.ToDateTime(txtDataNascimento.Text);
            u.DS_EMAIL_USUARIO = txtEmailUsuario.Text;
            u.DS_SENHA_USUARIO = txtSenha.Text;
            u.DT_INCLUSAO_USUARIO = DateTime.Now;

            try
            {
                cadastraUsuarioBusiness.adicionarUsuario(u);
                Response.Redirect("realizaLogin.aspx", true);
            }
            catch (Exception ex)
            {
                ltErro.Text = $@"<div class='alert alert-danger'>{ex.Message}</div>";
            }
        }
    }
}