using System;

class TowersOfHanoi
{
    // Método para resolver el problema de las Torres de Hanoi
    public static void Solve(int n, char source, char target, char auxiliary)
    {
        // Caso base: si hay solo un disco, moverlo directamente
        if (n == 1)
        {
            Console.WriteLine($"Mover disco 1 de {source} a {target}");
            return;
        }

        // Mover n-1 discos de la fuente a la auxiliar
        Solve(n - 1, source, auxiliary, target);

        // Mover el disco restante de la fuente al objetivo
        Console.WriteLine($"Mover disco {n} de {source} a {target}");

        // Mover los n-1 discos de la auxiliar al objetivo
        Solve(n - 1, auxiliary, target, source);
    }

    // Función principal
    static void Main(string[] args)
    {
        int numberOfDisks = 3; // Cambia este valor para más discos
        Console.WriteLine($"Solución para {numberOfDisks} discos:");
        Solve(numberOfDisks, 'A', 'C', 'B'); // A, B y C son los nombres de las torres
    }
}