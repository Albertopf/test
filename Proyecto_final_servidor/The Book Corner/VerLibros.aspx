<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VerLibros.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/AdminMenu.ascx" TagPrefix="uc1" TagName="AdminMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:AdminMenu runat="server" ID="AdminMenu" />
    <div class="container" style="padding-top: 20px;">
        <h3>Ver Libros</h3>
        <asp:Label ID="lblResultado" runat="server"></asp:Label>
           <br />
           <br />
        <asp:Label ID="lblMensajes" runat="server" ForeColor="Red"></asp:Label>
    </div>
    
</asp:Content>

