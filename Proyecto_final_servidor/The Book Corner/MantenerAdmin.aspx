<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MantenerAdmin.aspx.cs" Inherits="MantenerAdmin" %>

<%@ Register Src="~/AdminMenu.ascx" TagPrefix="uc1" TagName="AdminMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:AdminMenu runat="server" ID="AdminMenu" />

    <div class="container">
        <h3>Mantenimiento de Usuarios</h3>
        <h2><span class="label label-danger" id="lblMensajes" runat="server"></span></h2>
        <div class="row">
            <div class="col-lg-12">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [USUARIO] WHERE ([Rol] = @Rol)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="A" Name="Rol" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
        <asp:GridView ID="grdAdministradores" Class="table" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="Login" DataSourceID="SqlDataSource1" AllowPaging="True" OnSelectedIndexChanged="grdUsuarios_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Login" HeaderText="Login" ReadOnly="True" SortExpression="Login" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Rol" HeaderText="Rol" SortExpression="Rol" />
                <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
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
        </div>
        <div class="row">
            <div class="form-group">
            <asp:Button ID="btnEditar" class="btn btn-default" runat="server" Text="Editar" visible="false"/>
            <asp:Button ID="btnModificar" class="btn btn-default" runat="server" Text="Confirmar cambios" visible="false"/>
            <asp:Button ID="btnCancelar" class="btn btn-default" runat="server" Text="Cancelar" visible="false" OnClick="btnCancelar_Click"/>
        </div>
        </div>
        
        
    </div>

</asp:Content>

