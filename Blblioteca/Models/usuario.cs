namespace Biblioteca.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaRegistro { get; set; }

    public Usuario()
    {
        Nombre = "";
        Email = "";
        Telefono = "";
        Activo = true;
        FechaRegistro = DateTime.Now;
    }

    public Usuario(int id, string nombre, string email, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Email = email;
        Telefono = telefono;
        Activo = true;
        FechaRegistro = DateTime.Now;
    }

    public string ResumenCorto()
    {
        return $"[{Id}] {Nombre} | {Email} | {(Activo ? "Activo" : "Inactivo")}";
    }

    public string DetalleCompleto()
    {
        return $"ID       : {Id}\n" +
               $"Nombre   : {Nombre}\n" +
               $"Email    : {Email}\n" +
               $"Teléfono : {Telefono}\n" +
               $"Activo   : {(Activo ? "Sí" : "No")}\n" +
               $"Registro : {FechaRegistro:dd/MM/yyyy}";
    }

    public override string ToString() => ResumenCorto();
}