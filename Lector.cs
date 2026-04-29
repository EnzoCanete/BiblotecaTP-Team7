namespace BibliotecaTP_Team7
{
    public class Lector
    {
        private List<Libro> LibrosEnPoder;

        // Agregar validación. Solo letras.
        public string Nombre { get; set; }

        public string Dni { get; set; }

        public Lector(string nombre, string dni)
        {
            this.LibrosEnPoder = [];
            Nombre = nombre;
            Dni = dni;


        }

        public string GetDNI()
        {
            return this.Dni;
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
                ListarLibros.MostrarTabla(LibrosEnPoder);
            }
        }
    }
}


