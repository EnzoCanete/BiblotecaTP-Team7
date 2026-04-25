namespace BibliotecaTP_Team7
{
    public class Libro
    {
        private readonly string Titulo;

        private readonly string Autor;

        private readonly string Editorial;

        // Agregar validaciones para estos campos. solo letras.
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

}
