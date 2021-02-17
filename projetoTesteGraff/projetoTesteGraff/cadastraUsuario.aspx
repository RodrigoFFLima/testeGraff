<%@ Page Title="Criar Nova Conta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadastraUsuario.aspx.cs" Inherits="projetoTesteGraff.cadastraUsuario" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %></h2>
    <div id="quadro" class="col-xs-4 col-xs-offset-4">
        <div class="row">
            <div class="form-group col-md-12">
                <label for="exampleInputEmail1">Nome Completo: </label>
                <asp:TextBox AutoPostBack="false" runat="server" type="text" class="form-control" ID="txtNomeUsuario" placeholder="Digite seu nome completo" MaxLength="200"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-12">
                <label for="txtDataNascimento">Data de Nascimento: </label>
                <asp:TextBox AutoPostBack="false" runat="server" type="date" class="form-control" ID="txtDataNascimento"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-12">
                <label for="exampleInputEmail1">E-mail: </label>
                <asp:TextBox AutoPostBack="false" runat="server" type="email" class="form-control" ID="txtEmailUsuario" placeholder="Digite seu e-mail" MaxLength="200"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-12">
                <label for="exampleInputEmail1">Senha: </label>
                <asp:TextBox AutoPostBack="false" runat="server" type="password" class="form-control" ID="txtSenha" placeholder="Digite sua senha" MaxLength="20"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-12">
                <label for="exampleInputEmail1">Confirma senha: </label>
                <asp:TextBox AutoPostBack="false" runat="server" type="password" class="form-control" ID="txtConfirmaSenha" placeholder="Confirme sua senha" MaxLength="20"></asp:TextBox>
            </div>
        </div>

        <asp:Literal ID="ltErro" runat="server"></asp:Literal>
        <div id="resultado" style="color: red"></div>
        <br />
        <hr />

        <div class="row">
            <div class="col-md-12">
                <asp:Button runat="server" ID="btnSalvar" CssClass="btn btn-primary" Text="Salvar" OnClientClick="return validaCadastro();" OnClick="btnSalvar_Click" />
                <a href="~/Home" class="btn btn-default" runat="server" id="btnCancelar">Cancelar</a>
            </div>
        </div>
    </div>

    <script>
        function getIdade(data) {
            var hoje = new Date();

            var nascimento = new Date(convertDateMMDDYYY(data.split("-")));

            //Retorna a diferença entre hoje e a data de nascimento em anos.
            var ano = hoje.getFullYear() - nascimento.getFullYear();

            //Retorna a diferença de mês do mês de nascimento para o atual.
            var m = hoje.getMonth() - nascimento.getMonth();

            //Caso ainda não tenha ultrapassado o dia e o mês
            if (m < 0 || (m === 0 && hoje.getDate() < nascimento.getDate())) {
                ano--;
            }
            return ano;
        }

        function convertDateMMDDYYY(datearray) {
            return datearray[1] + '-' + datearray[2] + '-' + datearray[0];
        }

        function validaCadastro() {
            console.log('');
            var data = document.getElementById("<%=txtDataNascimento.ClientID%>");
            var erro = '';
            var nome = document.getElementById("<%=txtNomeUsuario.ClientID%>").value;
            var email = document.getElementById("<%=txtEmailUsuario.ClientID%>").value;
            var senha = document.getElementById("<%=txtSenha.ClientID%>").value;
            var confirmaSenha = document.getElementById("<%=txtConfirmaSenha.ClientID%>").value;

            if (nome == '') {
                erro += "\nCadastro não autorizado - Campo nome em branco!"
            }

            if (email == '') {
                erro += "\nCadastro não autorizado - Campo email em branco!"
            }

            if (senha == '') {
                erro += "\nCadastro não autorizado - Campo senha em branco!"
            }

            if (confirmaSenha == '') {
                erro += "\nCadastro não autorizado - Campo confirma senha em branco!"
            }

            if (senha != confirmaSenha) {
                erro += "\nCadastro não autorizado - As senhas são diferentes!"
            }

            if (getIdade(data.value) < 18) {
                erro += "\nCadastro não autorizado - Você não tem mais que 18 anos!"
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
