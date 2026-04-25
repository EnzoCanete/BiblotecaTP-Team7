namespace TP1_Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();

            Console.WriteLine("--- 1. CARGA INICIAL ---");
            biblioteca.agregarLibro("El Aleph", "Borges", "Sur");
            biblioteca.agregarLibro("Ficciones", "Borges", "Sur");
            biblioteca.agregarLibro("Rayuela", "Cortazar", "Sudamericana");
            biblioteca.agregarLibro("1984", "Orwell", "Seix Barral");

            // Prueba de alta de lector exitosa y fallida
            Console.WriteLine(biblioteca.altaLector("Emanuel", "11111111") ? "Lector Emanuel agregado." : "Error: DNI duplicado.");
            Console.WriteLine(biblioteca.altaLector("Juan", "11111111") ? "Lector Juan agregado." : "Error: DNI duplicado."); // Debe fallar
            Console.WriteLine(biblioteca.altaLector("Maria", "22222222") ? "Lector Maria agregada.\n" : "Error: DNI duplicado.\n");

            Console.WriteLine("--- 2. LOTE DE PRUEBAS DE PRESTAMOS ---");

            // Prueba A: Lector que no existe
            Console.WriteLine("Prueba A: " + biblioteca.prestarLibro("El Aleph", "99999999"));

            // Prueba B: Libro que no existe
            Console.WriteLine("Prueba B: " + biblioteca.prestarLibro("Libro Fantasma", "11111111"));

            // Prueba C: Préstamo exitoso
            Console.WriteLine("Prueba C (Préstamo 1): " + biblioteca.prestarLibro("El Aleph", "11111111"));

            // Verificamos que el libro "El Aleph" desapareció de la biblioteca
            Console.WriteLine("\nInventario de Biblioteca tras el primer préstamo:");
            biblioteca.listarLibros();

            // Prueba D: Tope de préstamos
            Console.WriteLine("\nForzando el tope de préstamos...");
            Console.WriteLine("Préstamo 2: " + biblioteca.prestarLibro("Ficciones", "11111111"));
            Console.WriteLine("Préstamo 3: " + biblioteca.prestarLibro("Rayuela", "11111111"));

            // Este cuarto préstamo debe ser rechazado
            Console.WriteLine("Préstamo 4 (Debe rebotar): " + biblioteca.prestarLibro("1984", "11111111"));

            Console.WriteLine("\n--- 3. ESTADO FINAL DEL LECTOR ---");
            biblioteca.mostrarEstadoLector("11111111");

            Console.ReadLine();
        }
    }
}