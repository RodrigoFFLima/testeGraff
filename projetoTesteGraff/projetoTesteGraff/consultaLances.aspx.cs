using Graff.Business;
using Graff.Database.Model;
using Graff.Shared.Extension;
using System;
using System.Collections.Generic;

namespace projetoTesteGraff
{
    public partial class consultaLances : System.Web.UI.Page
    {
        private testeRodrigo_USUARIO UsuarioLogado => Session.GetValue<testeRodrigo_USUARIO>("usuarioLogado");
        private readonly RealizaLanceBusiness realizaLanceBusiness;
        private readonly CadastraProdutoBusiness cadastraProdutoBusiness;
        private readonly CadastraUsuarioBusiness cadastraUsuarioBusiness;

        public consultaLances()
        {
            realizaLanceBusiness = new RealizaLanceBusiness();
            cadastraProdutoBusiness = new CadastraProdutoBusiness();
            cadastraUsuarioBusiness = new CadastraUsuarioBusiness();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (UsuarioLogado == null)
                    Response.Redirect("realizaLogin.aspx", true);

                carregaListaLances();
            }
        }

        private void carregaListaLances()
        {
            List<testeRodrigo_LANCES> lLances = new List<testeRodrigo_LANCES>();
            lLances = realizaLanceBusiness.getAllLANCES();

            string lances = "";

            foreach (var item in lLances)
            {
                testeRodrigo_PRODUTO p = new testeRodrigo_PRODUTO();
                p = cadastraProdutoBusiness.getProdutoByCodigo(Convert.ToInt32(item.ID_PRODUTO));

                testeRodrigo_USUARIO u = new testeRodrigo_USUARIO();
                u = cadastraUsuarioBusiness.getUsuarioByCodigo(Convert.ToInt32(item.ID_USUARIO));

                string tbdoyLance = "<tr> " +
                "            <td>{0}</td> " +
                "            <td>{1}</td> " +
                "            <td>{2}</td> " +
                "            <td>R$ {3}</td> " +
                "            <td>{4}</td> " +
                "        </tr> ";

                lances += string.Format(tbdoyLance, p.DS_NOME_PRODUTO, p.DS_PRODUTO, u.DS_NOME_USUARIO, item.VL_LANCE_ATUAL, Convert.ToDateTime(item.DT_LANCE.ToString()).ToShortDateString());
            }

            listLances.Text = lances;
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            List<testeRodrigo_LANCES> lLances = new List<testeRodrigo_LANCES>();
            lLances = realizaLanceBusiness.getAllLANCES();

            string lances = "";

            foreach (var item in lLances)
            {
                int? codigoProduto = 0;

                testeRodrigo_PRODUTO p = new testeRodrigo_PRODUTO();
                p = cadastraProdutoBusiness.getProdutoByCodigo(Convert.ToInt32(item.ID_PRODUTO));

                testeRodrigo_USUARIO u = new testeRodrigo_USUARIO();
                u = cadastraUsuarioBusiness.getUsuarioByCodigo(Convert.ToInt32(item.ID_USUARIO));

                if (u.DS_NOME_USUARIO.Contains(searchUsuario.Value) && !string.IsNullOrEmpty(searchUsuario.Value) && codigoProduto != 0)
                {
                    string tbdoyLance = "<tr> " +
                    "            <td>{0}</td> " +
                    "            <td>{1}</td> " +
                    "            <td>{2}</td> " +
                    "            <td>R$ {3}</td> " +
                    "            <td>{4}</td> " +
                    "        </tr> ";

                    codigoProduto = item.ID_PRODUTO;

                    lances += string.Format(tbdoyLance, p.DS_NOME_PRODUTO, p.DS_PRODUTO, u.DS_NOME_USUARIO, item.VL_LANCE_ATUAL, Convert.ToDateTime(item.DT_LANCE.ToString()));
                }

                if (p.DS_NOME_PRODUTO.Contains(searchProduto.Value) && !string.IsNullOrEmpty(searchProduto.Value) && codigoProduto != 0)
                {
                    string tbdoyLance = "<tr> " +
                    "            <td>{0}</td> " +
                    "            <td>{1}</td> " +
                    "            <td>{2}</td> " +
                    "            <td>R$ {3}</td> " +
                    "            <td>{4}</td> " +
                    "        </tr> ";

                    codigoProduto = item.ID_PRODUTO;

                    lances += string.Format(tbdoyLance, p.DS_NOME_PRODUTO, p.DS_PRODUTO, u.DS_NOME_USUARIO, item.VL_LANCE_ATUAL, Convert.ToDateTime(item.DT_LANCE.ToString()));
                }

                else if (codigoProduto == 0)
                {
                    string tbdoyLance = "<tr> " +
                    "            <td>{0}</td> " +
                    "            <td>{1}</td> " +
                    "            <td>{2}</td> " +
                    "            <td>R$ {3}</td> " +
                    "            <td>{4}</td> " +
                    "        </tr> ";

                    codigoProduto = item.ID_PRODUTO;

                    lances += string.Format(tbdoyLance, p.DS_NOME_PRODUTO, p.DS_PRODUTO, u.DS_NOME_USUARIO, item.VL_LANCE_ATUAL, Convert.ToDateTime(item.DT_LANCE.ToString()));
                }

            }

            listLances.Text = lances;
        }
    }
}