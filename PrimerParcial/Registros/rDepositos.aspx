<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rDepositos.aspx.cs" Inherits="PrimerParcial.Registros.rDepositos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <hr>
    <h2 style="color: #000">Registro de Depositos</h2>
    <hr>
    <div class="form-horizontal col-md-12" role="form">
        <div class="form-group row">
            <label class="control-label col-sm-2" for="DepositoidTextBox">Deposito ID:</label>
            <div class="col-sm-1 col-md-4 col-xs6">
                <asp:TextBox type="Number" class="form-control" ID="DepositoidTextBox" Text="0" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-1 col-md-4 col-xs6">
                <button type="button" class="btn btn-info">Buscar</button>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
