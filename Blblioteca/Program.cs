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

    // ═══════════════════════════════════════════════
    // RAMA: feature/users-menu
    // ═══════════════════════════════════════════════
    static void MenuUsuarios()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("=== MENU USUARIOS ===");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Listar usuarios");
            Console.WriteLine("3. Ver detalle de usuario");
            Console.WriteLine("4. Actualizar usuario");
            Console.WriteLine("5. Eliminar usuario");
            Console.WriteLine("0. Volver");
            Console.Write("Ingrese una opcion: ");
            opcion = int.Parse(Console.ReadLine());

            if (opcion == 1) { Console.WriteLine("Aqui se va a registrar un nuevo usuario."); Console.ReadKey(); }
            else if (opcion == 2) { Console.WriteLine("Aqui se va a listar todos los usuarios."); Console.ReadKey(); }
            else if (opcion == 3) { Console.WriteLine("Aqui se va a ver el detalle de un usuario por ID o documento."); Console.ReadKey(); }
            else if (opcion == 4) MenuActualizarUsuario();
            else if (opcion == 5) { Console.WriteLine("Aqui se va a eliminar un usuario, validando que no tenga prestamos activos."); Console.ReadKey(); }
            else if (opcion != 0) { Console.WriteLine("Opcion no valida."); Console.ReadKey(); }
        } while (opcion != 0);
    }

    static void MenuActualizarUsuario()
    {
        Console.Clear();
        Console.WriteLine("=== ACTUALIZAR USUARIO ===");
        Console.WriteLine("1. Editar nombre");
        Console.WriteLine("2. Editar contacto");
        Console.WriteLine("3. Activar o desactivar usuario");
        Console.WriteLine("0. Volver");
        Console.Write("Ingrese una opcion: ");
        int op = int.Parse(Console.ReadLine());
        if (op == 1) Console.WriteLine("Aqui se va a editar el nombre del usuario.");
        else if (op == 2) Console.WriteLine("Aqui se va a editar el contacto del usuario.");
        else if (op == 3) Console.WriteLine("Aqui se va a activar o desactivar el usuario.");
        Console.ReadKey();
    }

    // ═══════════════════════════════════════════════
    // RAMA: feature/loans-menu
    // ═══════════════════════════════════════════════
    static void MenuPrestamos()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("=== MENU PRESTAMOS ===");
            Console.WriteLine("1. Crear prestamo");
            Console.WriteLine("2. Listar prestamos");
            Console.WriteLine("3. Ver detalle de prestamo");
            Console.WriteLine("4. Registrar devolucion");
            Console.WriteLine("5. Eliminar prestamo");
            Console.WriteLine("0. Volver");
            Console.Write("Ingrese una opcion: ");
            opcion = int.Parse(Console.ReadLine());

            if (opcion == 1) { Console.WriteLine("Aqui se va a crear un prestamo validando usuario activo y libro disponible."); Console.ReadKey(); }
            else if (opcion == 2) MenuListarPrestamos();
            else if (opcion == 3) { Console.WriteLine("Aqui se va a ver el detalle de un prestamo por ID."); Console.ReadKey(); }
            else if (opcion == 4) { Console.WriteLine("Aqui se va a registrar la devolucion de un libro."); Console.ReadKey(); }
            else if (opcion == 5) { Console.WriteLine("Aqui se va a eliminar un prestamo solo si esta cerrado."); Console.ReadKey(); }
            else if (opcion != 0) { Console.WriteLine("Opcion no valida."); Console.ReadKey(); }
        } while (opcion != 0);
    }

    static void MenuListarPrestamos()
    {
        Console.Clear();
        Console.WriteLine("=== LISTAR PRESTAMOS ===");
        Console.WriteLine("1. Todos");
        Console.WriteLine("2. Activos");
        Console.WriteLine("3. Cerrados");
        Console.WriteLine("0. Volver");
        Console.Write("Ingrese una opcion: ");
        int op = int.Parse(Console.ReadLine());
        if (op == 1) Console.WriteLine("Aqui se van a listar todos los prestamos.");
        else if (op == 2) Console.WriteLine("Aqui se van a listar los prestamos activos.");
        else if (op == 3) Console.WriteLine("Aqui se van a listar los prestamos cerrados.");
        Console.ReadKey();
    }
    // ═══════════════════════════════════════════════
    // RAMA: feature/search-reports-menu
    // ═══════════════════════════════════════════════
    static void MenuBusquedas()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("=== BUSQUEDAS Y REPORTES ===");
            Console.WriteLine("1. Buscar libro");
            Console.WriteLine("2. Buscar usuario");
            Console.WriteLine("3. Reportes");
            Console.WriteLine("0. Volver");
            Console.Write("Ingrese una opcion: ");
            opcion = int.Parse(Console.ReadLine());

            if (opcion == 1) MenuBuscarLibro();
            else if (opcion == 2) MenuBuscarUsuario();
            else if (opcion == 3) MenuReportes();
            else if (opcion != 0) { Console.WriteLine("Opcion no valida."); Console.ReadKey(); }
        } while (opcion != 0);
    }

    static void MenuBuscarLibro()
    {
        Console.Clear();
        Console.WriteLine("=== BUSCAR LIBRO ===");
        Console.WriteLine("1. Por titulo");
        Console.WriteLine("2. Por autor");
        Console.WriteLine("3. Por ID o ISBN");
        Console.WriteLine("4. Por categoria");
        Console.WriteLine("0. Volver");
        Console.Write("Ingrese una opcion: ");
        int op = int.Parse(Console.ReadLine());
        if (op == 1) Console.WriteLine("Aqui se va a buscar un libro por titulo.");
        else if (op == 2) Console.WriteLine("Aqui se va a buscar un libro por autor.");
        else if (op == 3) Console.WriteLine("Aqui se va a buscar un libro por ID o ISBN.");
        else if (op == 4) Console.WriteLine("Aqui se va a buscar un libro por categoria.");
        Console.ReadKey();
    }

    static void MenuBuscarUsuario()
    {
        Console.Clear();
        Console.WriteLine("=== BUSCAR USUARIO ===");
        Console.WriteLine("1. Por nombre");
        Console.WriteLine("2. Por ID o documento");
        Console.WriteLine("0. Volver");
        Console.Write("Ingrese una opcion: ");
        int op = int.Parse(Console.ReadLine());
        if (op == 1) Console.WriteLine("Aqui se va a buscar un usuario por nombre.");
        else if (op == 2) Console.WriteLine("Aqui se va a buscar un usuario por ID o documento.");
        Console.ReadKey();
    }

    static void MenuReportes()
    {
        Console.Clear();
        Console.WriteLine("=== REPORTES ===");
        Console.WriteLine("1. Prestamos por usuario");
        Console.WriteLine("2. Prestamos por libro");
        Console.WriteLine("3. Prestamos vencidos");
        Console.WriteLine("4. Resumen general");
        Console.WriteLine("0. Volver");
        Console.Write("Ingrese una opcion: ");
        int op = int.Parse(Console.ReadLine());
        if (op == 1) Console.WriteLine("Aqui se va a mostrar el reporte de prestamos por usuario.");
        else if (op == 2) Console.WriteLine("Aqui se va a mostrar el reporte de prestamos por libro.");
        else if (op == 3) Console.WriteLine("Aqui se va a mostrar el reporte de prestamos vencidos.");
        else if (op == 4) Console.WriteLine("Aqui se va a mostrar el resumen general del sistema.");
        Console.ReadKey();
    }
    // ═══════════════════════════════════════════════
    // RAMA: feature/persistence-menu
    // ═══════════════════════════════════════════════
    static void MenuGuardarCargar()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("=== GUARDAR / CARGAR DATOS ===");
            Console.WriteLine("1. Guardar datos");
            Console.WriteLine("2. Cargar datos");
            Console.WriteLine("3. Reiniciar datos");
            Console.WriteLine("0. Volver");
            Console.Write("Ingrese una opcion: ");
            opcion = int.Parse(Console.ReadLine());

            if (opcion == 1) { Console.WriteLine("Aqui se van a guardar los datos del sistema."); Console.ReadKey(); }
            else if (opcion == 2) { Console.WriteLine("Aqui se van a cargar los datos guardados."); Console.ReadKey(); }
            else if (opcion == 3) { Console.WriteLine("Aqui se va a reiniciar toda la informacion del sistema."); Console.ReadKey(); }
            else if (opcion != 0) { Console.WriteLine("Opcion no valida."); Console.ReadKey(); }
        } while (opcion != 0);
    }

    // ═══════════════════════════════════════════════
    // RAMA: feature/exit-flow
    // ═══════════════════════════════════════════════
    static void Salir()
    {
        Console.Clear();
        Console.Write("Desea guardar antes de salir? (S/N): ");
        string respuesta = Console.ReadLine();
        if (respuesta == "S" || respuesta == "s")
            Console.WriteLine("Datos guardados. Hasta luego!");
        else
            Console.WriteLine("Saliendo sin guardar. Hasta luego!");
        Console.ReadKey();
    }
}