<%@ Page Title="Consultar Lances" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="consultaLances.aspx.cs" Inherits="projetoTesteGraff.consultaLances" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="top" class="row">
        <div class="col-sm-3">
            <h2><%: Title %> </h2>
        </div>
        <div class="col-sm-6">

            <div class="input-group h2">
                <input name="data[search]" class="form-control" runat="server" id="search" type="text" placeholder="Filtrar usuário">
                <span class="input-group-btn">
                <asp:Button runat="server" ID="btnPesquisar" CssClass="btn btn-primary" Text="Pesquisar" OnClick="btnPesquisar_Click"/>
                </span>
            </div>

        </div>
        <div class="col-sm-3">
            <a runat="server" id="btnNovoProduto" href="~/cadastraProdutos" class="btn btn-primary pull-right h2">Novo Produto</a>
        </div>
    </div>
    <!-- /#top -->


    <hr />
    <div id="list" class="row">

        <div class="table-responsive col-md-12">
            <table class="table table-striped" cellspacing="0" cellpadding="0">
                <thead>
                    <tr>
                        <th>Produto</th>
                        <th>Descrição</th>
                        <th>Usuário</th>
                        <th>Valor último lance</th>
                        <th>Data último lance</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Literal ID="listLances" runat="server"></asp:Literal>
                </tbody>
            </table>
        </div>

    </div>

</asp:Content>
