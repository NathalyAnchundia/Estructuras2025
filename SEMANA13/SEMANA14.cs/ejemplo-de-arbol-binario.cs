using System;
using System.Collections.Generic;

class Node
{
    public string Key;
    public Node Left, Right;
    
    public Node(string key)
    {
        Key = key;
        Left = Right = null;
    }
}

class BinaryTree
{
    private Node root;
    
    public BinaryTree()
    {
        root = null;
    }
    
    public void Insert(string key)
    {
        root = InsertRec(root, key);
    }
    
    private Node InsertRec(Node node, string key)
    {
        if (node == null)
            return new Node(key);
        
        if (string.Compare(key, node.Key) < 0)
            node.Left = InsertRec(node.Left, key);
        else
            node.Right = InsertRec(node.Right, key);
        
        return node;
    }
    
    public bool Search(string key)
    {
        return SearchRec(root, key);
    }
    
    private bool SearchRec(Node node, string key)
    {
        if (node == null)
            return false;
        if (node.Key == key)
            return true;
        
        return string.Compare(key, node.Key) < 0 ? 
            SearchRec(node.Left, key) : SearchRec(node.Right, key);
    }
    
    public void Delete(string key)
    {
        root = DeleteRec(root, key);
    }
    
    private Node DeleteRec(Node node, string key)
    {
        if (node == null)
            return node;
        
        if (string.Compare(key, node.Key) < 0)
            node.Left = DeleteRec(node.Left, key);
        else if (string.Compare(key, node.Key) > 0)
            node.Right = DeleteRec(node.Right, key);
        else
        {
            if (node.Left == null)
                return node.Right;
            else if (node.Right == null)
                return node.Left;
            
            Node temp = MinValueNode(node.Right);
            node.Key = temp.Key;
            node.Right = DeleteRec(node.Right, temp.Key);
        }
        return node;
    }
    
    private Node MinValueNode(Node node)
    {
        Node current = node;
        while (current.Left != null)
            current = current.Left;
        return current;
    }
    
    public void Inorder()
    {
        InorderRec(root);
        Console.WriteLine();
    }
    
    private void InorderRec(Node node)
    {
        if (node != null)
        {
            InorderRec(node.Left);
            Console.Write(node.Key + " ");
            InorderRec(node.Right);
        }
    }
    
    public void Preorder()
    {
        PreorderRec(root);
        Console.WriteLine();
    }
    
    private void PreorderRec(Node node)
    {
        if (node != null)
        {
            Console.Write(node.Key + " ");
            PreorderRec(node.Left);
            PreorderRec(node.Right);
        }
    }
    
    public void Postorder()
    {
        PostorderRec(root);
        Console.WriteLine();
    }
    
    private void PostorderRec(Node node)
    {
        if (node != null)
        {
            PostorderRec(node.Left);
            PostorderRec(node.Right);
            Console.Write(node.Key + " ");
        }
    }
}

class Program
{
    static void Main()
    {
        BinaryTree tree = new BinaryTree();
        Dictionary<string, string> catalogo = new Dictionary<string, string>
        {
            {"Libro1", ""},
            {"Libro2", ""},
            {"Revista1", ""}
        };
        
        // Insertar las publicaciones en el árbol binario
        foreach (var publicacion in catalogo.Keys)
        {
            tree.Insert(publicacion);
        }
        
        int opcion;
        do
        {
            Console.WriteLine("\nMenú de operaciones:");
            Console.WriteLine("1. Insertar dato");
            Console.WriteLine("2. Buscar dato");
            Console.WriteLine("3. Eliminar dato");
            Console.WriteLine("4. Recorrer Inorden");
            Console.WriteLine("5. Recorrer Preorden");
            Console.WriteLine("6. Recorrer Postorden");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcion))
                continue;
            
            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese un dato a insertar: ");
                    tree.Insert(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("Ingrese un dato a buscar: ");
                    Console.WriteLine(tree.Search(Console.ReadLine()) ? "Encontrado" : "No encontrado");
                    break;
                case 3:
                    Console.Write("Ingrese un dato a eliminar: ");
                    tree.Delete(Console.ReadLine());
                    break;
                case 4:
                    Console.Write("Inorden: ");
                    tree.Inorder();
                    break;
                case 5:
                    Console.Write("Preorden: ");
                    tree.Preorder();
                    break;
                case 6:
                    Console.Write("Postorden: ");
                    tree.Postorder();
                    break;
                case 7:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
        } while (opcion != 7);
    }
}
