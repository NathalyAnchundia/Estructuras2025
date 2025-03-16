using System;
using System.Collections.Generic;

class Program
{
    // Función recursiva para buscar un título en el catálogo
    static bool BuscarTitulo(List<string> catalogo, string titulo, int index)
    {
        // Caso base: si hemos recorrido toda la lista
        if (index >= catalogo.Count)
            return false;

        // Caso recursivo: si encontramos el título
        if (catalogo[index].ToLower() == titulo.ToLower())
            return true;

        // Llamada recursiva con el siguiente índice
        return BuscarTitulo(catalogo, titulo, index + 1);
    }

    static void Main()
    {
        // Crear catálogo de revistas
        List<string> catalogo = new List<string>
        {
            "Revista de Ciencia", 
            "Revista de Tecnología", 
            "Revista de Historia", 
            "Revista de Arte", 
            "Revista de Literatura", 
            "Revista de Medicina", 
            "Revista de Astronomía", 
            "Revista de Psicología", 
            "Revista de Educación", 
            "Revista de Economía"
        };

        // Mostrar el menú
        Console.WriteLine("Catálogo de Revistas:");
        Console.WriteLine("1. Buscar un título");

        // Leer la opción del usuario
        Console.Write("Ingrese el título a buscar: ");
        string tituloBuscar = Console.ReadLine();

        // Buscar el título en el catálogo utilizando la función recursiva
        bool encontrado = BuscarTitulo(catalogo, tituloBuscar, 0);

        // Mostrar el resultado de la búsqueda
        if (encontrado)
        {
            Console.WriteLine("Título encontrado.");
        }
        else
        {
            Console.WriteLine("Título no encontrado.");
        }
    }
}