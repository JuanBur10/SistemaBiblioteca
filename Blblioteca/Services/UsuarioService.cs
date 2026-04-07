using Biblioteca.Models;

namespace Biblioteca.Services;

class UsuarioService
{
    // Lista principal de usuarios
    private List<Usuario> usuarios = new List<Usuario>();

    // AGREGAR
    public void AgregarUsuario(Usuario usuario)
    {
        usuarios.Add(usuario);
        Console.WriteLine($"Usuario '{usuario.Nombre}' agregado correctamente.");
    }

    // ELIMINAR 
    public void EliminarUsuario(int id)
    {
        Usuario? encontrado = usuarios.Find(u => u.Id == id);
        if (encontrado != null)
        {
            usuarios.Remove(encontrado);
            Console.WriteLine($"Usuario '{encontrado.Nombre}' eliminado.");
        }
        else
        {
            Console.WriteLine("No se encontró ningún usuario con ese ID.");
        }
    }

    //OBTENER TODOS 
    public List<Usuario> ObtenerTodos()
    {
        return usuarios;
    }

    //BÚSQUEDAS 
    public Usuario? BuscarPorId(int id)
    {
        return usuarios.Find(u => u.Id == id);
    }

    public Usuario? BuscarPorDocumento(string documento)
    {
        return usuarios.Find(u => u.Correo.ToLower().Contains(documento.ToLower()));
    }

    public List<Usuario> BuscarPorNombre(string nombre)
    {
        return usuarios.FindAll(u => u.Nombre.ToLower().Contains(nombre.ToLower()));
    }

    //ORDENACIÓN
    public List<Usuario> OrdenarPorNombre()
    {
        List<Usuario> ordenados = new List<Usuario>(usuarios);
        ordenados.Sort((a, b) => string.Compare(a.Nombre, b.Nombre));
        return ordenados;
    }

    //KPIs 
    public int TotalUsuarios()
    {
        return usuarios.Count;
    }

    public int TotalActivos()
    {
        return usuarios.FindAll(u => u.Activo == true).Count;
    }

    public int TotalInactivos()
    {
        return usuarios.FindAll(u => u.Activo == false).Count;
    }

    public void MostrarEstadisticas()
    {
        Console.WriteLine("──── ESTADÍSTICAS DE USUARIOS ────");
        Console.WriteLine($"Total de usuarios:    {TotalUsuarios()}");
        Console.WriteLine($"Usuarios activos:     {TotalActivos()}");
        Console.WriteLine($"Usuarios inactivos:   {TotalInactivos()}");
        Console.WriteLine("──────────────────────────────────");
    }
}