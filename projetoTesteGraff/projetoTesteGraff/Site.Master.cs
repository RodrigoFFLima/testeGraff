using Graff.Database.Model;
using Graff.Shared.Extension;
using System;
using System.Web;
using System.Web.UI;

namespace projetoTesteGraff
{
    public partial class SiteMaster : MasterPage
    {
        private testeRodrigo_USUARIO UsuarioLogado => Session.GetValue<testeRodrigo_USUARIO>("usuarioLogado");

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}