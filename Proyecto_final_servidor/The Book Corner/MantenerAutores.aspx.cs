using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MantenerAutores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void grdAutores_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMensajes.Text = "";

        //FnDeshabilitarControles();

        string StrIdAutor = grdAutores.SelectedRow.Cells[1].Text;

        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") +
        ";Integrated Security=True;Connect Timeout=30";

        string StrComandoSql = "SELECT Autor FROM AUTOR " +
         "WHERE AUTOR.IdAutor = '" + StrIdAutor + "';";

        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                txtIdAutor.Text = reader.GetString(0);
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
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";

        btnNuevo.Visible = false;
        btnEditar.Visible = false;
        btnEliminar.Visible = false;
        btnInsertar.Visible = true;
        btnModificar.Visible = false;
        btnBorrar.Visible = false;
        btnCancelar.Visible = true;

        txtIdAutor.Text = "";

        grdAutores.SelectedIndex = -1;

        //FnHabilitarControles();

        txtIdAutor.Focus();
    }
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";

        String strIdAutor;

        strIdAutor = txtIdAutor.Text;

        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") + ";Integrated Security=True;Connect Timeout=30";

        string StrComandoSql = "INSERT AUTOR " +
        "(Autor) VALUES (" +
        "'" + strIdAutor + "');";

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
        grdAutores.DataBind();
        grdAutores.SelectedIndex = -1;

        //FnDeshabilitarControles();
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

        txtIdAutor.Text = "";

        grdAutores.SelectedIndex = -1;

        //FnDeshabilitarControles();
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";

        String strIdAutor;
        int idAutor;

        strIdAutor = txtIdAutor.Text;
        idAutor = int.Parse(grdAutores.SelectedRow.Cells[1].Text);

        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") + ";Integrated Security=True;Connect Timeout=30";

        string StrComandoSql = "UPDATE AUTOR " + "SET Autor = '" + strIdAutor +
            "'WHERE IdAutor = '" + idAutor + "';";

        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);

            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);

            comando.Connection.Open();

            Int32 inRegistrosAfectados = comando.ExecuteNonQuery();   //para que sirve el executenonquery

            comando.Connection.Close();

            if (inRegistrosAfectados == 1)
                lblMensajes.Text = "Autor actualizado correctamente";
            else
                lblMensajes.Text = "Error al actualizar el autor";

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

        grdAutores.DataBind();
        grdAutores.SelectedIndex = -1;

        //FnDeshabilitarControles();
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";

        txtIdAutor.Focus();

        btnNuevo.Visible = false;
        btnEditar.Visible = false;
        btnEliminar.Visible = false;
        btnModificar.Visible = true;
        btnCancelar.Visible = true;
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "Vas a borrar el autor seleccionado, se eliminarán también todos sus libros, pulsa el botón borrar para confirmarlo.";

        btnNuevo.Visible = false;
        btnEditar.Visible = false;
        btnEliminar.Visible = false;
        btnCancelar.Visible = true;
        btnBorrar.Visible = true;
    }
    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";

        String strIdAutor;

        strIdAutor = txtIdAutor.Text;

        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") + ";Integrated Security=True;Connect Timeout=30";

        string StrComandoSql = "DELETE FROM AUTOR " + "WHERE Autor = '" + strIdAutor + "';";

        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);

            comando.Connection.Open();

            Int32 inRegistrosAfectados = comando.ExecuteNonQuery();   //para que sirve el executenonquery

            comando.Connection.Close();

            if (inRegistrosAfectados == 1)
                lblMensajes.Text = "Autor eliminado correctamente";
            else
                lblMensajes.Text = "Error al eliminar el autor";

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
        grdAutores.DataBind();
        grdAutores.SelectedIndex = -1;

        txtIdAutor.Text = "";

        //FnDeshabilitarControles();
    }
}