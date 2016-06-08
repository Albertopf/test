<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MantenerAutores.aspx.cs" Inherits="MantenerAutores" %>

<%@ Register Src="~/AdminMenu.ascx" TagPrefix="uc1" TagName="AdminMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:AdminMenu runat="server" ID="AdminMenu" />

    <div class="container">
        <h3>Mantener autores</h3>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [AUTOR]"></asp:SqlDataSource>
        <div style="padding: 12px;">
            <div class="row"">
            <div id="grdView" class="col-sm-2">
                <asp:GridView ID="grdAutores" cssClass="table" runat="server" CellPadding="3" DataSourceID="SqlDataSource1" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="IdAutor" PageSize="5" OnSelectedIndexChanged="grdAutores_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                        <asp:BoundField DataField="IdAutor" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="IdAutor" />
                        <asp:BoundField DataField="Autor" HeaderText="Autor" SortExpression="Autor" />
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
            <div class="col-sm-7" style="margin-left: 100px;">
                <div>
                    <div class="form-horizontal">
                    
                    <div class="form-group">
                        <label>Autor</label>
                        <asp:TextBox ID="txtIdAutor" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    
                    <div class="form-group">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" class="btn btn-warning" OnClick="btnNuevo_Click" />
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" class="btn btn-default" Visible="false" OnClick="btnEditar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-danger" Visible="false" OnClick="btnEliminar_Click"/>
                        <asp:Button ID="btnInsertar" runat="server" Text="Insertar" class="btn btn-warning"  Visible="false" OnClick="btnInsertar_Click"/>
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" class="btn btn-warning" Visible="false" OnClick="btnModificar_Click" />
                        <asp:Button ID="btnBorrar" runat="server" Text="Borrar" class="btn btn-danger" Visible="false" OnClick="btnBorrar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-default" Visible="false" OnClick="btnCancelar_Click" />
                    </div>
                

            </div>

        </div>
        <asp:Label ID="lblMensajes" runat="server" Text=""></asp:Label>
            </div>
            
        </div>
        </div>
        
        

    </div>
</asp:Content>

