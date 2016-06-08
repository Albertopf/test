using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MantenerLibros : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMensajes.Text = "";

        //FnDeshabilitarControles();

        string StrIdLibro = grdLibros.SelectedRow.Cells[1].Text;

        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") +
        ";Integrated Security=True;Connect Timeout=30";

        string StrComandoSql = "SELECT ISBN,Titulo,FechaEdicion,Autor,Genero,NumeroPaginas,Sinopsis,Precio,Escaparate FROM LIBRO, " +
         "GENERO, AUTOR WHERE LIBRO.ISBN = '" + StrIdLibro + "' AND LIBRO.GeneroId = GENERO.IdGenero AND LIBRO.AutorId = AUTOR.IdAutor;";  

        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                txtIdLibro.Text = reader.GetString(0);
                txtTituloLibro.Text = reader.GetString(1);
                txtFecEd.Text = string.Format("{0:d}", reader.GetValue(2));
                //ddlAutor.SelectedItem.Selected = false;
                //ddlAutor.SelectedItem.Text = reader.GetString(3);  
                ddlAutor.SelectedValue = ddlAutor.Items.FindByText(reader.GetString(3)).Value;
                //ddlGenero.SelectedItem.Selected = false;
                //ddlGenero.SelectedItem.Text = reader.GetString(4);
                ddlGenero.SelectedValue = ddlGenero.Items.FindByText(reader.GetString(4)).Value;
                txtNumpags.Text = reader.GetInt32(5).ToString();
                txtPrecio.Text = string.Format("{0:F2}", reader.GetValue(7));
                //rblEscaparate.SelectedValue = reader.GetValue(8).ToString();
                rblEscaparate.SelectedIndex = FnSeleccionRadiobutton(reader.GetValue(8).ToString());
                comment.InnerText = reader.GetString(6);
            }
            else
            {
                lblMensajes.Text = "No existen registros resultantes de la consulta";
            }

            reader.Close();
            comando.Dispose();
            conexion.Close();

            btnNuevo.Visible = true;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            btnInsertar.Visible = false;
            btnModificar.Visible = false; 
            btnBorrar.Visible = false;
            btnCancelar.Visible = false;
        }
        catch (SqlException ex)
        {
            string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
            StrError = StrError + "<div>Código: " + ex.Number + "</div>";
            StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
            lblMensajes.Text = StrError;
            return;
        }
    }

    //TODO: Ver como habilitar y deshabilitar los textbox de bootstrap
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        DateTime FecActual = DateTime.UtcNow.Date;

        lblMensajes.Text = "";

        btnNuevo.Visible = false;
        btnEditar.Visible = false;
        btnEliminar.Visible = false;
        btnInsertar.Visible = true;
        btnModificar.Visible = false;
        btnBorrar.Visible = false;
        btnCancelar.Visible = true;

        txtIdLibro.Text = "";
        txtFecEd.Text = FecActual.ToShortDateString();
        txtTituloLibro.Text = "";
        txtPrecio.Text = Convert.ToString(0);
        txtNumpags.Text = Convert.ToString(0);

        ddlAutor.DataBind();  //Ver si esto es necesario.
        ddlGenero.DataBind();

        rblEscaparate.DataBind(); //OJO!
        rblEscaparate.SelectedIndex = -1;
        comment.InnerText = "";

        grdLibros.SelectedIndex = -1;

        //FnHabilitarControles();

        txtIdLibro.Focus();
    }
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";

        String strIdLibro, strTitulo, srtSinopsis, srtImagen;
        Decimal dcPrecio;
        DateTime dtFecEd;
        Int32 Numpags, idGenero, idAutor;
        bool Escaparate;


        strIdLibro = txtIdLibro.Text;
        strTitulo = txtTituloLibro.Text;
        dcPrecio = Convert.ToDecimal(txtPrecio.Text);
        dtFecEd = DateTime.Parse(txtFecEd.Text); //Porqué al intentar introducir un nuevo campo con la fecha por defecto me sale error?
        idAutor = int.Parse(ddlAutor.SelectedValue);
        idGenero = int.Parse(ddlGenero.SelectedValue);
        Numpags = Convert.ToInt32(txtNumpags.Text);
        srtSinopsis = comment.InnerText;
        Escaparate = FnEscaparateConversion(rblEscaparate.SelectedValue);
        srtImagen = FileUpload1.FileName;
        if (srtImagen != "")
            FileUpload1.SaveAs(Server.MapPath("~/images/" + FileUpload1.FileName));
        

        //Al borrar un campo con foto la foto no se borra OJO!


        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") + ";Integrated Security=True;Connect Timeout=30";

        string StrComandoSql = "INSERT LIBRO " +
        "(ISBN,Titulo,FechaEdicion,AutorId,GeneroId,NumeroPaginas,Sinopsis,Precio,Escaparate,Imagen) VALUES (" +
        "'" + strIdLibro + "','" + strTitulo +
        "','" + dtFecEd + "','" + idAutor + "','" + idGenero + "','" + Numpags + "','" + srtSinopsis +
        "','" + FnComaPorPunto(dcPrecio) +
        "','" + Escaparate + "','" + srtImagen + "');";

        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);

            comando.Connection.Open();

            Int32 inRegistrosAfectados = comando.ExecuteNonQuery();

            comando.Connection.Close();

            if (inRegistrosAfectados == 1)
                lblMensajes.Text = "Registro insertado correctamente";
            else
                lblMensajes.Text = "Error al insertar el registro";

            btnNuevo.Visible = true;  //Encapsular función desactivar botones
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = false;
            btnModificar.Visible = false;
            btnBorrar.Visible = false;
            btnCancelar.Visible = false;
        }
        catch (SqlException ex)
        {
            string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
            StrError = StrError + "<div>Código: " + ex.Number + "</div>";
            StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
            lblMensajes.Text = StrError;
            return;
        }

        grdLibros.DataBind();
        grdLibros.SelectedIndex = -1;

        //FnDeshabilitarControles();
    }

    protected string FnComaPorPunto(decimal Numero)
    {
        string StrNumero = Convert.ToString(Numero);
        string stNumeroConPunto = String.Format("{0}", StrNumero.Replace(',', '.'));
        return (stNumeroConPunto);
    }

    protected bool FnEscaparateConversion(string cadena)
    {
        bool res = false; //OJO!

        if (cadena == "true")
            res = true;
        if (cadena == "false")
            res = false;

        return res;
    }

    protected int FnSeleccionRadiobutton(string valor)
    {
        int n = -1;

        if (valor == "True")
        {
            n = 0;
        }
        if (valor == "False")
        {
            n = 1;
        }

        return n;
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";

        btnNuevo.Visible = true;
        btnEditar.Visible = false;
        btnEliminar.Visible = false;
        btnInsertar.Visible = false;
        btnModificar.Visible = false;
        btnBorrar.Visible = false;
        btnCancelar.Visible = false;

        ClearForm();

        grdLibros.SelectedIndex = -1;

        //FnDeshabilitarControles();
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";

        String strIdLibro, strTitulo, srtSinopsis;
        Decimal dcPrecio;
        DateTime dtFecEd;
        Int32 Numpags, idGenero, idAutor;
        bool Escaparate;

        strIdLibro = txtIdLibro.Text;
        strTitulo = txtTituloLibro.Text;
        dcPrecio = Convert.ToDecimal(txtPrecio.Text);
        dtFecEd = DateTime.Parse(txtFecEd.Text); //Porqué al intentar introducir un nuevo campo con la fecha por defecto me sale error?
        idAutor = int.Parse(ddlAutor.SelectedValue);
        idGenero = int.Parse(ddlGenero.SelectedValue);
        Numpags = Convert.ToInt32(txtNumpags.Text);
        srtSinopsis = comment.InnerText;
        Escaparate = FnEscaparateConversion(rblEscaparate.SelectedValue);

        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") + ";Integrated Security=True;Connect Timeout=30";

        string StrComandoSql = "UPDATE LIBRO " + "SET ISBN = '" + strIdLibro + "', Titulo = '"
            + strTitulo + "', FechaEdicion = '" + dtFecEd + "', AutorId = '" + idAutor +
            "', GeneroId = '" + idGenero + "', NumeroPaginas = '" + Numpags +
            "', Sinopsis = '" + srtSinopsis + "', Precio = '" + dcPrecio + "', Escaparate = '" + Escaparate + "' WHERE ISBN = '" + txtIdLibro.Text + "';";

        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);

            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);

            comando.Connection.Open();

            Int32 inRegistrosAfectados = comando.ExecuteNonQuery();   //para que sirve el executenonquery

            comando.Connection.Close();

            if (inRegistrosAfectados == 1)
                lblMensajes.Text = "Registro actualizado correctamente";
            else
                lblMensajes.Text = "Error al actualizar el registro";

            btnNuevo.Visible = true;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = false;
            btnModificar.Visible = false;
            btnBorrar.Visible = false;
            btnCancelar.Visible = false;
        }
        catch (SqlException ex)
        {
            string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
            StrError = StrError + "<div>Código: " + ex.Number + "</div>";
            StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
            lblMensajes.Text = StrError;
            return;
        }

        grdLibros.DataBind();
        grdLibros.SelectedIndex = -1;

        //FnDeshabilitarControles();
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "Vas a borrar el producto seleccionado, pulsa el botón borrar para confirmarlo.";

        btnNuevo.Visible = false;
        btnEditar.Visible = false;
        btnEliminar.Visible = false;
        btnCancelar.Visible = true;
        btnBorrar.Visible = true;
    }

    //Encapsular la función reiniciar formulario
    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";

        String strIdLibro;

        strIdLibro = txtIdLibro.Text;

        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") + ";Integrated Security=True;Connect Timeout=30";

        string StrComandoSql = "DELETE FROM LIBRO " + "WHERE ISBN = '" + strIdLibro + "';";  //No me funciona el comando sql

        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);

            comando.Connection.Open();

            Int32 inRegistrosAfectados = comando.ExecuteNonQuery();   //para que sirve el executenonquery

            comando.Connection.Close();

            if (inRegistrosAfectados == 1)
                lblMensajes.Text = "Registro eliminado correctamente";
            else
                lblMensajes.Text = "Error al eliminar el registro";

            btnNuevo.Visible = true;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = false;
            btnModificar.Visible = false;
            btnBorrar.Visible = false;
            btnCancelar.Visible = false;
        }
        catch (SqlException ex)
        {
            string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
            StrError = StrError + "<div>Código: " + ex.Number + "</div>";
            StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
            lblMensajes.Text = StrError;
            return;
        }
        grdLibros.DataBind();
        grdLibros.SelectedIndex = -1;

        ClearForm();

        //FnDeshabilitarControles();
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";

        btnNuevo.Visible = false;
        btnEditar.Visible = false;
        btnEliminar.Visible = false;
        btnModificar.Visible = true;
        btnCancelar.Visible = true;
    }
    protected void ClearForm()
    {
        txtIdLibro.Text = "";
        txtTituloLibro.Text = "";
        txtFecEd.Text = "";
        txtNumpags.Text = Convert.ToString(0);
        txtPrecio.Text = Convert.ToString(0);

        ddlAutor.DataBind();
        ddlGenero.DataBind();

        rblEscaparate.DataBind(); //OJO!
        rblEscaparate.SelectedIndex = -1;

        comment.InnerText = "";
    }
}