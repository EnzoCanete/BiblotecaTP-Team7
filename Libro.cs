using System;
using System.Collections.Generic;
using System.Text;

namespace TP1_Biblioteca
{
    public class Libro
    {
        // Atributos
        private string titulo;
        private string autor;
        private string editorial;

        // Constructor
        public Libro(string titulo, string autor, string editorial)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.editorial = editorial;
        }

        // Método necesario para que la biblioteca pueda buscar
        public string getTitulo()
        {
            return this.titulo;
        }

        // Sobreescribimos ToString() para que se imprima lindo en consola 
        public override string ToString()
        {
            return titulo + " - " + autor + " - " + editorial;
        }
    }
}
