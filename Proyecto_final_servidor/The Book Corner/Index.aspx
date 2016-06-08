<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<%@ Register Src="~/Sidebar.ascx" TagPrefix="uc1" TagName="Sidebar" %>
<%@ Register Src="~/Copia de Sidebar.ascx" TagPrefix="uc1" TagName="CopiadeSidebar" %>
<%@ Register Src="~/UserMenu.ascx" TagPrefix="uc1" TagName="UserMenu" %>
<%@ Register Src="~/AdminMenu.ascx" TagPrefix="uc1" TagName="AdminMenu" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
        <uc1:UserMenu runat="server" ID="UserMenu" />
        <uc1:AdminMenu runat="server" ID="AdminMenu" />
		<div class="container" style="padding-top: 20px;">
			<div class="row">
				<uc1:CopiadeSidebar runat="server" ID="CopiadeSidebar" />
				
				<div class="col-sm-9 padding-right">
					<div class="features_items">
						<h2 class="title text-center">Libros recomendados</h2>
                        <div id="divEscaparate" runat="server">
                            
                        </div>											
					</div>
				</div>
			</div>
		</div>
	</section>
</asp:Content>

