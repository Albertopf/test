<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MantenerLibros.aspx.cs" Inherits="MantenerLibros" %>

<%@ Register Src="~/AdminMenu.ascx" TagPrefix="uc1" TagName="AdminMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--<link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/css/datepicker.min.css" />
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/css/datepicker3.min.css" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/js/bootstrap-datepicker.min.js"></script>-->

    <script src="bootstrap-datepicker.es.js" charset="utf-8"></script>
    <script src="bootstrap-datepicker.js" charset="utf-8"></script>
    <script src="js/jquery.js"></script>
    <link href="datepicker.css" type="text/css" rel="stylesheet"/>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:AdminMenu runat="server" ID="AdminMenu" />

    <div class="container">
        <h3>Mantener Libros</h3>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [ISBN], [Titulo], [Autor], [FechaEdicion], [Genero], [NumeroPaginas], [Precio], [Escaparate] FROM [LIBRO], GENERO, AUTOR WHERE LIBRO.GeneroId = GENERO.IdGenero AND LIBRO.AutorId = AUTOR.IdAutor"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [AUTOR]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [GENERO]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Escaparate] FROM [LIBRO]"></asp:SqlDataSource>

        <div style="padding: 12px; background-color: #F0F0E9">
            <asp:GridView ID="grdLibros" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="ISBN" DataSourceID="SqlDataSource1" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" PageSize="5">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" ReadOnly="True" SortExpression="ISBN" />
                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" SortExpression="Titulo" />
                    <asp:BoundField DataField="Autor" HeaderText="Autor" SortExpression="Autor" />
                    <asp:BoundField DataField="FechaEdicion" HeaderText="FechaEdicion" SortExpression="FechaEdicion" />
                    <asp:BoundField DataField="Genero" HeaderText="Genero" SortExpression="Genero" />
                    <asp:BoundField DataField="NumeroPaginas" HeaderText="NumeroPaginas" SortExpression="NumeroPaginas" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                    <asp:CheckBoxField DataField="Escaparate" HeaderText="Escaparate" SortExpression="Escaparate" />
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

            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label>ISBN</label>
                            <asp:TextBox ID="txtIdLibro" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Título</label>
                            <asp:TextBox ID="txtTituloLibro" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Fecha de edición</label>
                            <asp:TextBox ID="txtFecEd" runat="server" class="form-control"></asp:TextBox>
                            <!--<input type="text" class="span2 form-control" data-date-format="dd/mm/yy" runat="server" id="dp2" value=""/>-->
                        </div>
                        <div class="form-group">
                            <label>Autor</label>
                            <asp:DropDownList ID="ddlAutor" runat="server" class="form-control" DataSourceID="SqlDataSource2" DataTextField="Autor" DataValueField="IdAutor"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Genero</label>
                            <asp:DropDownList ID="ddlGenero" runat="server" class="form-control" DataSourceID="SqlDataSource3" DataTextField="Genero" DataValueField="IdGenero"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Numero de páginas</label>
                            <asp:TextBox ID="txtNumpags" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Sinopsis</label>
                            <textarea class="form-control" rows="5" id="comment" runat="server"></textarea>
                        </div>
                        <div class="form-group">
                            <label>Precio</label>
                            <asp:TextBox ID="txtPrecio" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Visible en escaparate</label>
                            <asp:RadioButtonList ID="rblEscaparate" runat="server" class="checkbox" RepeatDirection="Horizontal">
                                <asp:ListItem Value="true">Sí</asp:ListItem>
                                <asp:ListItem Value="false">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="form-group">
                            <label>Imagen</label>
                            <asp:FileUpload ID="FileUpload1" runat="server" class=""/>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" class="btn btn-warning" OnClick="btnNuevo_Click" />
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" class="btn btn-default" visible="false" OnClick="btnEditar_Click"/>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-danger" visible="false" OnClick="btnEliminar_Click" />
                            <asp:Button ID="btnInsertar" runat="server" Text="Insertar" class="btn btn-warning" visible="false" OnClick="btnInsertar_Click" />
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" class="btn btn-warning" visible="false" OnClick="btnModificar_Click" />
                            <asp:Button ID="btnBorrar" runat="server" Text="Borrar" class="btn btn-danger" visible="false" OnClick="btnBorrar_Click" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-default" visible="false" OnClick="btnCancelar_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-md-1"></div>
            </div>
        </div>
        
        <asp:Label ID="lblMensajes" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>

