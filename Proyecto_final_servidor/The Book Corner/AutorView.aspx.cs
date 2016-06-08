using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AutorView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strAutor;

        strAutor = Request.QueryString["autor"];

        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") +
        ";Integrated Security=True;Connect Timeout=30";

        string StrComandoSql = "SELECT Precio, Titulo, Imagen, Autor from LIBRO, AUTOR WHERE IdAutor = AutorId AND Autor = '" + strAutor + "';";
        string StrComandoSql1 = "SELECT Count(Titulo) AS cantidad from LIBRO, Autor WHERE IdAutor = AutorId AND Autor = '" + strAutor + "';";

        string StrError, strLibrosAutor = "";



        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlConnection conexion1 = new SqlConnection(StrCadenaConexion);

            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
            SqlCommand comando1 = new SqlCommand(StrComandoSql1, conexion1);

            conexion.Open();
            conexion1.Open();

            SqlDataReader reader = comando.ExecuteReader();
            SqlDataReader reader1 = comando1.ExecuteReader();

            reader.Read();
            reader1.Read();

            

            //int nlibros = comando1.ExecuteNonQuery();
            int librosEscaparate = reader1.GetInt32(0);

            if (reader.HasRows)
            {
                tituloAutor.InnerHtml = reader.GetString(3);

                for (int i = 0; i < librosEscaparate; i++)
                {
                    strLibrosAutor += "<div class='col-sm-4'>";
                    strLibrosAutor += "<div class='product-image-wrapper'>";
                    strLibrosAutor += "<div class='single-products'>";
                    strLibrosAutor += "<div class='productinfo text-center'>";
                    strLibrosAutor += "<img src='.\\images\\" + reader.GetString(2) + "' alt='' width='83' heigth='120'/>";
                    strLibrosAutor += "<h2>" + String.Format("{0:c}", reader.GetValue(0)) + "</h2>";
                    strLibrosAutor += "<p><a href='DetailsView.aspx?id=" + reader.GetString(1) + "'>" + reader.GetString(1) + "</a></p>";
                    strLibrosAutor += "<a href='#' class='btn btn-default add-to-cart'><i class='fa fa-shopping-cart'></i>Add to cart</a>";
                    strLibrosAutor += "</div>";
                    strLibrosAutor += "</div></div></div>";

                    reader.Read();
                }

                divAutores.InnerHtml = strLibrosAutor;

            }
            else
            {
                Response.Redirect("~/Error404.aspx");
            }



            comando.Dispose();
            comando1.Dispose();
            reader1.Close();
            reader.Close();

        }
        catch (SqlException ex)
        {
            StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
            StrError = StrError + "<div>Código: " + ex.Number + "</div>";
            StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
            //lblMensajes.Text = StrError;
            return;
        }
    }
}