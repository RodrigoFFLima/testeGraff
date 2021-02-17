using Graff.Business;
using Graff.Database.Model;
using Graff.Shared.Extension;
using System;
using System.Web.UI;

namespace projetoTesteGraff
{
    public partial class cadastraProduto : Page
    {
        private testeRodrigo_USUARIO UsuarioLogado => Session.GetValue<testeRodrigo_USUARIO>("usuarioLogado");

        private readonly CadastraProdutoBusiness cadastraProdutoBusiness;

        public cadastraProduto()
        {
            cadastraProdutoBusiness = new CadastraProdutoBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(UsuarioLogado == null)
                    Response.Redirect("realizaLogin.aspx", true);

            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            testeRodrigo_PRODUTO p = new testeRodrigo_PRODUTO();
            p.DS_NOME_PRODUTO = txtNomeProduto.Text;
            p.DS_PRODUTO = txtDescricaoProduto.Text;
            p.VL_LANCE_INICIAL = Convert.ToDecimal(txtLanceInicial.Text);
            p.DT_INCLUSAO_PRODUTO = DateTime.Now;

            try
            {
                cadastraProdutoBusiness.adicionarProduto(p);
                Response.Redirect("consultaLances.aspx", true);
            }
            catch (Exception ex)
            {
                ltErro.Text = $@"<div class='alert alert-danger'>{ex.Message}</div>";
            }

        }
    }
}