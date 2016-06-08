<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PedidosPorCliente.aspx.cs" Inherits="Pedidos" %>

<%@ Register Src="~/AdminMenu.ascx" TagPrefix="uc1" TagName="AdminMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:AdminMenu runat="server" ID="AdminMenu" />
    <div class="container">
        <h3>Pedidos por cliente</h3>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [IdCliente], [NomCli], [DirCli], [PobCli], [CorCli], [Login] FROM [CLIENTE]"></asp:SqlDataSource>
        <asp:GridView ID="grdClientes" runat="server" CssClass="table" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IdCliente" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" PageSize="5" OnSelectedIndexChanged="grdClientes_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                <asp:BoundField DataField="IdCliente" HeaderText="Id Cliente" ReadOnly="True" SortExpression="IdCliente" />
                <asp:BoundField DataField="NomCli" HeaderText="Nombre" SortExpression="NomCli" />
                <asp:BoundField DataField="DirCli" HeaderText="Dirección" SortExpression="DirCli" />
                <asp:BoundField DataField="PobCli" HeaderText="Población" SortExpression="PobCli" />
                <asp:BoundField DataField="CorCli" HeaderText="Correo" SortExpression="CorCli" />
                <asp:BoundField DataField="Login" HeaderText="Login" SortExpression="Login" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblMensajes" runat="server" Text=""></asp:Label>
    </div>
    <div>
    </div>
</asp:Content>

