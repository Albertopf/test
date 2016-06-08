<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdHome.aspx.cs" Inherits="AdHome" %>

<%@ Register Src="~/AdminMenu.ascx" TagPrefix="uc1" TagName="AdminMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:AdminMenu runat="server" ID="AdminMenu" />

    <div class="container">
        <div style="padding: 30px;">
           <h3>Bienvenido al menú de administración.</h3>
        <p>Desde aquí podrás gestionar los distintos departamentos de la aplicación.</p>
        <div>
            <asp:Button ID="btnSalirApp" runat="server" Text="Salir de la aplicación" class="btn btn-default" OnClick="btnSalirApp_Click"/>
        </div>
        </div>
        
    </div>

</asp:Content>

