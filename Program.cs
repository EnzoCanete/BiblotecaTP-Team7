namespace BibliotecaTP
{

    public class Biblioteca
    {

        private readonly List<Libro> Libros;
        private readonly List<Lector> LectoresRegistados;


        public Biblioteca()
        {
            this.Libros = [];
            this.LectoresRegistados = [];
        }

        private Libro BuscarLibro(string titulo)
        {
            /* Busca un libro a partir de un titulo, si el libro existe en la lista, lo retorna. */

            /* lo cambie por que me parecia mas legible. 
             * No se asusten por el warning, la version original provoca lo mismo.
             * podemos arreglarlo pero que retorne null le sirve a los otros métodos.
             */


            return Libros.Find(libro => libro.GetTitulo() == titulo);


            /* el metodo original es:
            Libro libroBuscado = null;

            int i = 0;

            while (i < libros.Count && !libros[i].GetTitulo().Equals(titulo))
            {
                i++;

            }
            if (i != libros.Count)
            {
                libroBuscado = libros[i];
            }
            return libroBuscado;

             */

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
                Libros.Add(libro);
                resultado = true;
            }
            return resultado;

        }

        public void ListarLibros()
        {
            /* Muestra uno por uno los libros de la lista */
            Console.WriteLine("Estos son los libros de la lista:");
            Console.WriteLine();

            foreach (var libro in Libros)
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
                Libros.Remove(libro);
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

    }

    public class Libro
    {
        private string Titulo;

        private string Autor;

        private string Editorial;

        public Libro(string titulo, string autor, string editorial)
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.Editorial = editorial;
        }

        public string GetTitulo()
        {
            return this.Titulo;
        }

        public override string ToString()
        {
            return "| Titulo:" + Titulo + " | Autor: " + Autor + " | Editorial: " + Editorial + " |";
        }
    }

    public class Lector
    {
        // esto tiene que tener un limite de tres libros
        public List<Libro> Libros;

        public string Nombre;

        private int dni;

        public int Dni
        {
            get => dni;
            private set
            {
                // los "_" solo son separadores visuales, no afectan al valor.
                // Limite inferior teniendo en cuenta a la actual persona mas longeva del pais.
                if (value < 5_000_000 || value > 99_000_999)
                {
                    throw new ArgumentException("DNI inválido.");
                }
            }
        }

        public Lector(string nombre, int dni)
        {
            this.Libros = new List<Libro>();
            Nombre = nombre;
            this.dni = dni;

        }

        public int GetDNI()
        {
            return this.dni;
        }

    }

    internal class Test
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new();
            cargarLibros(10);
            biblioteca.ListarLibros();
            // no deberia aparecer ningún mensaje por que ya existen los libros 1 y 2.
            cargarLibros(2);
            biblioteca.EliminarLibro("Libro5");

            /* agregado para cerciorarse que el libro5 se elimino */
            biblioteca.ListarLibros();

            // retorna true si el lector fue dado de alta.
            Console.WriteLine(biblioteca.AltaLector("enrique", 45897060));


            void cargarLibros(int cantidad)
            {
                bool pude;
                for (int i = 1; i <= cantidad; i++)
                {
                    pude = biblioteca.AgregarLibro("Libro" + i, "Autor" + i, "Editorial" + i);

                    if (pude)
                    {
                        Console.WriteLine("Libro" + i + " fue agregado");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}