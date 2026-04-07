using Biblioteca.Models;

namespace Biblioteca.Services;

class LibroService
{
    // Lista principal de libros
    private List<Libro> libros = new List<Libro>();

    // AGREGAR 
    public void AgregarLibro(Libro libro)
    {
        libros.Add(libro);
        Console.WriteLine($"Libro '{libro.Titulo}' agregado correctamente.");
    }

    // ELIMINAR
    public void EliminarLibro(int id)
    {
        Libro? encontrado = libros.Find(l => l.Id == id);
        if (encontrado != null)
        {
            libros.Remove(encontrado);
            Console.WriteLine($"Libro '{encontrado.Titulo}' eliminado.");
        }
        else
        {
            Console.WriteLine("No se encontró ningún libro con ese ID.");
        }
    }

    //OBTENER TODOS 
    public List<Libro> ObtenerTodos()
    {
        return libros;
    }

    // BÚSQUEDAS 
    public Libro? BuscarPorId(int id)
    {
        return libros.Find(l => l.Id == id);
    }

    public Libro? BuscarPorIsbn(string isbn)
    {
        return libros.Find(l => l.Titulo.ToLower().Contains(isbn.ToLower()));
    }

    public List<Libro> BuscarPorAutor(string autor)
    {
        return libros.FindAll(l => l.Autor.ToLower().Contains(autor.ToLower()));
    }

    public List<Libro> BuscarPorTitulo(string titulo)
    {
        return libros.FindAll(l => l.Titulo.ToLower().Contains(titulo.ToLower()));
    }

    //ORDENACIÓN
    public List<Libro> OrdenarPorTitulo()
    {
        List<Libro> ordenados = new List<Libro>(libros);
        ordenados.Sort((a, b) => string.Compare(a.Titulo, b.Titulo));
        return ordenados;
    }

    public List<Libro> OrdenarPorAnio()
    {
        List<Libro> ordenados = new List<Libro>(libros);
        ordenados.Sort((a, b) => a.Anio.CompareTo(b.Anio));
        return ordenados;
    }

    //KPIs 
    public int TotalLibros()
    {
        return libros.Count;
    }

    public int TotalDisponibles()
    {
        return libros.FindAll(l => l.Disponible == true).Count;
    }

    public int TotalPrestados()
    {
        return libros.FindAll(l => l.Disponible == false).Count;
    }

    public void MostrarEstadisticas()
    {
        Console.WriteLine("──── ESTADÍSTICAS DE LIBROS ────");
        Console.WriteLine($"Total de libros:      {TotalLibros()}");
        Console.WriteLine($"Libros disponibles:   {TotalDisponibles()}");
        Console.WriteLine($"Libros prestados:     {TotalPrestados()}");
        Console.WriteLine("────────────────────────────────");
    }
}