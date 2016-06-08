using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ejemplo2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
          
    }

    protected void btnPoner_Click(object sender, EventArgs e)
    {
        // Se puede hacer referencia a la propiedad Master del objeto Page porque se ha incluido
        // la directiva MasterType al principio de la página que la enlaza con MasterPage2.master
        this.Master.IdentificadorUsuario = txtUsuario.Text;
        this.Master.NombreUsuario = txtNombre.Text;
    }

    protected void btnCoger_Click(object sender, EventArgs e)
    {
        lblUsuario.Text = Master.IdentificadorUsuario;
        lblNombre.Text = Master.NombreUsuario;     
    }

}