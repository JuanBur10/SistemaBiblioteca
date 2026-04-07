using Biblioteca.Models;

namespace Biblioteca.Services;

class PrestamoService
{
    // Lista principal de prestamos
    private List<Prestamo> prestamos = new List<Prestamo>();

    // AGREGAR
    public void AgregarPrestamo(Prestamo prestamo)
    {
        prestamos.Add(prestamo);
        Console.WriteLine($"Préstamo '{prestamo.Id}' agregado correctamente.");
    }

    // ELIMINAR
    public void EliminarPrestamo(int id)
    {
        Prestamo? encontrado = prestamos.Find(p => p.Id == id);
        if (encontrado != null)
        {
            prestamos.Remove(encontrado);
            Console.WriteLine($"Préstamo '{encontrado.Id}' eliminado.");
        }
        else
        {
            Console.WriteLine("No se encontró ningún préstamo con ese ID.");
        }
    }

    //OBTENER TODOS 
    public List<Prestamo> ObtenerTodos()
    {
        return prestamos;
    }

    // BÚSQUEDAS 
    public Prestamo? BuscarPorId(int id)
    {
        return prestamos.Find(p => p.Id == id);
    }

    public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado)
    {
        return prestamos.FindAll(p => p.Estado == estado);
    }

    public List<Prestamo> BuscarPorUsuario(int usuarioId)
    {
        return prestamos.FindAll(p => p.UsuarioId == usuarioId);
    }

    // ORDENACIÓN 
    public List<Prestamo> OrdenarPorFecha()
    {
        List<Prestamo> ordenados = new List<Prestamo>(prestamos);
        ordenados.Sort((a, b) => a.FechaPrestamo.CompareTo(b.FechaPrestamo));
        return ordenados;
    }

    // KPIs
    public int TotalPrestamos()
    {
        return prestamos.Count;
    }

    public int TotalActivos()
    {
        return prestamos.FindAll(p => p.Estado == EstadoPrestamo.Activo).Count;
    }

    public int TotalVencidos()
    {
        return prestamos.FindAll(p => p.Estado == EstadoPrestamo.Vencido).Count;
    }

    public int TotalDevueltos()
    {
        return prestamos.FindAll(p => p.Estado == EstadoPrestamo.Devuelto).Count;
    }

    public double PromedioDiasPrestamo()
    {
        if (prestamos.Count == 0) return 0;
        double total = 0;
        foreach (Prestamo p in prestamos)
        {
            total += p.DiasTranscurridos();
        }
        return total / prestamos.Count;
    }

    public void MostrarEstadisticas()
    {
        Console.WriteLine("──── ESTADÍSTICAS DE PRÉSTAMOS ────");
        Console.WriteLine($"Total de préstamos:   {TotalPrestamos()}");
        Console.WriteLine($"Préstamos activos:    {TotalActivos()}");
        Console.WriteLine($"Préstamos vencidos:   {TotalVencidos()}");
        Console.WriteLine($"Préstamos devueltos:  {TotalDevueltos()}");
        Console.WriteLine($"Promedio días:        {PromedioDiasPrestamo():F1} días");
        Console.WriteLine("───────────────────────────────────");
    }
}