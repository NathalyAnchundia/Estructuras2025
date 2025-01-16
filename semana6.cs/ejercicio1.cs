using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<double> listaPrincipal = new List<double>();
        
        // Cargar datos en la lista principal
        Console.Write("Ingrese la cantidad de elementos para la lista: ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Por favor, ingrese un número válido mayor que cero: ");
        }

        for (int i = 0; i < n; i++)
        {
            double elemento;
            while (true)
            {
                Console.Write($"Ingrese el elemento {i + 1} (número real): ");
                if (double.TryParse(Console.ReadLine(), out elemento))
                {
                    listaPrincipal.Add(elemento);
                    break;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número real.");
                }
            }
        }

        // Calcular el promedio
        double promedio = CalcularPromedio(listaPrincipal);

        // Separar los datos
        List<double> menoresIguales = new List<double>();
        List<double> mayores = new List<double>();

        foreach (double numero in listaPrincipal)
        {
            if (numero <= promedio)
            {
                menoresIguales.Add(numero);
            }
            else
            {
                mayores.Add(numero);
            }
        }

        // Mostrar resultados
        Console.WriteLine("\nResultados:");
        Console.WriteLine("a. Los datos cargados en la lista principal: " + string.Join(", ", listaPrincipal));
        Console.WriteLine("b. El promedio: " + promedio);
        Console.WriteLine("c. Los datos cuyo valor sea igual o menor al promedio: " + string.Join(", ", menoresIguales));
        Console.WriteLine("d. Los datos que sean mayores al promedio: " + string.Join(", ", mayores));
    }

    static double CalcularPromedio(List<double> lista)
    {
        if (lista.Count == 0)
            return 0;
        double suma = 0;
        foreach (double numero in lista)
        {
            suma += numero;
        }
        return suma / lista.Count;
    }
}