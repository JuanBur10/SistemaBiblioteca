namespace Biblioteca.Models;

class Prestamo
{
    // Propiedades
    public int Id { get; set; }
    public int LibroId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public EstadoPrestamo Estado { get; set; }

    // Constructor vacio
    public Prestamo()
    {
        FechaPrestamo = DateTime.Now;
        FechaDevolucion = null;
        Estado = EstadoPrestamo.Activo;
    }

    // Constructor completo
    public Prestamo(int id, int libroId, int usuarioId)
    {
        Id = id;
        LibroId = libroId;
        UsuarioId = usuarioId;
        FechaPrestamo = DateTime.Now;
        FechaDevolucion = null;
        Estado = EstadoPrestamo.Activo;
    }

    // Metodos
    public bool EstaVencido()
    {
        return Estado == EstadoPrestamo.Vencido;
    }

    public int DiasTranscurridos()
    {
        return (DateTime.Now - FechaPrestamo).Days;
    }

    public string ResumenCorto()
    {
        return $"[{Id}] Libro:{LibroId} - Usuario:{UsuarioId} - Estado:{Estado}";
    }

    public string DetalleCompleto()
    {
        return $"ID: {Id}\nLibro ID: {LibroId}\nUsuario ID: {UsuarioId}\nFecha Préstamo: {FechaPrestamo}\nFecha Devolución: {FechaDevolucion}\nEstado: {Estado}\nDías transcurridos: {DiasTranscurridos()}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}