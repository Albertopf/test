using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage2 : System.Web.UI.MasterPage
{
    public String IdentificadorUsuario
    {
        get 
        { 
            return (String)ViewState["Identificador"]; 
        }
        set 
        {
            lblMPIdentificadorUsuario.Text = value;
            ViewState["Identificador"] = value;         // El valor de la propiedad se lamacena en el Estado de la Página (ViewState) para
                                                        // conservar su valor en las devoluciones de datos (Post-Backs)
        }
    }

    public String NombreUsuario
    {
        get
        {
            return lblMPNombreUsuario.Text;
        }
        set
        {          
            lblMPNombreUsuario.Text = value;            // El valor del nombre se conserva en el Label
        }
    }

    void Page_Init(Object sender, EventArgs e)
    {
        this.IdentificadorUsuario = "No identificado";
        this.NombreUsuario = " ";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

}
