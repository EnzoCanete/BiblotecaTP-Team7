
namespace BibliotecaTP_Team7
{
    internal class Program
    {
        static void Main()
        {
            Biblioteca biblioteca = new();

            Console.WriteLine("--- 1. CARGA INICIAL ---");
            biblioteca.AgregarLibro("El Aleph", "Borges", "Sur");
            biblioteca.AgregarLibro("Ficciones", "Borges", "Sur");
            biblioteca.AgregarLibro("Rayuela", "Cortazar", "Sudamericana");
            biblioteca.AgregarLibro("1984", "Orwell", "Seix Barral");

            // Prueba de alta de lector exitosa y fallida
            Console.WriteLine(biblioteca.AltaLector("Emanuel", 11111111) ? "Lector Emanuel agregado." : "Error: DNI duplicado.");
            Console.WriteLine(biblioteca.AltaLector("Juan", 11111111) ? "Lector Juan agregado." : "Error: DNI duplicado."); // Debe fallar
            Console.WriteLine(biblioteca.AltaLector("Maria", 22222222) ? "Lector Maria agregada.\n" : "Error: DNI duplicado.\n");

            Console.WriteLine("--- 2. LOTE DE PRUEBAS DE PRESTAMOS ---");

            // Prueba A: Lector que no existe
            Console.WriteLine("Prueba A: " + biblioteca.PrestarLibro("El Aleph", 99999999));

            // Prueba B: Libro que no existe
            Console.WriteLine("Prueba B: " + biblioteca.PrestarLibro("Libro Fantasma", 11111111));

            // Prueba C: Préstamo exitoso
            Console.WriteLine("Prueba C (Préstamo 1): " + biblioteca.PrestarLibro("El Aleph", 11111111));

            // Verificamos que el libro "El Aleph" desapareció de la biblioteca
            Console.WriteLine("\nInventario de Biblioteca tras el primer préstamo:");
            biblioteca.ListarLibros();

            // Prueba D: Tope de préstamos
            Console.WriteLine("\nForzando el tope de préstamos...");
            Console.WriteLine("Préstamo 2: " + biblioteca.PrestarLibro("Ficciones", 11111111));
            Console.WriteLine("Préstamo 3: " + biblioteca.PrestarLibro("Rayuela", 11111111));

            // Este cuarto préstamo debe ser rechazado
            Console.WriteLine("Préstamo 4 (Debe rebotar): " + biblioteca.PrestarLibro("1984", 11111111));

            // Console.WriteLine("\n--- 3. ESTADO FINAL DEL LECTOR ---");
            // biblioteca.MostrarEstadoLector("11111111");

            Console.ReadLine();
        }
    }
}