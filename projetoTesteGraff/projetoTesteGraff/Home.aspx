<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="projetoTesteGraff._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Graff Leilões</h1>
        <p class="lead" id="txtBemVindo" runat="server"></p>
        <%--<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Começar!</h2>
            <p>
                Para começar a dar lances, é necessário estar logado no sistema!
            </p>
             <br /> <br />
            <p>
                <a class="btn btn-default" runat="server" href="~/realizaLogin">Logar &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Dar lances!</h2>
            <p>
                Deseja dar seus lances? <br /> <br /> Clique no botão abaixo!
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/realizaLances">Realizar Lance &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Consultar lances!</h2>
            <p>
                Deseja ficar por dentro dos lances que já foram feitos?  <br /> <br /> Clique no botão abaixo!
            </p>
            <p>
                <a class="btn btn-default" runat="server" href="~/consultaLances">Consultar Lance &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
