using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Carrito
/// </summary>
public class Carrito
{

    public static Carrito GetInstance()
    {
        Carrito cart = (Carrito)HttpContext.Current.Session["ASPNETShoppingCart"];

        if (cart == null)
        {
            HttpContext.Current.Session["ASPNETShoppingCart"] = cart = new Carrito();
        }

        return cart;
    }

    protected Carrito()
    {
        Items = new List<ItemCarrito>();
    }

    /*public static Carrito Instance
    {

        get
        {

            if (HttpContext.Current.Session["ASPNETShoppingCart"] == null)
            {

                // we are creating a local variable and thus

                // not interfering with other users sessions

                Carrito instance = new Carrito();

                instance.Items = new List<ItemCarrito>();

                HttpContext.Current.Session["ASPNETShoppingCart"] = instance;

                return instance;

            }
            else
            {

                // we are returning the shopping cart for the given user

                return (Carrito)HttpContext.Current.Session["ASPNETShoppingCart"];

            }

        }

    }*/

    /*public static Carrito Instance
    {
        get
        {
            Carrito c = null;
            if (HttpContext.Current.Session["ASPNETShoppingCart"] == null)
            {
                c = new Carrito();
                c.Items = new List<ItemCarrito>();
                HttpContext.Current.Session.Add("ASPNETShoppingCart", c);
            }
            else
            {
                c = (Carrito)HttpContext.Current.Session["ASPNETShoppingCart"];
            }
            return c;
        }
    }*/

    // The static constructor is called as soon as the class is loaded into memory 
    /*public Carrito GetShoppingCart()
    {
            // If the cart is not in the session, create one and put it there
            if (HttpContext.Current.Session["ASPNETShoppingCart"] == null)
            {
                Carrito cart = new Carrito();
                cart.Items = new List<ItemCarrito>();
                HttpContext.Current.Session["ASPNETShoppingCart"] = cart;
            }

            return (Carrito)HttpContext.Current.Session["ASPNETShoppingCart"];
    }*/

    //protected Carrito() { }

    public List<ItemCarrito> Items { get; private set; }

    public void AnyadirItem(int libroId, string titulo, decimal precio)
    {
        ItemCarrito nuevoItem = new ItemCarrito(libroId, titulo, precio);

        if (Items.Contains(nuevoItem))
        {
            foreach (ItemCarrito item in Items)
            {
                if (item.Equals(nuevoItem))
                {
                    item.Cantidad++;
                    return;
                }
            }
        }
        else
        {
            nuevoItem.Cantidad = 1;
            Items.Add(nuevoItem);
        }
    }

    public void SetCantidad(int isbn, int cantidad, string titulo, decimal precio)
    {
        if (cantidad == 0)
        {
            EliminarItem(isbn, titulo, precio);
            return;
        }

        ItemCarrito itemActualizado = new ItemCarrito(isbn, titulo, precio);

        foreach (ItemCarrito item in Items)
        {
            if (item.Equals(itemActualizado))
            {
                item.Cantidad = cantidad;
                return;
            }
        }
    }

    public void EliminarItem(int isbn, string titulo, decimal precio)
    {
        ItemCarrito itemEliminado = new ItemCarrito(isbn, titulo, precio);
        Items.Remove(itemEliminado);
    }

    public decimal CalcularTotal()
    {
        decimal total = 0;

        foreach (ItemCarrito item in Items)
        {
            total += item.PrecioTotal;
        }

        return total;
    }

    public int LeerItem(int i)
    {
        int isbn;

        isbn = Items[i].ISBN;

        return isbn;
    }
}