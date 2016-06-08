using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sidebar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string StrError, strGeneros = "", genero = "", autor = "";

        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") +
        ";Integrated Security=True;Connect Timeout=30";

        string StrComandoSqlGenero = "SELECT Genero from GENERO;";
        string StrComandoSqlAutor = "SELECT Autor from AUTOR;";

        string StrComandoSqlnAutores = "SELECT Count(Autor) AS cantidad from AUTOR;";
        string StrComandoSqlnGeneros = "SELECT Count(Genero) AS cantidad from GENERO;";

        string StrComandoSqllibrosGenero = "SELECT titulo from LIBRO, GENERO WHERE genero = '" + genero +
            "' AND LIBRO.GeneroId = GENERO.IdGenero";
        string StrComandoSqlnumlibrosGenero = "SELECT count (titulo) from LIBRO, GENERO WHERE genero = '" + genero +
            "' AND LIBRO.GeneroId = GENERO.IdGenero";

        string StrComandoSqllibrosAutor = "SELECT titulo from LIBRO, Autor WHERE Autor = '" + autor +
            "' AND LIBRO.AutorId = Autor.IdAutor";
        string StrComandoSqlnumlibrosAutor = "SELECT count (titulo) from LIBRO, Autor WHERE Autor = '" + autor +
            "' AND LIBRO.AutorId = Autor.IdAutor"; 
        /*
        try
        {
            SqlConnection conexionGeneros = new SqlConnection(StrCadenaConexion);
            SqlConnection conexionnumGeneros = new SqlConnection(StrCadenaConexion);
            SqlConnection conexionnumLibrosGenero = new SqlConnection(StrCadenaConexion);
            SqlConnection conexionlibrosGenero = new SqlConnection(StrCadenaConexion);

            SqlCommand comandoGeneros = new SqlCommand(StrComandoSqlGenero, conexionGeneros);
            SqlCommand comandonumGeneros = new SqlCommand(StrComandoSqlnGeneros, conexionnumGeneros);
            SqlCommand comandoLibrosGenero = new SqlCommand(StrComandoSqllibrosGenero, conexionlibrosGenero);
            SqlCommand comandonumLibrosGenero = new SqlCommand(StrComandoSqlnumlibrosGenero, conexionnumLibrosGenero);

            conexionGeneros.Open();
            conexionnumGeneros.Open();
            conexionlibrosGenero.Open();
            conexionnumLibrosGenero.Open();

            SqlDataReader readerGeneros = comandoGeneros.ExecuteReader();
            SqlDataReader readernumGeneros = comandonumGeneros.ExecuteReader();

            readerGeneros.Read();
            readernumGeneros.Read();
            

            //int nlibros = comando1.ExecuteNonQuery();
            int nGeneros = readernumGeneros.GetInt32(0);
            

            if (readerGeneros.HasRows)
            {

                for (int i = 0; i < nGeneros; i++)
                {
                   strGeneros += "<div class='panel panel-default'>";
				   strGeneros += "<div class='panel-heading'>";
				   strGeneros += "<h4 class='panel-title'>";
				   strGeneros += "<a data-toggle='collapse' data-parent='#divGeneros' href='#generos'>";
				   strGeneros += "<span class='badge pull-right'><i class='fa fa-plus'></i></span>";
			       strGeneros += readerGeneros.GetString(0) +"</a></h4></div>";
				   strGeneros += "<div id='generos' class='panel-collapse collapse'><div class='panel-body'>";
                   strGeneros += "<ul>";

                   genero = readerGeneros.GetString(0);

                   comandoGeneros.Dispose();
                   comandonumGeneros.Dispose();
                   readernumGeneros.Close();
                   readerGeneros.Close();
                   conexionGeneros.Close();
                   conexionnumGeneros.Close();

                   SqlDataReader readerLibrosGenero = comandoLibrosGenero.ExecuteReader();
                   SqlDataReader readernumLibrosGenero = comandonumLibrosGenero.ExecuteReader();

                   readernumLibrosGenero.Read();

                   int nLibrosGenero = readernumLibrosGenero.GetInt32(0);

                    if (nLibrosGenero > 0)
                    {                                       

                        readerLibrosGenero.Read();
                        
                        for (int j = 0; j < nLibrosGenero; j++)
                        {
                            strGeneros += "	<li><a href='DetailsView.aspx?titulo=" + readerLibrosGenero.GetString(0) + "'>" + readerLibrosGenero.GetString(0) + "</a></li>";

                            readerLibrosGenero.Read();
                        }

                        strGeneros += "</ul>";

                    }

                    strGeneros += "</div></div></div>";

                    conexionGeneros = new SqlConnection(StrCadenaConexion);
                    conexionGeneros.Open();

                    comandoGeneros = new SqlCommand(StrComandoSqlGenero, conexionGeneros);
                    comandoGeneros.ExecuteReader();
                    readerGeneros.Read();
                }

                divGeneros.InnerHtml = strGeneros;

            }
      
            
            

        }
        catch (SqlException ex)
        {
            StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
            StrError = StrError + "<div>Código: " + ex.Number + "</div>";
            StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
            //lblMensajes.Text = StrError;
            return;
        } */
    }
}