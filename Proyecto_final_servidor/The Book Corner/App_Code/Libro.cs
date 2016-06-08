using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Libro
/// </summary>
public class Libro
{

    public int ISBN { get; set; }

    public decimal Precio
    {
        get;
        set;
    }

    public string Titulo
    {
        get;
        set;
    }

    public Libro(int isbn, decimal precio, string titulo)
    {
        this.ISBN = isbn;
        this.Precio = precio;
        this.Titulo = titulo;
    }

}