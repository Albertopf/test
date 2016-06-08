<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Ejemplo2.aspx.cs" Inherits="Ejemplo2" %>

<%@ MasterType virtualpath="~/MasterPage2.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" Runat="Server">
    <div>
       <div style="text-align: center">
          EJEMPLO 2 - PAGINA DE CONTENIDO
       </div>
       <br />
       <br />
       <div style="text-align: center">
           Identificador de Usuario <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
           <br />
           Nombre <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
           <br />
           <br />
           <asp:Button ID="btnPoner" runat="server" Text="Poner en Master Page" OnClick="btnPoner_Click" />
       </div>
       <br />
       <br />
       <div style="text-align: center">
           <asp:Button ID="btnCoger" runat="server" Text="Coger de Master Page" OnClick="btnCoger_Click" />
           <br />
           <br />
           Identificador de Usuario <asp:Label ID="lblUsuario" runat="server" BorderStyle="Solid"></asp:Label>
           <br />
           Nombre <asp:Label ID="lblNombre" runat="server" BorderStyle="Solid"></asp:Label>
       </div>
       <br />
   </div>

</asp:Content>

