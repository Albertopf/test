using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DetailsView : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string strTitulo;

        strTitulo = Request.QueryString["titulo"];

        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") +
        ";Integrated Security=True;Connect Timeout=30";

        string StrComandoSql = "SELECT ISBN,Titulo,FechaEdicion,Autor,Genero,NumeroPaginas,Sinopsis,Precio,Escaparate,Imagen FROM LIBRO, " +
         "GENERO, AUTOR WHERE Titulo = '" + strTitulo + "' AND LIBRO.GeneroId = GENERO.IdGenero AND LIBRO.AutorId = AUTOR.IdAutor;";
        
        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                detailTitulo.InnerHtml = strTitulo;
                detailImagen.Src= ".\\images\\" + reader.GetString(9);
                detailId.InnerHtml += reader.GetString(0);
                detailPrecio.Text = String.Format("{0:c}", reader.GetValue(7));
                detailAutor.InnerHtml += reader.GetString(3);
                detailSinopsis.InnerHtml += reader.GetString(6);
            }
            else
            {
                Response.Redirect("~/Error404.aspx");
            }

            reader.Close();
            comando.Dispose();
            conexion.Close();

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
    protected void btnAnyadirLibroCarrito_Click(object sender, EventArgs e)
    {

        int isbn;

        string titulo;  

        decimal precio; 
       

        string strTitulo;

        strTitulo = Request.QueryString["titulo"];

        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") +
        ";Integrated Security=True;Connect Timeout=30";

        string StrComandoSql = "SELECT ISBN, Titulo, Precio FROM LIBRO " +
         "WHERE Titulo = '" + strTitulo + "';";

        /*string StrComandoSql = "INSERT PEDIDO " + "(IdPedido, FecPed, IdEstado) VALUES (" +
            "'" + Idpedido + "','" + fecPedido + "','" + Estado + "'); SELECT CONVERT(int, SCOPE_IDENTITY()) as IdPed;";

        string StrComandoSql1 = "INSERT LIBROS_DETALLE " + "(IdLibro, IdPedido) VALUES (" +
            "'" + Idlibro + "','" + Idpedido + "');";*/

        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);

            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();

            reader.Read();

            isbn = int.Parse(reader.GetString(0));
            titulo = reader.GetString(1);
            precio = Convert.ToDecimal(reader.GetValue(2));

            //Carrito.Instancia.AnyadirItem(isbn, titulo, precio);
            //Carrito.Instance.AnyadirItem(isbn, titulo, precio);

            //Carrito cart = Carrito.GetShoppingCart;
            //cart.AnyadirItem(isbn, titulo, precio);

            Carrito.GetInstance().AnyadirItem(isbn, titulo, precio);

            comando.Connection.Close();

            Response.Redirect("~/Carrito_de_compra.aspx");

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

}