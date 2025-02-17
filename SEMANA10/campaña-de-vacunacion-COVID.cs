using System;
using System.Collections.Generic;
using System.Linq;

class Ciudadano
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public string Vacuna { get; set; } // Puede ser "Pfizer", "AstraZeneca" o null
}

class Program
{
    static void Main(string[] args)
    {
        // Generar un conjunto ficticio de 500 ciudadanos
        List<Ciudadano> ciudadanos = new List<Ciudadano>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add(new Ciudadano
            {
                ID = i,
                Nombre = $"Ciudadano_{i}",
                Vacuna = null // Inicialmente no vacunado
            });
        }

        // Asignar vacunas
        Random random = new Random();
        HashSet<int> indicesPfizer = new HashSet<int>();
        HashSet<int> indicesAstraZeneca = new HashSet<int>();

        // Asignar 75 ciudadanos a Pfizer
        while (indicesPfizer.Count < 75)
        {
            int index = random.Next(0, 500);
            if (ciudadanos[index].Vacuna == null) // Solo asignar si no está vacunado
            {
                ciudadanos[index].Vacuna = "Pfizer";
                indicesPfizer.Add(index);
            }
        }

        // Asignar 75 ciudadanos a AstraZeneca
        while (indicesAstraZeneca.Count < 75)
        {
            int index = random.Next(0, 500);
            if (ciudadanos[index].Vacuna == null) // Solo asignar si no está vacunado
            {
                ciudadanos[index].Vacuna = "AstraZeneca";
                indicesAstraZeneca.Add(index);
            }
        }

        // Listados requeridos
        var noVacunados = ciudadanos.Where(c => c.Vacuna == null).ToList();
        var vacunados = ciudadanos.Where(c => c.Vacuna != null).ToList();
        var soloPfizer = ciudadanos.Where(c => c.Vacuna == "Pfizer").ToList();
        var soloAstraZeneca = ciudadanos.Where(c => c.Vacuna == "AstraZeneca").ToList();

        // Resultados
        Console.WriteLine("Listado de ciudadanos que no se han vacunado:");
        foreach (var c in noVacunados)
        {
            Console.WriteLine(c.Nombre);
        }

        Console.WriteLine("\nListado de ciudadanos que han recibido las dos vacunas:");
        foreach (var c in vacunados)
        {
            Console.WriteLine(c.Nombre);
        }

        Console.WriteLine("\nListado de ciudadanos que solamente han recibido la vacuna de Pfizer:");
        foreach (var c in soloPfizer)
        {
            Console.WriteLine(c.Nombre);
        }

        Console.WriteLine("\nListado de ciudadanos que solamente han recibido la vacuna de AstraZeneca:");
        foreach (var c in soloAstraZeneca)
        {
            Console.WriteLine(c.Nombre);
        }
    }
}