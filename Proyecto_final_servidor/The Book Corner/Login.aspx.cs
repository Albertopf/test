using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") +
        ";Integrated Security=True;Connect Timeout=30";

        string StrComandoSql = "SELECT Login, nombre, rol FROM USUARIO ";

        StrComandoSql = StrComandoSql + " WHERE Login='" + Login1.UserName + "' ";
        StrComandoSql = StrComandoSql + "AND Password='" + Login1.Password + "';";

        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                Session.Add("Nombre", reader.GetString(1));
                Session.Add("Rol", reader.GetString(2));
                e.Authenticated = true;
                reader.Close();
                comando.Dispose();
                conexion.Close();
                if (Convert.ToString(Session["Rol"]) == "A")
                {
                    Response.Redirect("~/AdHome.aspx");
                    
                }

                if (Convert.ToString(Session["Rol"]) == "U")
                {
                    Response.Redirect("~/Index.aspx");
                }

            }
            else
            {
                e.Authenticated = false;
                reader.Close();
                comando.Dispose();
                conexion.Close();
            }
        }
        catch (SqlException ex)
        {
            string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
            StrError = StrError + "<div>Código: " + ex.Number + "</div>";
            StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
            //lblMensajes.Text = StrError;
            return;
        }
        
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {

    }
    protected void btnRegistro_Click(object sender, EventArgs e)
    {
        lblMensajes.Text = "";

        String strNombre, strNomUsuario, strContraseña, strContraseñaConfirm, strRol, strCorreo;

        strNombre = txtnombre.Value;
        strNomUsuario = txtnomUsuario.Value;
        strContraseña = Password1.Value;
        strContraseñaConfirm = Password2.Value;
        strCorreo = txtCorreo.Value;
        strRol = "U";       

        if (strContraseña == strContraseñaConfirm)
        {
            string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
            Server.MapPath("~/App_Data/BookCornerDb.mdf") + ";Integrated Security=True;Connect Timeout=30";

            string StrComandoSql = "INSERT USUARIO " + "(Login, Password, Nombre, Rol, Correo) VALUES (" +
               "'" + strNomUsuario + "','" + strContraseña + "','" + strNombre + "','" + strRol + "','" + strCorreo + "');";

            try
            {
                SqlConnection conexion = new SqlConnection(StrCadenaConexion);
                SqlCommand comando = new SqlCommand(StrComandoSql, conexion);

                comando.Connection.Open();

                Int32 inRegistrosAfectados = comando.ExecuteNonQuery();

                comando.Connection.Close();

                if (inRegistrosAfectados == 1)
                {
                    lblMensajes.Text = "Usuario registrado correctamente";

                }   
                else
                    lblMensajes.Text = "Ha ocurrido un error durante el registro, prueba a registrarte de nuevo.";

            }
            catch (SqlException ex)
            {
                string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
                StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                lblMensajes.Text = StrError;
                return;
            }

            //Response.Redirect("~/VerLibros.aspx");

            //FnDeshabilitarControles();
        }
        else
        {
            lblMensajes.Text = "Error";
        }

       
    }
}