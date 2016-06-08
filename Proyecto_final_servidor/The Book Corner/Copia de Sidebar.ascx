<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Copia de Sidebar.ascx.cs" Inherits="Sidebar" %>

				<div class="col-sm-3">
					<div class="left-sidebar">
						<h2>Géneros</h2>
						<div class="panel-group category-products" id="divGeneros" runat="server"><!--category-productsr-->
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Genero] FROM [GENERO]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Titulo] FROM [LIBRO], GENERO WHERE GeneroId = IdGenero AND Genero = '((RepeaterItem)Container.Parent.Parent).DataItem'" ></asp:SqlDataSource>
                            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                                <ItemTemplate>
                                    <div class="panel panel-default">
								        <div class="panel-heading">
									        <h4 class="panel-title">
										        <a href="GeneroView.aspx?genero=<%# Eval("Genero") %>">
											        <span class="badge pull-right"><i class="fa fa-plus"></i></span>
											        <%# Eval("Genero") %>
										        </a>
									        </h4>
								        </div>
								        <!--<div id="<%# Eval("Genero")%>" class="panel-collapse collapse">
									        <div class="panel-body">
										        <ul>  
                                                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
                                                    <ItemTemplate>
                                                        <li><%# Eval("Titulo")%></li>
                                                    </ItemTemplate>
                                                </asp:Repeater>											        
										        </ul>
									        </div>
								        </div>-->
							        </div>
                                </ItemTemplate>
                            </asp:Repeater>

							
						</div><!--/category-products-->
					
						<div class="brands_products"><!--brands_products-->
							<h2>Autores</h2>
							<div class="brands-name">
								<ul class="nav nav-pills nav-stacked">
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Autor] FROM [AUTOR]"></asp:SqlDataSource>
                                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource3">
                                    <ItemTemplate>
                                        <li><a href="AutorView.aspx?autor=<%# Eval("Autor") %>"> <%# Eval("Autor") %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
								</ul>
							</div>
						</div><!--/brands_products-->
						
						<!--<div class="price-range">
							<h2>Price Range</h2>
							<div class="well text-center">
								 <input type="text" class="span2" value="" data-slider-min="0" data-slider-max="600" data-slider-step="5" data-slider-value="[250,450]" id="sl2" ><br />
								 <b class="pull-left">$ 0</b> <b class="pull-right">$ 600</b>
							</div>
						</div>
						
						<div class="shipping text-center">
							<img src="images/home/shipping.jpg" alt="" />
						</div>-->
					
					</div>
				</div>
