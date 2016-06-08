using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Carrito_de_compra : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }

    protected void BindData()
    {

        grdCarrito.DataSource = Carrito.GetInstance().Items;
        grdCarrito.DataBind();
    }
    protected void grdCarrito_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[3].Text = "Total: " + Carrito.GetInstance().CalcularTotal().ToString("C");
        }
    }
    protected void grdCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            int libroId = Convert.ToInt32(e.CommandArgument);
            string titulo = e.CommandArgument.ToString();  //OJOOO
            decimal precio = Convert.ToDecimal(e.CommandArgument);
            Carrito.GetInstance().EliminarItem(libroId, titulo, precio);
        }

        BindData();
    }
    protected void btnUpdateCart_Click(object sender, EventArgs e)
    {
        /*int productId;
        string titulo;
        decimal precio;
        int cantidad;

        foreach (GridViewRow row in grdCarrito.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                try
                {

                    productId = Convert.ToInt32(grdCarrito.DataKeys[row.RowIndex].Value);

                    titulo = grdCarrito.SelectedRow.Cells[2].ToString();

                    precio = Convert.ToDecimal(grdCarrito.SelectedRow.Cells[3]);

                    cantidad = int.Parse(((TextBox)row.Cells[1].FindControl("txtQuantity")).Text);

                    Carrito.GetInstance().SetCantidad(productId, cantidad, titulo, precio);
                }
                catch (FormatException) { }
            }
        }

        BindData();*/
    }
    protected void btnSeguirComprando_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Index.aspx");
    }
    protected void btnConfirmarPedido_Click(object sender, EventArgs e)
    {
        
        foreach (ItemCarrito item in Carrito.GetInstance().Items)
        {
            string id = item.Titulo;
        }

        DateTime FechaActual = DateTime.MinValue;

        int c = 1;

        string StrCadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" +
        Server.MapPath("~/App_Data/BookCornerDb.mdf") +
        ";Integrated Security=True;Connect Timeout=30";

        /*string StrComandoSql = "SELECT ISBN,Titulo,FechaEdicion,Autor,Genero,NumeroPaginas,Sinopsis,Precio,Escaparate,Imagen FROM LIBRO, " +
         "GENERO, AUTOR WHERE Titulo = '" + strTitulo + "' AND LIBRO.GeneroId = GENERO.IdGenero AND LIBRO.AutorId = AUTOR.IdAutor;";*/

        string StrComandoSql = "INSERT PEDIDO " + "( IdEstado) VALUES (" +
            "'" + 1 + "');";

        string StrComandoSql1 = "INSERT LIBROS_DETALLE " + "(IdLibro, IdPedido) VALUES ";

        int tamañoCarro = Carrito.GetInstance().Items.Count;
        for (int j = 0; j < tamañoCarro; j++)
        {
            if (j == tamañoCarro - 1)
            {
                StrComandoSql1 += "(" + "'" + Carrito.GetInstance().LeerItem(j) + "','" + c + "');";
            }
            else
                StrComandoSql1 += "(" + "'" + Carrito.GetInstance().LeerItem(j) + "','" + c + "'), ";
        }

        try
        {
            SqlConnection conexion = new SqlConnection(StrCadenaConexion);
            SqlCommand comando = new SqlCommand(StrComandoSql, conexion);

            comando.Connection.Open();

            Int32 inRegistrosAfectados = comando.ExecuteNonQuery();

            comando.Connection.Close();

            if (inRegistrosAfectados == 1)
            {
                lblMensajes.Text = "Pedido creado correctamente";
                c++;
            }
            else
                lblMensajes.Text = "Error al crear el pedido";

            comando.Dispose();
            conexion.Close();

            SqlConnection conexion1 = new SqlConnection(StrCadenaConexion);
            SqlCommand comando1 = new SqlCommand(StrComandoSql1, conexion1);

            comando.Connection.Open();

            Int32 inRegistrosAfectados2 = comando.ExecuteNonQuery();

            if (inRegistrosAfectados2 != 0)
                lblMensajes.Text = "Pedido creado correctamente";
            else
                lblMensajes.Text = "Error, has creado un pedido sin artículos";

            comando.Connection.Close();

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