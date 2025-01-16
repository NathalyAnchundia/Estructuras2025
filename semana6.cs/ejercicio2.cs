using System;
using System.Collections.Generic;

class Nodo
{
    public int Valor;
    public Nodo Siguiente;

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

class ListaEnlazada
{
    private Nodo cabeza;

    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
    }

    public void EliminarFueraDeRango(int min, int max)
    {
        while (cabeza != null && (cabeza.Valor < min || cabeza.Valor > max))
        {
            cabeza = cabeza.Siguiente;
        }

        Nodo actual = cabeza;
        while (actual != null && actual.Siguiente != null)
        {
            if (actual.Siguiente.Valor < min || actual.Siguiente.Valor > max)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
            }
            else
            {
                actual = actual.Siguiente;
            }
        }
    }

    public void Mostrar()
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Random random = new Random();
        ListaEnlazada lista = new ListaEnlazada();

        // Generar 50 números aleatorios entre 1 y 999
        for (int i = 0; i < 50; i++)
        {
            int numeroAleatorio = random.Next(1, 1000);
            lista.Agregar(numeroAleatorio);
        }

        Console.WriteLine("Lista original:");
        lista.Mostrar();

        // Leer el rango de valores
        Console.Write("Ingrese el valor mínimo del rango: ");
        int min = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el valor máximo del rango: ");
        int max = int.Parse(Console.ReadLine());

        // Eliminar nodos fuera del rango
        lista.EliminarFueraDeRango(min, max);

        Console.WriteLine($"Lista después de eliminar nodos fuera del rango [{min}, {max}]:");
        lista.Mostrar();
    }
}