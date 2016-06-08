using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ItemCarrito
/// </summary>
public class ItemCarrito : IEquatable<ItemCarrito>
{
    public int Cantidad { get; set; }

    private int _iSBN;
    public int ISBN
    {
        get { return _iSBN; }
        set
        {
            _libro = null;
            _iSBN = value;
        }
    }

    private string titulo;
    public string Titulo
    {
        get { return titulo; }
        set
        {
            titulo = value;
        }
    }

    private decimal precio;
    public decimal PrecioUnidad
    {
        get { return precio; }
        set { precio = value; }
    }

    public decimal PrecioTotal
    {
        get { return PrecioUnidad * Cantidad; }
    }

    private Libro _libro = null;
    public Libro Libro
    {
        get
        {
            if (_libro == null)
            {
                _libro = new Libro(ISBN, PrecioUnidad, Titulo);
            }
            return _libro;
        }
    }

    public ItemCarrito(int libroId, string titulo, decimal precio)
    {
        this.ISBN = libroId;
        this.Titulo = titulo;
        this.PrecioUnidad = precio;
    }

    public bool Equals(ItemCarrito item)
    {
        return item.ISBN == this.ISBN;
    }


         
}