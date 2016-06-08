<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminMenu.ascx.cs" Inherits="AdminMenu" %>

        <div class="header-bottom" style="padding-bottom: 0px;" id="MenuAdmin" runat="server">
			<div class="container">
				<div class="row">
					<div class="col-sm-9">
						<div class="navbar-header">
							<button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
								<span class="sr-only">Toggle navigation</span>
								<span class="icon-bar"></span>
								<span class="icon-bar"></span>
								<span class="icon-bar"></span>
							</button>
						</div>
						<div class="mainmenu pull-left">
							<ul class="nav navbar-nav collapse navbar-collapse">
								<li><a href="adHome.aspx">Inicio</a></li>
								<li class="dropdown"><a href="#">Tienda<i class="fa fa-angle-down"></i></a>
                                    <ul role="menu" class="sub-menu">
                                        <li><a href="MantenerLibros.aspx">Libros</a></li>
										<li><a href="MantenerGeneros.aspx">Géneros</a></li> 
										<li><a href="MantenerAutores.aspx">Autores</a></li> 
                                    </ul>
                                </li> 
								<li class="dropdown"><a href="#">Ventas<i class="fa fa-angle-down"></i></a>
                                    <ul role="menu" class="sub-menu">
                                        <li><a href="PedidosDetalle.aspx">Pedidos</a></li>
										<li><a href="PedidosPorCliente.aspx">Pedidos por cliente</a></li>
                                    </ul>
                                </li> 
								<li class="dropdown"><a href="#">Usuario<i class="fa fa-angle-down"></i></a>
                                    <ul role="menu" class="sub-menu">
                                        <li><a href="MantenerUsuarios.aspx">Usuarios</a></li>
										<li><a href="MantenerAdmin.aspx">Administradores</a></li>
                                    </ul>
								</li>
                                <li><a href="Index.aspx">Front-end</a></li>
							</ul>
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
					<div class="col-sm-3">
						<!--<div class="search_box pull-right">
							<input type="text" placeholder="Search"/>
						</div>-->
					</div>
				</div>
			</div>
		</div><!--/header-bottom-->
