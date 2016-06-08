using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PedidosDetalle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void grdPedidos_SelectedIndexChanged(object sender, EventArgs e)
    {
        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
       Server.MapPath("~/App_Data/BookCornerDb.mdf") +
       ";Integrated Security=True;Connect Timeout=30";

        string strPedidoSeleccionado = grdPedidos.SelectedRow.Cells[1].Text;
        string strTotal, StrError;
        decimal DcTotal;

        string StrComandoSql = "SELECT SUM(Precio) AS Total " +
                "FROM LIBRO INNER JOIN LIBROS_DETALLE ON LIBRO.IdLibro = LIBROS_DETALLE.IdLibro " +
                "INNER JOIN PEDIDO ON PEDIDO.IdPedido = LIBROS_DETALLE.IdPedido " +
                "GROUP BY PEDIDO.IdPedido " +
                "HAVING (PEDIDO.IdPedido = '" + strPedidoSeleccionado + "');";

        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);

            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();

            comando.Dispose();
            reader.Close();

            DcTotal = Convert.ToDecimal(comando.ExecuteScalar());

            lblTotal.Text =
                "<div>Importe total del pedido: " +
                string.Format("{0:c}", DcTotal) + "</div>";

            /*if (reader.HasRows)
            {
                
                
                
            }
            else
            {
                lblMensajes.Text = "No existen registros resultantes de la consulta";
            }*/

            string StrComandoSql1 = "SELECT Count(Item) AS Articulos " +
                "FROM LIBROS_DETALLE " +
                "INNER JOIN PEDIDO ON PEDIDO.IdPedido = LIBROS_DETALLE.IdPedido " +
                "GROUP BY PEDIDO.IdPedido " +
                "HAVING (PEDIDO.IdPedido = '" + strPedidoSeleccionado + "');";

            SqlCommand comando1 = new SqlCommand(StrComandoSql1, conexion);
            SqlDataReader reader1 = comando1.ExecuteReader();

            //strTotal = "Nº de artículos: " + reader1.GetValue(0);
            //lblTotal.Text += strTotal;

            reader1.Close();
            comando1.Dispose();
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