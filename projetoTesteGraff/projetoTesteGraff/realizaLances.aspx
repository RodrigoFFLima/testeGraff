<%@ Page Title="Realizar Lance" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="realizaLances.aspx.cs" Inherits="projetoTesteGraff.realizarLance" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %> </h2>

    <div id="quadro" class="col-xs-4 col-xs-offset-4">
        <div class="row">
            <div class="form-group col-md-12">
                <label for="exampleInputEmail1">Selecione um produto: </label>
                <asp:DropDownList ID="cbxProdutos" runat="server" CssClass="form-control" DataSourceID="dsProdutos" DataTextField="DS_NOME_PRODUTO" DataValueField="ID_PRODUTO" OnSelectedIndexChanged ="cbxProdutos_SelectedIndexChanged" AutoPostBack="true" OnDataBound="cbxProdutos_DataBound">
                </asp:DropDownList>
            <asp:ObjectDataSource ID="dsProdutos" runat="server" SelectMethod="getAllProdutos" TypeName="Graff.Business.CadastraProdutoBusiness"></asp:ObjectDataSource>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-12">
                <label for="exampleInputEmail1">Ultimo lance realizado: </label>
                <asp:TextBox AutoPostBack="false" runat="server" type="text" class="form-control" id="txtUltimoLance2" ReadOnly="true"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-12">
                <label for="exampleInputEmail1">Seu lance: </label>
                <asp:TextBox AutoPostBack="false" runat="server" type="number" class="form-control" id="txtLanceAtual" placeholder="Digite seu lance" MaxLength="9"></asp:TextBox>
            </div>
        </div>
        
        <asp:Literal ID="ltErro" runat="server"></asp:Literal>
        <div id="resultado" style="color: red"></div>
        
        <br />
        <hr />


        <div class="row">
            <div class="col-md-12">
                <asp:Button runat="server" ID="btnConcluir" CssClass="btn btn-primary" Text="Concluir" OnClientClick="return validaLance()" OnClick="btnConcluir_Click"/>
                <a href="~/Home" class="btn btn-default" runat="server" id="btnCancelar">Cancelar</a>
            </div>
        </div>
    </div>
    <script>
        function validaLance() {
            var erro = '';
            var lance = document.getElementById("<%=txtLanceAtual.ClientID%>").value;

            if (lance == '') {
                erro += "\nLance não autorizado - Campo Lance em branco!"
            }

            if (erro != '') {
                document.getElementById("resultado").innerHTML = erro;
                return false; // true for postback and false for not postback
            }
            else {
                return true; // true for postback and false for not postback
            }
        }
    </script>
</asp:Content>
