using System;

// ═══════════════════════════════════════════════
// RAMA: feature/main-menu-navigation
// ═══════════════════════════════════════════════
class Program
{
    static void Main(string[] args)
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA BIBLIOTECA ===");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Prestamos");
            Console.WriteLine("4. Busquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Salir");
            Console.Write("Ingrese una opcion: ");
            opcion = int.Parse(Console.ReadLine());

            if (opcion == 1) MenuLibros();
            else if (opcion == 2) MenuUsuarios();
            else if (opcion == 3) MenuPrestamos();
            else if (opcion == 4) MenuBusquedas();
            else if (opcion == 5) MenuGuardarCargar();
            else if (opcion == 6) Salir();
            else { Console.WriteLine("Opcion no valida."); Console.ReadKey(); }

        } while (opcion != 6);
    }

    // ═══════════════════════════════════════════════
    // RAMA: feature/books-menu
    // ═══════════════════════════════════════════════
    static void MenuLibros()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("=== MENU LIBROS ===");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Listar libros");
            Console.WriteLine("3. Ver detalle de libro");
            Console.WriteLine("4. Actualizar libro");
            Console.WriteLine("5. Eliminar libro");
            Console.WriteLine("0. Volver");
            Console.Write("Ingrese una opcion: ");
            opcion = int.Parse(Console.ReadLine());

            if (opcion == 1) { Console.WriteLine("Aqui se va a registrar un nuevo libro."); Console.ReadKey(); }
            else if (opcion == 2) MenuListarLibros();
            else if (opcion == 3) { Console.WriteLine("Aqui se va a ver el detalle de un libro por ID o ISBN."); Console.ReadKey(); }
            else if (opcion == 4) MenuActualizarLibro();
            else if (opcion == 5) { Console.WriteLine("Aqui se va a eliminar un libro, validando que no este prestado."); Console.ReadKey(); }
            else if (opcion != 0) { Console.WriteLine("Opcion no valida."); Console.ReadKey(); }
        } while (opcion != 0);
    }

    static void MenuListarLibros()
    {
        Console.Clear();
        Console.WriteLine("=== LISTAR LIBROS ===");
        Console.WriteLine("1. Listar todos");
        Console.WriteLine("2. Listar disponibles");
        Console.WriteLine("3. Listar prestados");
        Console.WriteLine("0. Volver");
        Console.Write("Ingrese una opcion: ");
        int op = int.Parse(Console.ReadLine());
        if (op == 1) Console.WriteLine("Aqui se van a listar todos los libros.");
        else if (op == 2) Console.WriteLine("Aqui se van a listar los libros disponibles.");
        else if (op == 3) Console.WriteLine("Aqui se van a listar los libros prestados.");
        Console.ReadKey();
    }

    static void MenuActualizarLibro()
    {
        Console.Clear();
        Console.WriteLine("=== ACTUALIZAR LIBRO ===");
        Console.WriteLine("1. Editar titulo");
        Console.WriteLine("2. Editar autor");
        Console.WriteLine("3. Editar anio y categoria");
        Console.WriteLine("0. Volver");
        Console.Write("Ingrese una opcion: ");
        int op = int.Parse(Console.ReadLine());
        if (op == 1) Console.WriteLine("Aqui se va a editar el titulo del libro.");
        else if (op == 2) Console.WriteLine("Aqui se va a editar el autor del libro.");
        else if (op == 3) Console.WriteLine("Aqui se va a editar el anio y categoria del libro.");
        Console.ReadKey();
    }
}