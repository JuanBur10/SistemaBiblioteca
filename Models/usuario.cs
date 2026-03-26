namespace Biblioteca.Models;

class Usuario
{
    // Propiedades
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }
    public bool Activo { get; set; }

    // Constructor vacio
    public Usuario()
    {
        Nombre = "";
        Correo = "";
        Telefono = "";
        Activo = true;
    }

    // Constructor completo
    public Usuario(int id, string nombre, string correo, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Correo = correo;
        Telefono = telefono;
        Activo = true;
    }

    // Metodos
    public string ResumenCorto()
    {
        return $"[{Id}] {Nombre} - {Correo}";
    }

    public string DetalleCompleto()
    {
        return $"ID: {Id}\nNombre: {Nombre}\nCorreo: {Correo}\nTeléfono: {Telefono}\nActivo: {Activo}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}