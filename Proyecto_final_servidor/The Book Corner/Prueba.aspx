<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Prueba.aspx.cs" Inherits="Prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <div class="a" id="asdf" runat="server"></div>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" ItemType="a" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/DetailsView.aspx">LinkButton</asp:LinkButton>
                
            </ItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Titulo] FROM [LIBRO] WHERE ([Escaparate] = @Escaparate)">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="Escaparate" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
