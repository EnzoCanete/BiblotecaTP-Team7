namespace BibliotecaTP_Team7
{
    public static class ListarLibros
    {
        public static void MostrarTabla(List<Libro> libros)
        {
            Console.WriteLine("+----------------------+----------------------+----------------------+");
            Console.WriteLine($"| {"Titulo",-20} | {"Autor",-20} | {"Editorial",-20} |");
            Console.WriteLine("+----------------------+----------------------+----------------------+");

            foreach (var libro in libros)
            {
                Console.WriteLine(libro); // usa ToString()
            }

            Console.WriteLine("+----------------------+----------------------+----------------------+");
        }
    }

}

