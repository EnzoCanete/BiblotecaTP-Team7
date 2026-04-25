namespace TP1_Biblioteca
{
    internal class Biblioteca
    {
        // Atributos de colección
        private List<Libro> libros;
        private List<Lector> lectores; // Nueva colección agregada

        // Constructor
        public Biblioteca()
        {
            this.libros = new List<Libro>();
            this.lectores = new List<Lector>(); // Inicializamos la nueva lista
        }

        // --- MÉTODOS DE LIBROS (Ya los teníamos) ---
        private Libro buscarLibro(string titulo)
        {
            Libro libroBuscado = null;
            int i = 0;
            while (i < libros.Count && !libros[i].getTitulo().Equals(titulo))
                i++;

            if (i != libros.Count)
                libroBuscado = libros[i];

            return libroBuscado;
        }

        public bool agregarLibro(string titulo, string autor, string editorial)
        {
            bool resultado = false;
            Libro libro = buscarLibro(titulo);

            if (libro == null)
            {
                libro = new Libro(titulo, autor, editorial);
                libros.Add(libro);
                resultado = true;
            }
            return resultado;
        }

        public void listarLibros()
        {
            foreach (var libro in libros)
                Console.WriteLine(libro);
        }

        // --- NUEVOS MÉTODOS DE LECTORES Y PRÉSTAMOS ---

        // Búsqueda interna de lector por DNI
        private Lector buscarLector(string dni)
        {
            Lector lectorBuscado = null;
            int i = 0;
            while (i < lectores.Count && !lectores[i].getDni().Equals(dni))
                i++;

            if (i != lectores.Count)
                lectorBuscado = lectores[i];

            return lectorBuscado;
        }

        // Dar de alta un lector validando que no exista previamente
        public bool altaLector(string nombre, string dni)
        {
            bool resultado = false;
            Lector lector = buscarLector(dni);

            if (lector == null) // Si no lo encuentra, lo agrega
            {
                lector = new Lector(nombre, dni);
                lectores.Add(lector);
                resultado = true;
            }
            return resultado; // Retorna false si el DNI ya existía
        }

        // Método central del trabajo práctico
        public string prestarLibro(string titulo, string dni)
        {
            Lector lector = buscarLector(dni);
            if (lector == null)
            {
                return "LECTOR INEXISTENTE";
            }

            Libro libro = buscarLibro(titulo);
            if (libro == null)
            {
                return "LIBRO INEXISTENTE";
            }

            if (lector.cantidadLibrosPrestados() >= 3)
            {
                // Mantenemos el error ortográfico "ALCAZADO" porque así lo pide la consigna estrictamente
                return "TOPE DE PRESTAMO ALCAZADO";
            }

            // Lógica exitosa: Se quita de la biblioteca y se asigna al lector
            libros.Remove(libro);
            lector.agregarLibroPrestado(libro);

            return "PRESTAMO EXITOSO";
        }

        // Método extra útil para hacer pruebas y ver el estado del lector
        public void mostrarEstadoLector(string dni)
        {
            Lector lector = buscarLector(dni);
            if (lector != null)
                lector.listarLibrosPrestados();
        }
    }
}
