using Biblioteca.Models;

namespace Biblioteca.Services;

public class LibroService
{
    private List<Libro> libros = new List<Libro>();
    private int _nextId = 1;

    public void AgregarLibro(Libro libro)
    {
        libros.Add(libro);
        if (libro.Id >= _nextId) _nextId = libro.Id + 1;
    }

    public bool RegistrarLibro(string titulo, string autor, int anio, string categoria, string isbn, int stock)
    {
        if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor)) return false;
        libros.Add(new Libro(_nextId++, titulo, autor, anio, categoria, isbn, stock));
        return true;
    }

    public void EliminarLibro(int id)
    {
        Libro? encontrado = libros.Find(l => l.Id == id);
        if (encontrado != null) libros.Remove(encontrado);
    }

    public List<Libro> ObtenerTodos() => new List<Libro>(libros);

    public Libro? BuscarPorId(int id) => libros.Find(l => l.Id == id);

    public List<Libro> BuscarPorISBN(string isbn) =>
        libros.FindAll(l => l.ISBN.ToLower().Contains(isbn.ToLower()));

    public List<Libro> BuscarPorAutor(string autor) =>
        libros.FindAll(l => l.Autor.ToLower().Contains(autor.ToLower()));

    public List<Libro> BuscarPorTitulo(string titulo) =>
        libros.FindAll(l => l.Titulo.ToLower().Contains(titulo.ToLower()));

    public List<Libro> BuscarPorCategoria(string categoria) =>
        libros.FindAll(l => l.Categoria.ToLower().Contains(categoria.ToLower()));

    public List<Libro> OrdenarPorTitulo()
    {
        List<Libro> ordenados = new List<Libro>(libros);
        ordenados.Sort((a, b) => string.Compare(a.Titulo, b.Titulo));
        return ordenados;
    }

    public List<Libro> OrdenarPorAnio()
    {
        List<Libro> ordenados = new List<Libro>(libros);
        ordenados.Sort((a, b) => a.AnioPublicacion.CompareTo(b.AnioPublicacion));
        return ordenados;
    }

    public bool ActualizarLibro(int id, string titulo, string autor, int anio, string categoria)
    {
        var libro = BuscarPorId(id);
        if (libro == null) return false;
        if (!string.IsNullOrWhiteSpace(titulo)) libro.Titulo = titulo;
        if (!string.IsNullOrWhiteSpace(autor)) libro.Autor = autor;
        if (anio > 0) libro.AnioPublicacion = anio;
        if (!string.IsNullOrWhiteSpace(categoria)) libro.Categoria = categoria;
        return true;
    }

    public bool ReducirStock(int id)
    {
        var libro = BuscarPorId(id);
        if (libro == null || libro.Stock <= 0) return false;
        libro.Stock--;
        return true;
    }

    public bool AumentarStock(int id)
    {
        var libro = BuscarPorId(id);
        if (libro == null) return false;
        libro.Stock++;
        return true;
    }

    public int Count => libros.Count;

    public void MostrarEstadisticas()
    {
        Console.WriteLine("──── ESTADÍSTICAS DE LIBROS ────");
        Console.WriteLine($"Total de libros    : {libros.Count}");
        Console.WriteLine($"Disponibles        : {libros.FindAll(l => l.Disponible).Count}");
        Console.WriteLine($"Sin stock          : {libros.FindAll(l => !l.Disponible).Count}");
        if (libros.Any())
        {
            var top = libros.GroupBy(l => l.Categoria).OrderByDescending(g => g.Count()).First();
            Console.WriteLine($"Categoría top      : {top.Key} ({top.Count()})");
        }
        Console.WriteLine("────────────────────────────────");
    }
}