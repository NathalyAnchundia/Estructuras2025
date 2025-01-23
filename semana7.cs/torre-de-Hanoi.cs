using System;
using System.Collections.Generic;

class Program
{
    // Función para verificar si una expresión está balanceada
    static bool IsBalanced(string expression)
    {
        // Crear una pila para almacenar los caracteres de apertura
        Stack<char> stack = new Stack<char>();

        // Recorrer cada carácter en la expresión
        foreach (char c in expression)
        {
            // Si es un carácter de apertura, lo apilamos
            if (c == '{' || c == '(' || c == '[')
            {
                stack.Push(c);
            }
            // Si es un carácter de cierre, verificamos la pila
            else if (c == '}' || c == ')' || c == ']')
            {
                // Si la pila está vacía, no hay un par correspondiente
                if (stack.Count == 0)
                {
                    return false;
                }

                // Sacar el carácter de apertura de la pila
                char openChar = stack.Pop();

                // Verificar si el carácter de cierre corresponde al de apertura
                if (!IsMatchingPair(openChar, c))
                {
                    return false;
                }
            }
        }

        // Si la pila está vacía al final, la expresión está balanceada
        return stack.Count == 0;
    }

    // Función para verificar si los caracteres de apertura y cierre coinciden
    static bool IsMatchingPair(char openChar, char closeChar)
    {
        return (openChar == '{' && closeChar == '}') ||
               (openChar == '(' && closeChar == ')') ||
               (openChar == '[' && closeChar == ']');
    }

    // Función principal
    static void Main(string[] args)
    {
        string expression = "{7+(8*5)-[(9-7)+(4+1)]}";
        if (IsBalanced(expression))
        {
            Console.WriteLine("La expresión está balanceada.");
        }
        else
        {
            Console.WriteLine("La expresión no está balanceada.");
        }
    }
}