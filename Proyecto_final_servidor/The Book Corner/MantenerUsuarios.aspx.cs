﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MantenerUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void grdUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnEditar.Visible = false;
        btnModificar.Visible = false;
        btnCancelar.Visible = false;
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        lblMensajes.InnerText = "";

        btnEditar.Visible = false;
        btnModificar.Visible = false;
        btnCancelar.Visible = false;

        grdUsuarios.SelectedIndex = -1;
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {

    }
    
}