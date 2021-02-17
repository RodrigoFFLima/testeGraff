using Graff.Database.Model;
using Graff.Shared.Extension;
using System;
using System.Web;

namespace projetoTesteGraff
{
    public partial class _Default : System.Web.UI.Page
    {
        private testeRodrigo_USUARIO UsuarioLogado => Session.GetValue<testeRodrigo_USUARIO>("usuarioLogado");

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (UsuarioLogado != null)
                    txtBemVindo.InnerText = "Olá, " + ((Graff.Database.Model.testeRodrigo_USUARIO)HttpContext.Current.Session["usuarioLogado"]).DS_NOME_USUARIO + 
                                            "! Seja bem-vindo ao maior portal de leilões do Brasil!";
                else
                    txtBemVindo.InnerText = "Seja bem-vindo ao maior portal de leilões do Brasil!";
            }
        }
    }
}