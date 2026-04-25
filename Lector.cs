namespace BibliotecaTP_Team7
{
    public class Lector
    {
        private List<Libro> LibrosEnPoder;

        // Agregar validación. Solo letras.
        public string Nombre { get; set; }

        private int dni;

        public int Dni
        {
            get => dni;
            private set
            {
                // los "_" solo son separadores visuales, no afectan al valor.
                if (value < 1_000_000 || value > 99_999_999)
                {
                    throw new ArgumentException("DNI inválido.");
                }
                dni = value;
            }
        }

        public Lector(string nombre, int dni)
        {
            this.LibrosEnPoder = [];
            Nombre = nombre;
            Dni = dni;


        }

        public int GetDNI()
        {
            return this.dni;
        }

        public void AgregarLibro(Libro libro)
        {

            this.LibrosEnPoder.Add(libro);
        }

        public int CantidadLibrosEnPoder()

        {
            return this.LibrosEnPoder.Count;
        }

        public void ListarLibrosEnPoder()
        {
            Console.WriteLine(" Libros en poder de " + this.Nombre + ": ");

            if (CantidadLibrosEnPoder() == 0)
            {
                Console.WriteLine("- no tiene libros en préstamo.");
            }
            else
            {
                foreach (var libro in LibrosEnPoder)
                {
                    Console.WriteLine("- " + libro.GetTitulo());
                }
            }
        }
    }
}


