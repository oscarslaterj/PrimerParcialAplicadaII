<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rDepositos.aspx.cs" Inherits="PrimerParcial.Registros.rDepositos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <hr>
    <h2 style="color: #000">Registro de Depositos</h2>
    <hr>
    <%--DepositoId--%>
    <div class="form-horizontal col-md-9" role="form">
        <div class="form-group row">
            <label class="control-label col-sm-2" for="DepositoidTextBox">Deposito ID:</label>
            <div class="col-sm-1 col-ms-4 col-xs6">
                <asp:TextBox type="Number" class="form-control" ID="DepositoidTextBox" Text="0" runat="server"></asp:TextBox>
                <<asp:RequiredFieldValidator ID="DepositoidRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="DepositoidTextBox" ValidationGroup="Buscar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="DepositoRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="DepositoidTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
            </div>

            <%--Boton--%>
            <div class="col-sm-1 col-sm-4 col-xs6">
                <asp:Button ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
            </div>
        </div>
    </div>

    <%--Fecha--%>
    <div class="form-group col-sm-1 col-md-4">
        <asp:Label Text="Fecha" runat="server" />
        <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
    </div>

    <%--CuentaId--%>
    <div class="form-row">
        <div class="form-group col-sm-1 col-md-4">
            <asp:Label Text="Cuenta" runat="server" />
            <asp:DropDownList ID="CuentaDropDownList" class="form-control input-sm" runat="server">
                <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <%--Concepto--%>
    <div class="form-group col-md-3">
        <asp:Label Text="Concepto" runat="server" />
        <asp:TextBox ID="ConceptoTextBox" class="form-control input-sm" placeholder="Concepto Deposito" runat="server" />   
        <asp:RegularExpressionValidator ID="CRegularExpressionValidator" runat="server" ErrorMessage="Ingrese algun concepto!" ControlToValidate="ConceptoTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" SetFocusOnError="True"></asp:RegularExpressionValidator>
    </div>

    <div class="form-row">
        <%--Monto--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Monto" runat="server" />
            <asp:TextBox ID="MontoTextBox" TextMode="Number" class="form-control input-sm" placeholder="0" runat="server" />
            <asp:RequiredFieldValidator ID="MontoRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo Numero!" ValidationGroup="guardar" ControlToValidate="MontoTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="MontoRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo Numero!" ControlToValidate="MontoTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <%--Botones--%>
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button Text="Nuevo" class="btn btn-outline-info btn-md" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                <asp:Button Text="Guardar" class="btn btn-outline-success btn-md" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                <asp:Button Text="Eliminar" class="btn btn-outline-danger btn-md" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />
            </div>
        </div>
    </div>

</asp:Content>
