using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca;

class Program
{
    static LibroService libroService = new();
    static UsuarioService usuarioService = new();
    static PrestamoService prestamoService = new();

    static void Main()
    {
        CargarDatosDePrueba();
        MenuPrincipal();
    }

    static void CargarDatosDePrueba()
    {
        libroService.AgregarLibro(new Libro(1, "Cien años de soledad", "Gabriel Garcia Marquez", 1967, "Novela", "ISBN-0001", 3));
        libroService.AgregarLibro(new Libro(2, "El principito", "Antoine de Saint-Exupery", 1943, "Infantil", "ISBN-0002", 2));
        libroService.AgregarLibro(new Libro(3, "Don Quijote", "Miguel de Cervantes", 1605, "Clasico", "ISBN-0003", 1));
        usuarioService.AgregarUsuario(new Usuario(1, "Juan Perez", "juan@gmail.com", "3001234567"));
        usuarioService.AgregarUsuario(new Usuario(2, "Maria Lopez", "maria@gmail.com", "3107654321"));
        prestamoService.AgregarPrestamo(new Prestamo(1, 1, 1));
    }

    static void MenuPrincipal()
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("    SISTEMA DE GESTIÓN BIBLIOTECARIA      ");
    
            Console.WriteLine($"  Libros: {libroService.Count,-5} Usuarios: {usuarioService.Count,-5} Préstamos: {prestamoService.Count,-4}");
            Console.WriteLine("  1. Libros                               ");
            Console.WriteLine("  2. Usuarios                             ");
            Console.WriteLine("  3. Préstamos                            ");
            Console.WriteLine("  4. Búsquedas y Reportes                 ");
            Console.WriteLine("  5. Guardar / Cargar Datos               ");
            Console.WriteLine("  6. Servicios y Estadísticas             ");
            Console.WriteLine("  0. Salir                                ");
            Console.Write("\nSeleccione una opción: ");

            switch (Console.ReadLine()?.Trim())
            {
                case "1": MenuLibros(); break;
                case "2": MenuUsuarios(); break;
                case "3": MenuPrestamos(); break;
                case "4": MenuReportes(); break;
                case "5": MenuDatos(); break;
                case "6": MenuServicios(); break;
                case "0":
                    Console.WriteLine("\nHasta luego. Sistema cerrado correctamente.");
                    salir = true;
                    break;
                default:
                    Console.WriteLine("\n[!] Opción inválida.");
                    Thread.Sleep(800);
                    break;
            }
        }
    }

    // 1. LIBROS
    static void MenuLibros()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║         GESTIÓN DE LIBROS            ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║  1.1 Registrar libro                 ║");
            Console.WriteLine("║  1.2 Listar todos los libros         ║");
            Console.WriteLine("║  1.3 Ver detalle de un libro         ║");
            Console.WriteLine("║  1.4 Actualizar libro                ║");
            Console.WriteLine("║  1.5 Eliminar libro                  ║");
            Console.WriteLine("║  0.  Volver                          ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.Write("\nOpción: ");
            string op = Console.ReadLine()?.Trim() ?? "";

            switch (op)
            {
                case "1.1":
                    Console.Clear();
                    Console.WriteLine(">> REGISTRAR LIBRO");
                    Console.Write("Título     : "); string titulo = Console.ReadLine() ?? "";
                    Console.Write("Autor      : "); string autor = Console.ReadLine() ?? "";
                    Console.Write("Año        : "); int.TryParse(Console.ReadLine(), out int anio);
                    Console.Write("Categoría  : "); string cat = Console.ReadLine() ?? "";
                    Console.Write("ISBN       : "); string isbn = Console.ReadLine() ?? "";
                    Console.Write("Stock      : "); int.TryParse(Console.ReadLine(), out int stock);
                    if (stock <= 0) stock = 1;
                    if (libroService.RegistrarLibro(titulo, autor, anio, cat, isbn, stock))
                        Ok("Libro registrado correctamente.");
                    else
                        Error("Datos inválidos. Título y autor son obligatorios.");
                    Pausa();
                    break;

                case "1.2":
                    Console.Clear();
                    Console.WriteLine(">> LISTADO DE LIBROS");
                    var libros = libroService.ObtenerTodos();
                    if (!libros.Any()) Console.WriteLine("No hay libros registrados.");
                    else foreach (var l in libros) Console.WriteLine(l.ResumenCorto());
                    Pausa();
                    break;

                case "1.3":
                    Console.Clear();
                    Console.WriteLine(">> DETALLE DE LIBRO");
                    Console.Write("Ingrese ID del libro: ");
                    if (int.TryParse(Console.ReadLine(), out int idL))
                    {
                        var libro = libroService.BuscarPorId(idL);
                        if (libro != null) Console.WriteLine("\n" + libro.DetalleCompleto());
                        else Error("Libro no encontrado.");
                    }
                    else Error("ID inválido.");
                    Pausa();
                    break;

                case "1.4":
                    Console.Clear();
                    Console.WriteLine(">> ACTUALIZAR LIBRO");
                    Console.Write("ID del libro a editar: ");
                    if (int.TryParse(Console.ReadLine(), out int idUpd))
                    {
                        var libro = libroService.BuscarPorId(idUpd);
                        if (libro == null) { Error("Libro no encontrado."); Pausa(); break; }
                        Console.WriteLine($"Editando: {libro.ResumenCorto()}");
                        Console.WriteLine("(Deje en blanco para no cambiar)");
                        Console.Write($"Nuevo título [{libro.Titulo}]: "); string nt = Console.ReadLine() ?? "";
                        Console.Write($"Nuevo autor [{libro.Autor}]: "); string na = Console.ReadLine() ?? "";
                        Console.Write($"Nuevo año [{libro.AnioPublicacion}]: "); int.TryParse(Console.ReadLine(), out int nAno);
                        Console.Write($"Nueva categoría [{libro.Categoria}]: "); string nc = Console.ReadLine() ?? "";
                        libroService.ActualizarLibro(idUpd, nt, na, nAno, nc);
                        Ok("Libro actualizado.");
                    }
                    else Error("ID inválido.");
                    Pausa();
                    break;

                case "1.5":
                    Console.Clear();
                    Console.WriteLine(">> ELIMINAR LIBRO");
                    Console.Write("ID del libro a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int idDel))
                    {
                        var libro = libroService.BuscarPorId(idDel);
                        if (libro == null) { Error("Libro no encontrado."); Pausa(); break; }
                        Console.Write($"¿Eliminar '{libro.Titulo}'? (S/N): ");
                        if (Console.ReadLine()?.ToUpper() == "S") { libroService.EliminarLibro(idDel); Ok("Libro eliminado."); }
                        else Console.WriteLine("Cancelado.");
                    }
                    else Error("ID inválido.");
                    Pausa();
                    break;

                case "0": volver = true; break;
                default: Error("Opción inválida."); Thread.Sleep(600); break;
            }
        }
    }

    // 2. USUARIOS
    static void MenuUsuarios()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║        GESTIÓN DE USUARIOS           ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║  2.1 Registrar usuario               ║");
            Console.WriteLine("║  2.2 Listar todos los usuarios       ║");
            Console.WriteLine("║  2.3 Ver detalle de un usuario       ║");
            Console.WriteLine("║  2.4 Actualizar usuario              ║");
            Console.WriteLine("║  2.5 Eliminar usuario                ║");
            Console.WriteLine("║  0.  Volver                          ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.Write("\nOpción: ");
            string op = Console.ReadLine()?.Trim() ?? "";

            switch (op)
            {
                case "2.1":
                    Console.Clear();
                    Console.WriteLine(">> REGISTRAR USUARIO");
                    Console.Write("Nombre   : "); string nombre = Console.ReadLine() ?? "";
                    Console.Write("Email    : "); string email = Console.ReadLine() ?? "";
                    Console.Write("Teléfono : "); string tel = Console.ReadLine() ?? "";
                    if (usuarioService.RegistrarUsuario(nombre, email, tel))
                        Ok("Usuario registrado correctamente.");
                    else
                        Error("Datos inválidos o email ya registrado.");
                    Pausa();
                    break;

                case "2.2":
                    Console.Clear();
                    Console.WriteLine(">> LISTADO DE USUARIOS");
                    var usuarios = usuarioService.ObtenerTodos();
                    if (!usuarios.Any()) Console.WriteLine("No hay usuarios registrados.");
                    else foreach (var u in usuarios) Console.WriteLine(u.ResumenCorto());
                    Pausa();
                    break;

                case "2.3":
                    Console.Clear();
                    Console.WriteLine(">> DETALLE DE USUARIO");
                    Console.Write("Ingrese ID del usuario: ");
                    if (int.TryParse(Console.ReadLine(), out int idU))
                    {
                        var u = usuarioService.BuscarPorId(idU);
                        if (u != null) Console.WriteLine("\n" + u.DetalleCompleto());
                        else Error("Usuario no encontrado.");
                    }
                    Pausa();
                    break;

                case "2.4":
                    Console.Clear();
                    Console.WriteLine(">> ACTUALIZAR USUARIO");
                    Console.Write("ID del usuario a editar: ");
                    if (int.TryParse(Console.ReadLine(), out int idUpdU))
                    {
                        var u = usuarioService.BuscarPorId(idUpdU);
                        if (u == null) { Error("Usuario no encontrado."); Pausa(); break; }
                        Console.WriteLine($"Editando: {u.ResumenCorto()}");
                        Console.WriteLine("(Deje en blanco para no cambiar)");
                        Console.Write($"Nuevo nombre [{u.Nombre}]: "); string nn = Console.ReadLine() ?? "";
                        Console.Write($"Nuevo email [{u.Email}]: "); string ne = Console.ReadLine() ?? "";
                        Console.Write($"Nuevo teléfono [{u.Telefono}]: "); string nt2 = Console.ReadLine() ?? "";
                        Console.Write($"Activo (S/N) [{(u.Activo ? "S" : "N")}]: ");
                        string actStr = Console.ReadLine()?.ToUpper() ?? "";
                        bool? activo = actStr == "S" ? true : actStr == "N" ? false : null;
                        usuarioService.ActualizarUsuario(idUpdU, nn, ne, nt2, activo);
                        Ok("Usuario actualizado.");
                    }
                    else Error("ID inválido.");
                    Pausa();
                    break;

                case "2.5":
                    Console.Clear();
                    Console.WriteLine(">> ELIMINAR USUARIO");
                    Console.Write("ID del usuario a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int idDelU))
                    {
                        var u = usuarioService.BuscarPorId(idDelU);
                        if (u == null) { Error("Usuario no encontrado."); Pausa(); break; }
                        Console.Write($"¿Eliminar a '{u.Nombre}'? (S/N): ");
                        if (Console.ReadLine()?.ToUpper() == "S") { usuarioService.EliminarUsuario(idDelU); Ok("Usuario eliminado."); }
                        else Console.WriteLine("Cancelado.");
                    }
                    else Error("ID inválido.");
                    Pausa();
                    break;

                case "0": volver = true; break;
                default: Error("Opción inválida."); Thread.Sleep(600); break;
            }
        }
    }

    // 3. PRÉSTAMOS 
    static void MenuPrestamos()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║        GESTIÓN DE PRÉSTAMOS          ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║  3.1 Crear préstamo                  ║");
            Console.WriteLine("║  3.2 Listar todos los préstamos      ║");
            Console.WriteLine("║  3.3 Ver detalle de un préstamo      ║");
            Console.WriteLine("║  3.4 Registrar devolución            ║");
            Console.WriteLine("║  3.5 Eliminar préstamo               ║");
            Console.WriteLine("║  0.  Volver                          ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.Write("\nOpción: ");
            string op = Console.ReadLine()?.Trim() ?? "";

            switch (op)
            {
                case "3.1":
                    Console.Clear();
                    Console.WriteLine(">> CREAR PRÉSTAMO");
                    var libDisp = libroService.ObtenerTodos().Where(l => l.Disponible).ToList();
                    if (!libDisp.Any()) { Error("No hay libros disponibles."); Pausa(); break; }
                    Console.WriteLine("-- Libros disponibles --");
                    foreach (var l in libDisp) Console.WriteLine(l.ResumenCorto());
                    Console.Write("\nID del libro  : ");
                    if (!int.TryParse(Console.ReadLine(), out int libId)) { Error("ID inválido."); Pausa(); break; }
                    var libroEleg = libroService.BuscarPorId(libId);
                    if (libroEleg == null || !libroEleg.Disponible) { Error("Libro no disponible."); Pausa(); break; }
                    var usrActivos = usuarioService.ObtenerTodos().Where(u => u.Activo).ToList();
                    if (!usrActivos.Any()) { Error("No hay usuarios activos."); Pausa(); break; }
                    Console.WriteLine("\n-- Usuarios activos --");
                    foreach (var u in usrActivos) Console.WriteLine(u.ResumenCorto());
                    Console.Write("\nID del usuario: ");
                    if (!int.TryParse(Console.ReadLine(), out int usrId)) { Error("ID inválido."); Pausa(); break; }
                    var usrEleg = usuarioService.BuscarPorId(usrId);
                    if (usrEleg == null || !usrEleg.Activo) { Error("Usuario no válido."); Pausa(); break; }
                    prestamoService.RegistrarPrestamo(usrId, libId);
                    libroService.ReducirStock(libId);
                    Ok($"Préstamo creado: '{libroEleg.Titulo}' → {usrEleg.Nombre}. Vence en 14 días.");
                    Pausa();
                    break;

                case "3.2":
                    Console.Clear();
                    Console.WriteLine(">> LISTADO DE PRÉSTAMOS");
                    prestamoService.ActualizarEstados();
                    var prestamos = prestamoService.ObtenerTodos();
                    if (!prestamos.Any()) Console.WriteLine("No hay préstamos registrados.");
                    else foreach (var p in prestamos) Console.WriteLine(p.ResumenCorto());
                    Pausa();
                    break;

                case "3.3":
                    Console.Clear();
                    Console.WriteLine(">> DETALLE DE PRÉSTAMO");
                    Console.Write("ID del préstamo: ");
                    if (int.TryParse(Console.ReadLine(), out int idP))
                    {
                        var p = prestamoService.BuscarPorId(idP);
                        if (p != null) Console.WriteLine("\n" + p.DetalleCompleto());
                        else Error("Préstamo no encontrado.");
                    }
                    Pausa();
                    break;

                case "3.4":
                    Console.Clear();
                    Console.WriteLine(">> REGISTRAR DEVOLUCIÓN");
                    prestamoService.ActualizarEstados();
                    var activos = prestamoService.BuscarPorEstado(EstadoPrestamo.Activo);
                    if (!activos.Any()) { Console.WriteLine("No hay préstamos activos."); Pausa(); break; }
                    Console.WriteLine("-- Préstamos activos --");
                    foreach (var p in activos) Console.WriteLine(p.ResumenCorto());
                    Console.Write("\nID del préstamo a devolver: ");
                    if (int.TryParse(Console.ReadLine(), out int idDev))
                    {
                        var prestamo = prestamoService.BuscarPorId(idDev);
                        if (prestamoService.RegistrarDevolucion(idDev))
                        {
                            if (prestamo != null) libroService.AumentarStock(prestamo.LibroId);
                            Ok("Devolución registrada. Stock actualizado.");
                        }
                        else Error("No se pudo registrar la devolución.");
                    }
                    else Error("ID inválido.");
                    Pausa();
                    break;

                case "3.5":
                    Console.Clear();
                    Console.WriteLine(">> ELIMINAR PRÉSTAMO");
                    Console.Write("ID del préstamo: ");
                    if (int.TryParse(Console.ReadLine(), out int idElim))
                    {
                        var p = prestamoService.BuscarPorId(idElim);
                        if (p == null) { Error("Préstamo no encontrado."); Pausa(); break; }
                        Console.Write($"¿Eliminar préstamo #{idElim}? (S/N): ");
                        if (Console.ReadLine()?.ToUpper() == "S") { prestamoService.EliminarPrestamo(idElim); Ok("Préstamo eliminado."); }
                    }
                    else Error("ID inválido.");
                    Pausa();
                    break;

                case "0": volver = true; break;
                default: Error("Opción inválida."); Thread.Sleep(600); break;
            }
        }
    }

    // 4. BÚSQUEDAS Y REPORTES 
    static void MenuReportes()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║       BÚSQUEDAS Y REPORTES           ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║  4.1 Buscar libro por título         ║");
            Console.WriteLine("║  4.2 Buscar libro por autor          ║");
            Console.WriteLine("║  4.3 Buscar libro por ISBN           ║");
            Console.WriteLine("║  4.4 Buscar libro por categoría      ║");
            Console.WriteLine("║  4.5 Buscar usuario por nombre       ║");
            Console.WriteLine("║  4.6 Reporte general                 ║");
            Console.WriteLine("║  0.  Volver                          ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.Write("\nOpción: ");
            string op = Console.ReadLine()?.Trim() ?? "";

            switch (op)
            {
                case "4.1": Console.Write("Título : "); MostrarLibros(libroService.BuscarPorTitulo(Console.ReadLine() ?? "")); break;
                case "4.2": Console.Write("Autor  : "); MostrarLibros(libroService.BuscarPorAutor(Console.ReadLine() ?? "")); break;
                case "4.3": Console.Write("ISBN   : "); MostrarLibros(libroService.BuscarPorISBN(Console.ReadLine() ?? "")); break;
                case "4.4": Console.Write("Categ. : "); MostrarLibros(libroService.BuscarPorCategoria(Console.ReadLine() ?? "")); break;
                case "4.5":
                    Console.Write("Nombre : ");
                    var ur = usuarioService.BuscarPorNombre(Console.ReadLine() ?? "");
                    Console.WriteLine($"\n{ur.Count} resultado(s):");
                    if (!ur.Any()) Console.WriteLine("Sin resultados.");
                    else foreach (var u in ur) Console.WriteLine(u.ResumenCorto());
                    Pausa();
                    break;
                case "4.6":
                    Console.Clear();
                    Console.WriteLine("=== REPORTE GENERAL ===\n");
                    libroService.MostrarEstadisticas(); Console.WriteLine();
                    usuarioService.MostrarEstadisticas(); Console.WriteLine();
                    prestamoService.MostrarEstadisticas();
                    Pausa();
                    break;
                case "0": volver = true; break;
                default: Error("Opción inválida."); Thread.Sleep(600); break;
            }
        }
    }

    static void MostrarLibros(List<Libro> lista)
    {
        Console.WriteLine($"\n{lista.Count} resultado(s):");
        if (!lista.Any()) Console.WriteLine("Sin resultados.");
        else foreach (var l in lista) Console.WriteLine(l.ResumenCorto());
        Pausa();
    }

    // 5. GUARDAR / CARGAR 
    static void MenuDatos()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║       GUARDAR / CARGAR DATOS         ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║  5.1 Guardar datos en archivo        ║");
            Console.WriteLine("║  5.2 Cargar datos desde archivo      ║");
            Console.WriteLine("║  5.3 Reiniciar sistema               ║");
            Console.WriteLine("║  0.  Volver                          ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.Write("\nOpción: ");
            switch (Console.ReadLine()?.Trim())
            {
                case "5.1": GuardarDatos(); break;
                case "5.2": CargarDatos(); break;
                case "5.3":
                    Console.Write("¿Confirmar reinicio total? (S/N): ");
                    if (Console.ReadLine()?.ToUpper() == "S")
                    {
                        libroService = new(); usuarioService = new(); prestamoService = new();
                        Ok("Sistema reiniciado. Todos los datos borrados.");
                    }
                    else Console.WriteLine("Cancelado.");
                    Pausa();
                    break;
                case "0": volver = true; break;
                default: Error("Opción inválida."); Thread.Sleep(600); break;
            }
        }
    }

    static void GuardarDatos()
    {
        try
        {
            string ruta = "biblioteca_datos.txt";
            using var sw = new StreamWriter(ruta);
            sw.WriteLine("[LIBROS]");
            foreach (var l in libroService.ObtenerTodos())
                sw.WriteLine($"{l.Id}|{l.Titulo}|{l.Autor}|{l.AnioPublicacion}|{l.Categoria}|{l.ISBN}|{l.Stock}");
            sw.WriteLine("[USUARIOS]");
            foreach (var u in usuarioService.ObtenerTodos())
                sw.WriteLine($"{u.Id}|{u.Nombre}|{u.Email}|{u.Telefono}|{u.Activo}");
            sw.WriteLine("[PRESTAMOS]");
            foreach (var p in prestamoService.ObtenerTodos())
                sw.WriteLine($"{p.Id}|{p.UsuarioId}|{p.LibroId}|{p.FechaPrestamo:O}|{p.Estado}");
            Ok($"Datos guardados en '{ruta}'.");
        }
        catch (Exception ex) { Error($"Error al guardar: {ex.Message}"); }
        Pausa();
    }

    static void CargarDatos()
    {
        string ruta = "biblioteca_datos.txt";
        if (!File.Exists(ruta)) { Error("Archivo no encontrado. Use 5.1 para guardar primero."); Pausa(); return; }
        try
        {
            libroService = new(); usuarioService = new(); prestamoService = new();
            string seccion = "";
            foreach (var linea in File.ReadAllLines(ruta))
            {
                if (linea.StartsWith("[")) { seccion = linea; continue; }
                var p = linea.Split('|');
                if (seccion == "[LIBROS]" && p.Length == 7)
                    libroService.AgregarLibro(new Libro(int.Parse(p[0]), p[1], p[2], int.Parse(p[3]), p[4], p[5], int.Parse(p[6])));
                else if (seccion == "[USUARIOS]" && p.Length == 5)
                {
                    var u = new Usuario(int.Parse(p[0]), p[1], p[2], p[3]);
                    u.Activo = bool.Parse(p[4]);
                    usuarioService.AgregarUsuario(u);
                }
                else if (seccion == "[PRESTAMOS]" && p.Length == 5)
                {
                    var pr = new Prestamo(int.Parse(p[0]), int.Parse(p[1]), int.Parse(p[2]));
                    pr.FechaPrestamo = DateTime.Parse(p[3]);
                    pr.Estado = Enum.Parse<EstadoPrestamo>(p[4]);
                    prestamoService.AgregarPrestamo(pr);
                }
            }
            Ok($"Datos cargados correctamente desde '{ruta}'.");
        }
        catch (Exception ex) { Error($"Error al cargar: {ex.Message}"); }
        Pausa();
    }

    // 6. SERVICIOS Y ESTADÍSTICAS
    static void MenuServicios()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║      SERVICIOS Y ESTADÍSTICAS        ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║  6.1 Estadísticas de libros          ║");
            Console.WriteLine("║  6.2 Estadísticas de usuarios        ║");
            Console.WriteLine("║  6.3 Estadísticas de préstamos       ║");
            Console.WriteLine("║  6.4 Comparación Array vs List       ║");
            Console.WriteLine("║  0.  Volver                          ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.Write("\nOpción: ");
            switch (Console.ReadLine()?.Trim())
            {
                case "6.1":
                    Console.Clear();
                    Console.WriteLine("-- LIBROS ORDENADOS POR TÍTULO --");
                    foreach (var l in libroService.OrdenarPorTitulo()) Console.WriteLine(l.ResumenCorto());
                    Console.WriteLine(); libroService.MostrarEstadisticas();
                    Pausa(); break;
                case "6.2":
                    Console.Clear();
                    Console.WriteLine("-- USUARIOS ORDENADOS POR NOMBRE --");
                    foreach (var u in usuarioService.OrdenarPorNombre()) Console.WriteLine(u.ResumenCorto());
                    Console.WriteLine(); usuarioService.MostrarEstadisticas();
                    Pausa(); break;
                case "6.3":
                    Console.Clear();
                    prestamoService.ActualizarEstados();
                    Console.WriteLine("-- PRÉSTAMOS ACTIVOS --");
                    var pA = prestamoService.BuscarPorEstado(EstadoPrestamo.Activo);
                    if (!pA.Any()) Console.WriteLine("Ninguno."); else foreach (var p in pA) Console.WriteLine(p.ResumenCorto());
                    Console.WriteLine("\n-- TODOS POR FECHA --");
                    foreach (var p in prestamoService.OrdenarPorFecha()) Console.WriteLine(p.ResumenCorto());
                    Console.WriteLine(); prestamoService.MostrarEstadisticas();
                    Pausa(); break;
                case "6.4":
                    Console.Clear(); ArrayVsList.MostrarComparacion(); Pausa(); break;
                case "0": volver = true; break;
                default: Error("Opción inválida."); Thread.Sleep(600); break;
            }
        }
    }

    // HELPERS
    static void Ok(string msg) => Console.WriteLine($"\n[OK] {msg}");
    static void Error(string msg) => Console.WriteLine($"\n[ERROR] {msg}");
    static void Pausa() { Console.WriteLine("\nPresione una tecla para continuar..."); Console.ReadKey(); }
}
