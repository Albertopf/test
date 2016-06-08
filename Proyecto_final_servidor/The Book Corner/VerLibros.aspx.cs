using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int InNumeroFilas;
        string StrResultado, StrError;
        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") +
        ";Integrated Security=True;Connect Timeout=30";
        //string StrComandoSql = "SELECT * FROM LIBRO;";
        //string StrComandoSql = "SELECT IdProducto,DesPro,PrePro,IdUnidad,DesTip “ +
        // FROM PRODUCTO,TIPO WHERE PRODUCTO.IdTipo = TIPO.IdTipo;";
        string StrComandoSql = "SELECT IdLibro,Titulo,FechaEdicion,AutorId,GeneroId,NumeroPaginas,Precio,Escaparate FROM LIBRO " +
        "INNER JOIN AUTOR ON LIBRO.AutorId = AUTOR.IdAutor;";
        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                StrResultado = "<div style='display:table; border-style:solid;border-color:DarkOrange'>";
                StrResultado += "<div style='display:table-row; background:DarkOrange;color:white'>";
                StrResultado += "<div style='display:table-cell; font-weight:bold'>Código</div>";
                StrResultado += "<div style='display:table-cell; font-weight:bold'>Título</div>";
                StrResultado += "<div style='display:table-cell; font-weight:bold'>Fecha de edición</div>";
                StrResultado += "<div style='display:table-cell; font-weight:bold'>Autor</div>";
                StrResultado += "<div style='display:table-cell; font-weight:bold'>Género</div>";
                StrResultado += "<div style='display:table-cell; font-weight:bold'>Num. de páginas</div>";
                StrResultado += "<div style='display:table-cell; font-weight:bold'>Precio</div>";
                StrResultado += "<div style='display:table-cell; font-weight:bold'>Disponible en escaparate</div>";
                StrResultado += "</div>";
                InNumeroFilas = 0;
                while (reader.Read())
                {
                    StrResultado += "<div style='display:table-row'>";
                    StrResultado += "<div style='display:table-cell'>" + reader.GetString(0) + "&nbsp</div>";
                    StrResultado += "<div style='display:table-cell'>" + reader.GetString(1) + "</div>";
                    StrResultado += "<div style='display:table-cell; text-align: right'>"
                    + string.Format("{0:d}", reader.GetValue(2)) + "&nbsp; &nbsp; </div>";
                    StrResultado += "<div style='display:table-cell'>" + reader.GetString(3) + "</div>";
                    StrResultado += "<div style='display:table-cell'>" + reader.GetString(4) + "</div>";
                    StrResultado += "<div style='display:table-cell'>" + reader.GetInt32(5) + "&nbsp</div>";
                    StrResultado += "<div style='display:table-cell'>" + reader.GetValue(6) + "</div>";
                    StrResultado += "<div style='display:table-cell'>" + reader.GetValue(7) + "</div>";
                    StrResultado += "</div>";
                    InNumeroFilas++;
                }
                StrResultado += "</div>";
                StrResultado += "<p> Número de Filas: " + InNumeroFilas + "</p>";
                lblResultado.Text = StrResultado;
            }
            else
            {
                lblMensajes.Text = "No existen registros resultantes de la consulta";
            }
            reader.Close();
            comando.Dispose();
            conexion.Close();
        }
        catch (SqlException ex)
        {
            StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
            StrError = StrError + "<div>Código: " + ex.Number + "</div>";
            StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
            lblMensajes.Text = StrError;
            return;
        }
    }
}