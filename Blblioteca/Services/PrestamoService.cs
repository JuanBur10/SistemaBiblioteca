using Biblioteca.Models;

namespace Biblioteca.Services;

public class PrestamoService
{
    private List<Prestamo> prestamos = new List<Prestamo>();
    private int _nextId = 1;

    public void AgregarPrestamo(Prestamo prestamo)
    {
        prestamos.Add(prestamo);
        if (prestamo.Id >= _nextId) _nextId = prestamo.Id + 1;
    }

    public bool RegistrarPrestamo(int usuarioId, int libroId)
    {
        prestamos.Add(new Prestamo(_nextId++, usuarioId, libroId));
        return true;
    }

    public bool EliminarPrestamo(int id)
    {
        Prestamo? encontrado = prestamos.Find(p => p.Id == id);
        if (encontrado == null) return false;
        prestamos.Remove(encontrado);
        return true;
    }

    public List<Prestamo> ObtenerTodos() => new List<Prestamo>(prestamos);

    public Prestamo? BuscarPorId(int id) => prestamos.Find(p => p.Id == id);

    public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado) =>
        prestamos.FindAll(p => p.Estado == estado);

    public List<Prestamo> BuscarPorUsuario(int usuarioId) =>
        prestamos.FindAll(p => p.UsuarioId == usuarioId);

    public List<Prestamo> OrdenarPorFecha()
    {
        List<Prestamo> ordenados = new List<Prestamo>(prestamos);
        ordenados.Sort((a, b) => a.FechaPrestamo.CompareTo(b.FechaPrestamo));
        return ordenados;
    }

    public bool RegistrarDevolucion(int prestamoId)
    {
        var p = BuscarPorId(prestamoId);
        if (p == null || p.Estado == EstadoPrestamo.Devuelto) return false;
        p.Estado = EstadoPrestamo.Devuelto;
        p.FechaDevolucionReal = DateTime.Now;
        return true;
    }

    public void ActualizarEstados()
    {
        foreach (var p in prestamos)
            if (p.Estado == EstadoPrestamo.Activo && p.EstaVencido())
                p.Estado = EstadoPrestamo.Vencido;
    }

    public int Count => prestamos.Count;

    public void MostrarEstadisticas()
    {
        Console.WriteLine("──── ESTADÍSTICAS DE PRÉSTAMOS ────");
        Console.WriteLine($"Total de préstamos : {prestamos.Count}");
        Console.WriteLine($"Activos            : {prestamos.FindAll(p => p.Estado == EstadoPrestamo.Activo).Count}");
        Console.WriteLine($"Devueltos          : {prestamos.FindAll(p => p.Estado == EstadoPrestamo.Devuelto).Count}");
        Console.WriteLine($"Vencidos           : {prestamos.FindAll(p => p.Estado == EstadoPrestamo.Vencido).Count}");
        Console.WriteLine("───────────────────────────────────");
    }
}