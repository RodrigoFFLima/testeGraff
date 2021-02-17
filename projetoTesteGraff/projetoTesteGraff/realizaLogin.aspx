<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="realizaLogin.aspx.cs" Inherits="projetoTesteGraff.realizaLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2><%: Title %></h2>
    <div id="quadro" class="col-xs-4 col-xs-offset-4">
        <div class="row">
            <div class="form-group col-md-12">
                <label for="exampleInputEmail1">E-mail: </label>
                <asp:TextBox AutoPostBack="false" runat="server" type="email" class="form-control" id="txtEmailUsuario" placeholder="Digite seu e-mail"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-12">
                <label for="exampleInputEmail1">Senha: </label>
                <asp:TextBox AutoPostBack="false" runat="server" type="password" class="form-control" id="txtSenha" placeholder="Digite sua senha"></asp:TextBox>
            </div>
        </div>
        
        <br />

        <div class="row">
            <div class="form-group col-md-12">
                <label for="exampleInputEmail1">Não tem login? Clique abaixo para criar uma conta! </label>
                <a class="btn btn-default" runat="server" href="~/cadastraUsuario">Cadastrar! &raquo;</a>
            </div>
        </div>
        
        <asp:Literal ID="ltErro" runat="server"></asp:Literal>
        <div id="resultado" style="color: red"></div>
        
        <br />
        <hr />

        <div class="row">
            <div class="col-md-12">
                <asp:Button runat="server" ID="btnLogar" CssClass="btn btn-primary" Text="Logar" OnClientClick="return validaLogin();" OnClick="btnLogar_Click"/>
                <a href="~/Home" class="btn btn-default" runat="server" id="btnCancelar">Cancelar</a>
            </div>
        </div>
    </div>
    
    <script>
        function validaLogin() {
            var erro = '';
            var email = document.getElementById("<%=txtEmailUsuario.ClientID%>").value;
            var senha = document.getElementById("<%=txtSenha.ClientID%>").value;

            if (nome == '') {
                erro += "\nLogin não autorizado - Campo email em branco!"
            }

            if (senha == '') {
                erro += "\nLogin não autorizado - Campo senha em branco!"
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
