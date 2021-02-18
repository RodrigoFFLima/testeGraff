using Graff.Business;
using Graff.Database.Model;
using System;
using System.Web.UI.WebControls;
using Graff.Shared.Extension;

namespace projetoTesteGraff
{
    public partial class realizarLance : System.Web.UI.Page
    {
        private testeRodrigo_USUARIO UsuarioLogado => Session.GetValue<testeRodrigo_USUARIO>("usuarioLogado");
        private readonly RealizaLanceBusiness realizaLanceBusiness;
        private readonly CadastraProdutoBusiness cadastraProdutoBusiness;

        public realizarLance()
        {
            realizaLanceBusiness = new RealizaLanceBusiness();
            cadastraProdutoBusiness = new CadastraProdutoBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (UsuarioLogado == null)
                    Response.Redirect("realizaLogin.aspx", true);
            }
        }

        protected void btnConcluir_Click(object sender, EventArgs e)
        {
            decimal? ultimoLance = Convert.ToDecimal(txtUltimoLance2.Text.Split(' ')[1]);
            testeRodrigo_LANCES l = new testeRodrigo_LANCES();
            l.ID_PRODUTO = Convert.ToInt32(cbxProdutos.SelectedItem.Value);
            l.ID_USUARIO = UsuarioLogado.ID_USUARIO;
            l.VL_LANCE_ANTERIOR = ultimoLance;
            l.VL_LANCE_ATUAL = Convert.ToDecimal(txtLanceAtual.Text);
            l.DT_LANCE = DateTime.Now;

            try
            {
                if (Convert.ToDecimal(txtLanceAtual.Text) > ultimoLance)
                {
                    realizaLanceBusiness.geraNovoLance(l);
                    Response.Redirect("consultaLances.aspx", true);
                }
                else
                {
                    ltErro.Text = $@"<div class='alert alert-danger'>O novo lance tem que ser maior que o lance anterior</div>";
                }
            }
            catch (Exception ex)
            {
                ltErro.Text = $@"<div class='alert alert-danger'>{ex.Message}</div>";
            }
        }

        protected void cbxProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ultimoLance = realizaLanceBusiness.getLanceAnterior(Convert.ToInt32(cbxProdutos.SelectedItem.Value));

            if (ultimoLance != null)
                txtUltimoLance2.Text = "R$ " + realizaLanceBusiness.getLanceAnterior(Convert.ToInt32(cbxProdutos.SelectedItem.Value)).VL_LANCE_ANTERIOR.ToString();
            else
                txtUltimoLance2.Text = "R$ " + cadastraProdutoBusiness.getProdutoByCodigo(Convert.ToInt32(cbxProdutos.SelectedItem.Value)).VL_LANCE_INICIAL.ToString();
        }

        protected void cbxProdutos_DataBound(object sender, EventArgs e)
        {
            InsertFirstItemDropDownList(sender as DropDownList, "-- Selecione um Produto --");
        }

        private void InsertFirstItemDropDownList(DropDownList cmb, string text)
        {
            cmb.Items.Insert(0, new ListItem(text, "0"));
            cmb.Items[0].Selected = true;
        }
    }
}