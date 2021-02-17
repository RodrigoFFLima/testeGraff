<%@ Page Title="Cadastrar Produtos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadastraProdutos.aspx.cs" Inherits="projetoTesteGraff.cadastraProduto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div id="quadro" class="col-xs-4 col-xs-offset-4">
        <div class="row">
            <div class="form-group col-md-12">
                <label for="exampleInputdescricaoProduto1">Produto: </label>
                <asp:TextBox AutoPostBack="false" runat="server" type="text" class="form-control" id="txtNomeProduto" placeholder="Digite o nome do Produto" MaxLength="200"></asp:TextBox>
            </div>
        </div>
        
        <div class="row">
            <div class="form-group col-md-12">
                <label for="exampleInputdescricaoProduto1">Descrição: </label>
                <asp:TextBox AutoPostBack="false" runat="server" type="text" class="form-control" id="txtDescricaoProduto" placeholder="Digite uma descrição para o Produto" MaxLength="200"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-12">
                <label for="exampleInputdescricaoProduto1">Lance Inicial: </label>
                <asp:TextBox AutoPostBack="false" runat="server" type="number" class="form-control" id="txtLanceInicial" placeholder="Digite o valor" MaxLength="9"></asp:TextBox>
            </div>
        </div>
        
        <asp:Literal ID="ltErro" runat="server"></asp:Literal>
        <div id="resultadoP" style="color: red"></div>
        <br />

        <hr />

        <div class="row">
            <div class="col-md-12">
                <asp:Button runat="server" ID="btnCadastrar" CssClass="btn btn-primary" Text="Cadastrar" OnClientClick="return validaProduto();" OnClick="btnCadastrar_Click" />
                <a href="~/Home" class="btn btn-default" id="btnCancelar">Cancelar</a>
            </div>
        </div>
    </div>
    
    <script>
        function validaProduto() {
            var erroP = '';
            var nomeProduto = document.getElementById("<%=txtNomeProduto.ClientID%>").value;
            var descricaoProduto = document.getElementById("<%=txtDescricaoProduto.ClientID%>").value;
            var lance = document.getElementById("<%=txtLanceInicial.ClientID%>").value;

            if (nomeProduto == '') {
                erroP += "\n\nErro - Campo nome do produto em branco!"
            }

            if (descricaoProduto == '') {
                erroP += "\n\nErro - Campo descrição do produto em branco!"
            }

            if (lance == '') {
                erroP += "\n\nErro - Campo lance em branco!"
            }

            if (erroP != '') {
                document.getElementById("resultadoP").innerHTML = erroP;
                return false; // true for postback and false for not postback
            }
            else {
                return true; // true for postback and false for not postback
            }
        }
    </script>
</asp:Content>
