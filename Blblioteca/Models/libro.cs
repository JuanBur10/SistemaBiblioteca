namespace Biblioteca.Models;

public class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnioPublicacion { get; set; }
    public string Categoria { get; set; }
    public string ISBN { get; set; }
    public int Stock { get; set; }
    public bool Disponible => Stock > 0;

    public Libro()
    {
        Titulo = "";
        Autor = "";
        Categoria = "";
        ISBN = "";
        Stock = 1;
    }

    public Libro(int id, string titulo, string autor, int anio, string categoria, string isbn = "", int stock = 1)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        AnioPublicacion = anio;
        Categoria = categoria;
        ISBN = string.IsNullOrEmpty(isbn) ? $"ISBN-{id:D4}" : isbn;
        Stock = stock;
    }

    public string ResumenCorto()
    {
        return $"[{Id}] \"{Titulo}\" - {Autor} ({AnioPublicacion}) | Stock: {Stock}";
    }

    public string DetalleCompleto()
    {
        return $"ID        : {Id}\n" +
               $"Título    : {Titulo}\n" +
               $"Autor     : {Autor}\n" +
               $"Año       : {AnioPublicacion}\n" +
               $"Categoría : {Categoria}\n" +
               $"ISBN      : {ISBN}\n" +
               $"Stock     : {Stock}\n" +
               $"Disponible: {(Disponible ? "Sí" : "No")}";
    }

    public override string ToString() => ResumenCorto();
}