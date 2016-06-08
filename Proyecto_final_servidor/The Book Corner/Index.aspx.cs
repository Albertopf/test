using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") +
        ";Integrated Security=True;Connect Timeout=30";

        string StrComandoSql = "SELECT Precio, Titulo, Imagen from LIBRO WHERE Escaparate = 'true';";
        string StrComandoSql1 = "SELECT Count(Titulo) AS cantidad from LIBRO WHERE Escaparate = 'true';";

        string StrError, strEscaparate = "";

        

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

                for (int i = 0; i < librosEscaparate; i++)
                {
                    strEscaparate += "<div class='col-sm-4'>";
                    strEscaparate += "<div class='product-image-wrapper'>";
                    strEscaparate += "<div class='single-products'>";
                    strEscaparate += "<div class='productinfo text-center'>";
                    strEscaparate += "<img src='.\\images\\" + reader.GetString(2) + "' alt='' width='83' heigth='120'/>";
                    strEscaparate += "<h2>" + String.Format("{0:c}", reader.GetValue(0)) + "</h2>";
                    strEscaparate += "<p><a href='DetailsView.aspx?id=" + reader.GetString(1) + "'>" + reader.GetString(1) + "</a></p>";
                    strEscaparate += "<a class='btn btn-default add-to-cart'><i class='fa fa-shopping-cart'></i>Add to cart</a>";
                    strEscaparate += "</div>";
                    strEscaparate += "<div class='product-overlay'>";
                    strEscaparate += "<div class='overlay-content'>";
                    strEscaparate += "<h2>" + String.Format("{0:c}", reader.GetValue(0)) + "</h2>";
                    strEscaparate += "<p><a href='DetailsView.aspx?titulo=" + reader.GetString(1) + "'>" + reader.GetString(1) + "</a></p>";
                    strEscaparate += "<a href='' class='btn btn-default add-to-cart'><i class='fa fa-shopping-cart'></i>Add to cart</a>";
                    strEscaparate += "</div></div></div></div></div>";

                    reader.Read();
                }

                divEscaparate.InnerHtml = strEscaparate;        

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