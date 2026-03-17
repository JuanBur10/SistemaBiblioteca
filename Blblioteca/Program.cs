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
}