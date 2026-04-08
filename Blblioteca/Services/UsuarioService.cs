using Biblioteca.Models;

namespace Biblioteca.Services;

public class UsuarioService
{
    private List<Usuario> usuarios = new List<Usuario>();
    private int _nextId = 1;

    public void AgregarUsuario(Usuario usuario)
    {
        usuarios.Add(usuario);
        if (usuario.Id >= _nextId) _nextId = usuario.Id + 1;
    }

    public bool RegistrarUsuario(string nombre, string email, string telefono)
    {
        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(email)) return false;
        if (usuarios.Exists(u => u.Email.ToLower() == email.ToLower())) return false;
        usuarios.Add(new Usuario(_nextId++, nombre, email, telefono));
        return true;
    }

    public bool EliminarUsuario(int id)
    {
        Usuario? encontrado = usuarios.Find(u => u.Id == id);
        if (encontrado == null) return false;
        usuarios.Remove(encontrado);
        return true;
    }

    public List<Usuario> ObtenerTodos() => new List<Usuario>(usuarios);

    public Usuario? BuscarPorId(int id) => usuarios.Find(u => u.Id == id);

    public Usuario? BuscarPorEmail(string email) =>
        usuarios.Find(u => u.Email.ToLower().Contains(email.ToLower()));

    public List<Usuario> BuscarPorNombre(string nombre) =>
        usuarios.FindAll(u => u.Nombre.ToLower().Contains(nombre.ToLower()));

    public List<Usuario> OrdenarPorNombre()
    {
        List<Usuario> ordenados = new List<Usuario>(usuarios);
        ordenados.Sort((a, b) => string.Compare(a.Nombre, b.Nombre));
        return ordenados;
    }

    public bool ActualizarUsuario(int id, string nombre, string email, string telefono, bool? activo)
    {
        var u = BuscarPorId(id);
        if (u == null) return false;
        if (!string.IsNullOrWhiteSpace(nombre)) u.Nombre = nombre;
        if (!string.IsNullOrWhiteSpace(email)) u.Email = email;
        if (!string.IsNullOrWhiteSpace(telefono)) u.Telefono = telefono;
        if (activo.HasValue) u.Activo = activo.Value;
        return true;
    }

    public int Count => usuarios.Count;

    public void MostrarEstadisticas()
    {
        Console.WriteLine("──── ESTADÍSTICAS DE USUARIOS ────");
        Console.WriteLine($"Total de usuarios  : {usuarios.Count}");
        Console.WriteLine($"Activos            : {usuarios.FindAll(u => u.Activo).Count}");
        Console.WriteLine($"Inactivos          : {usuarios.FindAll(u => !u.Activo).Count}");
        Console.WriteLine("──────────────────────────────────");
    }
}