<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AutorView.aspx.cs" Inherits="AutorView" %>

<%@ Register Src="~/Copia de Sidebar.ascx" TagPrefix="uc1" TagName="CopiadeSidebar" %>
<%@ Register Src="~/AdminMenu.ascx" TagPrefix="uc1" TagName="AdminMenu" %>
<%@ Register Src="~/UserMenu.ascx" TagPrefix="uc1" TagName="UserMenu" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <section>
        <uc1:AdminMenu runat="server" ID="AdminMenu" />
        <uc1:UserMenu runat="server" ID="UserMenu" />
		<div class="container" style="padding-top: 20px;">
			<div class="row">
				<uc1:CopiadeSidebar runat="server" ID="CopiadeSidebar" />
				<div class="col-sm-9 padding-right">
					<div class="features_items">
						<h2 class="title text-center" id="tituloAutor" runat="server"></h2>
                        <div id="divAutores" runat="server">
                            
                        </div>
					</div>			
				</div>
			</div>
		</div>
	</section>
</asp:Content>

