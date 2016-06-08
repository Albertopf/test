using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GeneroView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strGenero;

        strGenero = Request.QueryString["genero"];

        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") +
        ";Integrated Security=True;Connect Timeout=30";

        string StrComandoSql = "SELECT Precio, Titulo, Imagen, Genero from LIBRO, GENERO WHERE IdGenero = GeneroId AND Genero = '" + strGenero + "';";
        string StrComandoSql1 = "SELECT Count(Titulo) AS cantidad from LIBRO, GENERO WHERE IdGenero = GeneroId AND Genero = '" + strGenero + "';";

        string StrError, strLibrosGenero = "";



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
                tituloGeneroView.InnerHtml = reader.GetString(3);

                for (int i = 0; i < librosEscaparate; i++)
                {
                    strLibrosGenero += "<div class='col-sm-4'>";
                    strLibrosGenero += "<div class='product-image-wrapper'>";
                    strLibrosGenero += "<div class='single-products'>";
                    strLibrosGenero += "<div class='productinfo text-center'>";
                    strLibrosGenero += "<img src='.\\images\\" + reader.GetString(2) + "' alt='' width='83' heigth='120'/>";
                    strLibrosGenero += "<h2>" + String.Format("{0:c}", reader.GetValue(0)) + "</h2>";
                    strLibrosGenero += "<p><a href='DetailsView.aspx?id=" + reader.GetString(1) + "'>" + reader.GetString(1) + "</a></p>";
                    strLibrosGenero += "<a href='#' class='btn btn-default add-to-cart'><i class='fa fa-shopping-cart'></i>Add to cart</a>";
                    strLibrosGenero += "</div>";
                    strLibrosGenero += "</div></div></div>";

                    reader.Read();
                }

                divGenero.InnerHtml = strLibrosGenero;

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