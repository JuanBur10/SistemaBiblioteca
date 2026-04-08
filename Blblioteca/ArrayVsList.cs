namespace Biblioteca;

public class ArrayVsList
{
    public static void MostrarComparacion()
    {
        Console.WriteLine("══════════════════════════════════════");
        Console.WriteLine("      COMPARACIÓN: ARRAY VS LIST      ");
        Console.WriteLine("══════════════════════════════════════");

        // CON ARRAY 
        Console.WriteLine("\n── CON ARRAY ──");
        string[] librosArray = new string[3];
        librosArray[0] = "Cien años de soledad";
        librosArray[1] = "El principito";
        librosArray[2] = "Don Quijote";

        Console.WriteLine("Libros en el array:");
        foreach (string libro in librosArray)
        {
            Console.WriteLine($"  - {libro}");
        }

        // CON LIST
        Console.WriteLine("\n── CON LIST ──");
        List<string> librosList = new List<string>();
        librosList.Add("Cien años de soledad");
        librosList.Add("El principito");
        librosList.Add("Don Quijote");
        librosList.Add("Harry Potter");

        Console.WriteLine("Libros en la lista:");
        foreach (string libro in librosList)
        {
            Console.WriteLine($"  - {libro}");
        }

        librosList.Remove("El principito");
        Console.WriteLine("\nDespués de eliminar 'El principito':");
        foreach (string libro in librosList)
        {
            Console.WriteLine($"  - {libro}");
        }

        // DIFERENCIAS
        Console.WriteLine("\n── DIFERENCIAS ──");
        Console.WriteLine("ARRAY:");
        Console.WriteLine("  - Tamaño fijo, no cambia");
        Console.WriteLine("  - Más rápido en acceso por índice");
        Console.WriteLine("  - No tiene métodos como Add o Remove");
        Console.WriteLine("LIST:");
        Console.WriteLine("  - Tamaño dinámico, crece o decrece");
        Console.WriteLine("  - Tiene métodos como Add, Remove, Find");
        Console.WriteLine("  - Más flexible para gestionar colecciones");
        Console.WriteLine("══════════════════════════════════════");
    }
}