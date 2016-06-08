using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ejemplo3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
          
    }

    protected void btnPoner_Click(object sender, EventArgs e)
    {
        // Se puede hacer referencia a la propiedad Master del objeto Page porque se ha incluido
        // la directiva MasterType al principio de la página que la enlaza con MasterPage2.master
        Label controlIdentificador = (Label)Master.FindControl("lblMPIdentificadorUsuario");
        controlIdentificador.Text = txtUsuario.Text;
        Label controlNombre = (Label)Master.FindControl("lblMPNombreUsuario");
        controlNombre.Text = txtNombre.Text;
    }

    protected void btnCoger_Click(object sender, EventArgs e)
    {
        Label control = (Label)Master.FindControl("lblMPIdentificadorUsuario");
        lblUsuario.Text = control.Text;
        Label controlNombre = (Label)Master.FindControl("lblMPNombreUsuario");
        lblNombre.Text = controlNombre.Text;     
    }

}