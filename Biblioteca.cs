namespace BibliotecaTP_Team7
{
    public class Biblioteca
    {

        private readonly List<Libro> LibrosDisponibles;
        private readonly List<Lector> LectoresRegistados;


        public Biblioteca()
        {
            this.LibrosDisponibles = [];
            this.LectoresRegistados = [];
        }

        private Libro BuscarLibro(string titulo)
        {
            /* Busca un libro a partir de un titulo, si el libro existe en la lista, lo retorna. */
            return LibrosDisponibles.Find(libro => libro.GetTitulo() == titulo);

        }

        public bool AgregarLibro(string titulo, string autor, string editorial)
        {
            /* Revisa la lista y si el libro que se quiere agregar no forma parte de la misma, lo agrega al final. */

            bool resultado = false;

            Libro libro;
            libro = BuscarLibro(titulo);
            if (libro == null)
            {
                libro = new Libro(titulo, autor, editorial);
                LibrosDisponibles.Add(libro);
                resultado = true;
            }
            return resultado;

        }

        public void ListarLibros()
        {
            /* Muestra uno por uno los libros de la lista. */
            Console.WriteLine("Estos son los libros de la lista:");
            Console.WriteLine();

            foreach (var libro in LibrosDisponibles)
            {
                Console.WriteLine(libro);
                // solo para que el listado se vea un poco mejor.
                Console.WriteLine("---------------------------------------------------------");
            }
        }
        public bool EliminarLibro(string titulo)
        {
            /* Busca un libro a partir de un titulo, si lo encuentra, lo elimina de la lista.*/

            bool resultado = false;
            Libro libro;

            libro = BuscarLibro(titulo);
            if (libro != null)
            {
                LibrosDisponibles.Remove(libro);
                resultado = true;
            }
            return resultado;

        }

        private Lector BuscarLector(int dni)
        {
            return LectoresRegistados.Find(lector => lector.GetDNI() == dni);

        }


        public bool AltaLector(string nombreLector, int dniLector)
        {
            bool resultado = false;
            Lector lector;

            lector = BuscarLector(dniLector);
            if (lector == null)
            {
                lector = new Lector(nombreLector, dniLector);
                LectoresRegistados.Add(lector);
                resultado = true;
            }
            return resultado;

        }

        public string PrestarLibro(string titulo, int dniLector)
        {
            Libro LibroAPrestar = BuscarLibro(titulo);

            Lector lector = BuscarLector(dniLector);

            if (lector == null)
            {
                return "LECTOR INEXISTENTE";
            }

            if (LibroAPrestar == null)
            {
                return "LIBRO INEXISTENTE";
            }

            if (lector.CantidadLibrosEnPoder() == 3)
            {
                return "TOPE DE PRESTAMO ALCANZADO";
            }
            else
            {
                EliminarLibro(titulo);
                lector.AgregarLibro(LibroAPrestar);
                return "PRESTAMO EXITOSO";
            }

        }


    }

}
