<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Carrito_de_compra.aspx.cs" Inherits="Carrito_de_compra" %>

<%@ Register Src="~/UserMenu.ascx" TagPrefix="uc1" TagName="UserMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <section id="cart_items">
        <uc1:UserMenu runat="server" ID="UserMenu" />
		<div class="container">
			<div class="breadcrumbs">
				<ol class="breadcrumb">
				  <li><a href="Index.aspx">Inicio</a></li>
				  <li class="active">Carrito de compra</li>
				</ol>
			</div>
            <asp:Label ID="lblMensajes" runat="server" Text="" ForeColor="Red"></asp:Label>
			<div class="table-responsive cart_info">				
                <asp:GridView runat="server" ID="grdCarrito" AutoGenerateColumns="false" EmptyDataText="Ahora mismo tu carrito está vacio." GridLines="None" Width="100%" CellPadding="5" ShowFooter="true" DataKeyNames="ISBN" OnRowDataBound="grdCarrito_RowDataBound" OnRowCommand="grdCarrito_RowCommand">
                    <HeaderStyle HorizontalAlign="Left" BackColor="DarkOrange" ForeColor="#FFFFFF" />
                    <FooterStyle HorizontalAlign="Right" BackColor="#6C6B66" ForeColor="#FFFFFF" />
                    <AlternatingRowStyle BackColor="#F8F8F8" />
                    <Columns>
 
                        <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                        <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                        <asp:TemplateField HeaderText="Cantidad">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtQuantity" Columns="5" Text='<%# Eval("Cantidad") %>'></asp:TextBox><br />
                                <asp:LinkButton runat="server" ID="btnRemove" Text="Eliminar" CommandName="Remove" CommandArgument='<%# Eval("ISBN") %>' style="font-size:12px;"></asp:LinkButton>
 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PrecioUnidad" HeaderText="Precio" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="PrecioTotal" HeaderText="Total" DataFormatString="{0:C}" />
                    </Columns>
                </asp:GridView>
                <div style="padding: 10px;">
                    <asp:Button ID="btnUpdateCart" runat="server" Text="Actualizar Carta" OnClick="btnUpdateCart_Click" class="btn btn-warning" />
                </div>
                
			</div>
		</div>
	</section> 

	<section id="do_action">
		<div class="container">
			<div class="heading">
				<h3>Que te gustaría hacer a continuación</h3>
				<p></p>
                <asp:Button ID="btnConfirmarPedido" runat="server" Text="Confirmar Pedido" class="btn btn-warning" OnClick="btnConfirmarPedido_Click"/> &nbsp <asp:Button ID="btnSeguirComprando" runat="server" Text="Seguir Comprando" class="btn btn-default" OnClick="btnSeguirComprando_Click"  />
			</div>
			<!--<div class="row">
				<div class="col-sm-6">
					<div class="chose_area">
						<ul class="user_option">
							<li>
								<input type="checkbox">
								<label>Use Coupon Code</label>
							</li>
							<li>
								<input type="checkbox">
								<label>Use Gift Voucher</label>
							</li>
							<li>
								<input type="checkbox">
								<label>Estimate Shipping & Taxes</label>
							</li>
						</ul>
						<ul class="user_info">
							<li class="single_field">
								<label>Country:</label>
								<select>
									<option>United States</option>
									<option>Bangladesh</option>
									<option>UK</option>
									<option>India</option>
									<option>Pakistan</option>
									<option>Ucrane</option>
									<option>Canada</option>
									<option>Dubai</option>
								</select>
								
							</li>
							<li class="single_field">
								<label>Region / State:</label>
								<select>
									<option>Select</option>
									<option>Dhaka</option>
									<option>London</option>
									<option>Dillih</option>
									<option>Lahore</option>
									<option>Alaska</option>
									<option>Canada</option>
									<option>Dubai</option>
								</select>
							
							</li>
							<li class="single_field zip-field">
								<label>Zip Code:</label>
								<input type="text">
							</li>
						</ul>
						<a class="btn btn-default update" href="">Get Quotes</a>
						<a class="btn btn-default check_out" href="">Continue</a>
					</div>
				</div>
				<div class="col-sm-6">
					<div class="total_area">
						<ul>
							<li>Cart Sub Total <span>$59</span></li>
							<li>Eco Tax <span>$2</span></li>
							<li>Shipping Cost <span>Free</span></li>
							<li>Total <span>$61</span></li>
						</ul>
							<a class="btn btn-default update" href="">Update</a>
							<a class="btn btn-default check_out" href="">Check Out</a>
					</div>
				</div>
			</div>-->
		</div>
	</section>
</asp:Content>

