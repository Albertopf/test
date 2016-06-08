<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Store</title>
	<link href="Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
		
		<div class="container">
			<h1>My Store</h1>
			
			<div class="products">
				<div>Shoes - <asp:LinkButton runat="server" ID="btnAddShirt" OnClick="btnAddShoes_Click">Add To Cart</asp:LinkButton></div>
				<div>Shirt - <asp:LinkButton runat="server" ID="btnAddShorts" OnClick="btnAddShirt_Click">Add To Cart</asp:LinkButton></div>
				<div>Pants - <asp:LinkButton runat="server" ID="btnAddShoes" OnClick="btnAddPants_Click">Add To Cart</asp:LinkButton></div>
			</div>
			
			<a href="ViewCart.aspx">View Cart</a>
		</div>
		
    </form>
</body>
</html>
