using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        linkCuenta.Visible = false;
        linkCarrito.Visible = false;
        linkCaja.Visible = false;

        logoLink.HRef = "Index.aspx";

        if (Convert.ToString(Session["Rol"]) == "U" || Convert.ToString(Session["Rol"]) == "A")
        {
            linkCuenta.Visible = true;
            linkCuenta.InnerHtml = Convert.ToString(Session["Nombre"]);
            linkLogin.Visible = false;
            linkCarrito.Visible = true;
            logoLink.HRef = "Index.aspx";
        }

        if (Convert.ToString(Session["Rol"]) == "A")
        {
            linkCuenta.Visible = true;
            linkCuenta.InnerHtml = Convert.ToString(Session["Nombre"]);
            linkLogin.Visible = false;
            logoLink.HRef = "AdHome.aspx";
        }
    }
}
