<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cDepositos.aspx.cs" Inherits="PrimerParcial.Consultas.cDepositos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-row justify-content-center">
        <%--Filtro--%>
        <div class="form-group col-md-2">
            <asp:Label Text="Filtro" class="text-primary" runat="server" />
            <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>DepositoId</asp:ListItem>
                <asp:ListItem>Fecha</asp:ListItem>
                <asp:ListItem>CuentaId</asp:ListItem>
                <asp:ListItem>Concepto</asp:ListItem>
                <asp:ListItem>Monto</asp:ListItem>
            </asp:DropDownList>
        </div>
        <%--Criterio--%>
        <div class="form-group col-md-4">
            <asp:Label ID="Label1" runat="server" Text="Buscar">Criterio</asp:Label>
            <asp:TextBox ID="CriterioTextBox" class="form-control input-group" runat="server"></asp:TextBox>
        </div>
          <%--Desde--%>
        <div class="form-row justify-content-center">
            <div class="form-group col-md-6">
                <asp:Label Text="Desde" ForeColor="#0000FF" runat="server" />
                <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />
            </div>
             <%--Hasta--%>
            <div class="form-group col-md-6">
                <asp:Label Text="Hasta" ForeColor="#0000FF" runat="server" />
                <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
            </div>
        </div>
        <div class="col-lg-1 p-0">
            <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                <span class="fas fa-search"></span>
                 Buscar
            </asp:LinkButton>
        </div>
    </div>

    <div class="form-row justify-content-center">
        <asp:GridView ID="DepositoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="5" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="SkyBlue" />
            <Columns>
                <asp:BoundField DataField="DepositoId" HeaderText="Deposito Id" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="CuentaId" HeaderText="Cuenta Id" />
                <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                <asp:BoundField DataField="Monto" HeaderText="Monto" />
            </Columns>

        </asp:GridView>

    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
