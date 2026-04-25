using System;
using System.Collections.Generic;
using System.Text;

namespace TP1_Biblioteca
{
    public class Lector
    {
        // Atributos obligatorios
        private string nombre;
        private string dni;

        // Colección de libros que el lector tiene en su poder
        private List<Libro> librosPrestados;

        // Constructor
        public Lector(string nombre, string dni)
        {
            this.nombre = nombre;
            this.dni = dni;
            // Inicializamos la lista vacía al crear el lector
            this.librosPrestados = new List<Libro>();
        }

        // Métodos para acceder a los datos (Getters)
        public string getDni()
        {
            return this.dni;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        // Métodos para manejar los préstamos del lector
        public int cantidadLibrosPrestados()
        {
            return this.librosPrestados.Count;
        }

        public void agregarLibroPrestado(Libro libro)
        {
            this.librosPrestados.Add(libro);
        }

        public void listarLibrosPrestados()
        {
            Console.WriteLine("Libros en poder de " + this.nombre + ":");
            if (librosPrestados.Count == 0)
            {
                Console.WriteLine("- No tiene libros en préstamo.");
            }
            else
            {
                foreach (var libro in librosPrestados)
                    Console.WriteLine("- " + libro.getTitulo());
            }
        }
    }
}
