<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserMenu.ascx.cs" Inherits="AdminMenu" %>

        <div class="header-bottom" style="padding-bottom: 0px;" id="UserMenu" runat="server"><!--header-bottom-->
			<div class="container">
				<div class="row">
					<div class="col-sm-11">
						<div class="navbar-header">
							<asp:Button ID="btnSalir" runat="server" Text="Salir de la aplicación" OnClick="btnSalir_Click" class="btn btn-default"/>
						</div>
						

                        <!--<asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" style="font-size: large" class="" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" StaticSubMenuIndent="10px">
                            <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                            <DynamicMenuStyle BackColor="#FFFBD6" />
                            <DynamicSelectedStyle BackColor="#FFCC66" />
                            <Items>
                                <asp:MenuItem Text="Inicio" Value="Inicio"></asp:MenuItem>
                                <asp:MenuItem Text="Productos" Value="Productos">
                                    <asp:MenuItem Text="Mantener productos" Value="Mantener productos"></asp:MenuItem>
                                </asp:MenuItem>
                                <asp:MenuItem Text="Empleados" Value="Empleados"></asp:MenuItem>
                                <asp:MenuItem Text="Ventas" Value="Ventas"></asp:MenuItem>
                            </Items>
                            <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                            <StaticMenuItemStyle HorizontalPadding="8px" VerticalPadding="4px" />
                            <StaticSelectedStyle BackColor="#FFCC66" />
                        </asp:Menu>-->
                    
					</div>
					<div class="col-sm-1">
						<!--<div class="search_box pull-right">
							<input type="text" placeholder="Search"/>
						</div>-->
					</div>
				</div>
			</div>
		</div><!--/header-bottom-->
