<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PedidosDetalle.aspx.cs" Inherits="PedidosDetalle" %>

<%@ Register Src="~/AdminMenu.ascx" TagPrefix="uc1" TagName="AdminMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:AdminMenu runat="server" ID="AdminMenu" />


    <div class="container">
        <h3>Pedidos (Detalle)</h3>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT PEDIDO.IdPedido, PEDIDO.FecPed, PEDIDO.IdCliente, ESTADO.Estado, CLIENTE.NomCli FROM PEDIDO INNER JOIN CLIENTE ON PEDIDO.IdCliente = CLIENTE.IdCliente INNER JOIN ESTADO ON PEDIDO.IdEstado = 
ESTADO.IdEstado"></asp:SqlDataSource>
        <div class="row">
            <div class="col-md-7">
                <asp:GridView ID="grdPedidos" runat="server" AutoGenerateColumns="False" DataKeyNames="IdPedido" DataSourceID="SqlDataSource1" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="grdPedidos_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                <asp:BoundField DataField="IdPedido" HeaderText="IdPedido" ReadOnly="True" SortExpression="IdPedido" />
                <asp:BoundField DataField="FecPed" HeaderText="FecPed" SortExpression="FecPed" DataFormatString="{0:d}" />
                <asp:BoundField DataField="IdCliente" HeaderText="IdCliente" SortExpression="IdCliente" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                <asp:BoundField DataField="NomCli" HeaderText="NomCli" SortExpression="NomCli" />
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
            </div>
            <div class="col-md-5">
                <asp:GridView ID="grdLibrosDetalle" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                <asp:BoundField DataField="IdLibro" HeaderText="IdLibro" SortExpression="IdLibro" />
                <asp:BoundField DataField="Titulo" HeaderText="Titulo" SortExpression="Titulo" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ReadOnly="True" SortExpression="Cantidad" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" ReadOnly="True" SortExpression="Precio" />
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
                <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
            </div>
        </div>
        
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Item, LIBROS_DETALLE.IdLibro,  LIBRO.Titulo, COUNT (LIBROS_DETALLE.IdLibro) AS Cantidad, SUM (Precio) AS Precio FROM LIBROS_DETALLE, LIBRO WHERE LIBRO.IdLibro = LIBROS_DETALLE.IdLibro AND [IdPedido] = @IdPedido GROUP BY LIBROS_DETALLE.IdLibro, LIBRO.Titulo, Item;">
            <SelectParameters>
                <asp:ControlParameter ControlID="grdPedidos" Name="IdPedido" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        
    </div>
    
    <asp:Label ID="lblMensajes" runat="server" Text=""></asp:Label>
</asp:Content>

