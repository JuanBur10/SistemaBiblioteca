namespace Biblioteca.Models;

public class Prestamo
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int LibroId { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaDevolucionEsperada { get; set; }
    public DateTime? FechaDevolucionReal { get; set; }
    public EstadoPrestamo Estado { get; set; }

    public Prestamo()
    {
        FechaPrestamo = DateTime.Now;
        FechaDevolucionEsperada = DateTime.Now.AddDays(14);
        Estado = EstadoPrestamo.Activo;
    }

    public Prestamo(int id, int usuarioId, int libroId)
    {
        Id = id;
        UsuarioId = usuarioId;
        LibroId = libroId;
        FechaPrestamo = DateTime.Now;
        FechaDevolucionEsperada = DateTime.Now.AddDays(14);
        Estado = EstadoPrestamo.Activo;
    }

    public bool EstaVencido()
    {
        if (Estado == EstadoPrestamo.Devuelto) return false;
        return DateTime.Now > FechaDevolucionEsperada;
    }

    public int DiasTranscurridos()
    {
        return (int)(DateTime.Now - FechaPrestamo).TotalDays;
    }

    public string ResumenCorto()
    {
        return $"[{Id}] Usuario:{UsuarioId} | Libro:{LibroId} | {Estado} | Vence:{FechaDevolucionEsperada:dd/MM/yyyy}";
    }

    public string DetalleCompleto()
    {
        return $"ID Préstamo : {Id}\n" +
               $"Usuario ID  : {UsuarioId}\n" +
               $"Libro ID    : {LibroId}\n" +
               $"Fecha inicio: {FechaPrestamo:dd/MM/yyyy}\n" +
               $"Vence el    : {FechaDevolucionEsperada:dd/MM/yyyy}\n" +
               $"Devuelto el : {(FechaDevolucionReal.HasValue ? FechaDevolucionReal.Value.ToString("dd/MM/yyyy") : "Pendiente")}\n" +
               $"Estado      : {Estado}\n" +
               $"Días trans. : {DiasTranscurridos()}\n" +
               $"Vencido     : {(EstaVencido() ? "Sí" : "No")}";
    }

    public override string ToString() => ResumenCorto();
}