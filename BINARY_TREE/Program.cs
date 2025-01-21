BinaryTree<string> tree = GetTree(); // Crea y obtiene el árbol binario
BinaryTreeNode<string>? node = tree.Root; // Inicia el nodo actual en la raíz

while (node != null) // Bucle principal: se repite mientras haya nodo actual
{
    if (node.Left != null && node.Right != null) // Si el nodo actual tiene dos hijos (izquierdo y derecho)
    {
        Console.WriteLine(node.Data); // Imprime la pregunta del nodo actual
        node = Console.ReadKey(true).Key switch // Lee la pulsación de tecla del usuario (ocultando la pulsación)
        {
            ConsoleKey.Y => node.Left, // Si pulsa Y, asigna el nodo hijo izquierdo como nodo actual
            ConsoleKey.N => node.Right, // Si pulsa N, asigna el nodo hijo derecho como nodo actual
            _ => node // Si pulsa otra tecla, mantiene el nodo actual sin cambios
        };
    }
    else // Si el nodo actual no tiene dos hijos (es un nodo hoja)
    {
        Console.WriteLine(node.Data); // Imprime la información del nodo hoja (la decisión final)
        node = null; // Finaliza el bucle al no haber siguiente nodo
    }
}

/// <summary>
/// Método que crea y devuelve un árbol binario de cadenas representando un árbol de decisión para un proceso de selección.
/// </summary>
/// <returns>Un objeto BinaryTree<string> que representa el árbol de decisión.</returns>
BinaryTree<string> GetTree()
{
    // Crea una nueva instancia del árbol binario.
    BinaryTree<string> tree = new();

    // Crea el nodo raíz del árbol.
    tree.Root = new BinaryTreeNode<string>()
    {
        // Asigna el dato al nodo raíz (la primera pregunta).
        Data = "Do you have an experience in app development ? ",
        // Crea el array de hijos del nodo raíz.
        Children =
        [
            // Crea el primer hijo (rama izquierda - "Sí" a la primera pregunta).
            new BinaryTreeNode<string>()
            {
                Data = "Have you worked as a developer for 5 + years ? ",
                Children =
                [
                    new() { Data = "Apply as a senior developer" },
                    new() { Data = "Apply as a middle developer" }
                ]
            },
             // Crea el segundo hijo (rama derecha - "No" a la primera pregunta).
            new BinaryTreeNode<string>()
            {
                Data = "Have you completed a university?",
                Children =
                [
                    new() { Data = "Apply as a junior developer" },
                    new BinaryTreeNode<string>()
                    {
                        Data = "Will you find some time during the semester?",
                        Children =
                        [
                            new() { Data = "Apply for long-time internship" },
                            new() { Data = "Apply for summer internship" }
                        ]
                    }
                ]
            }
        ]
    };
    //Establece la cantidad de nodos del arbol
    tree.Count = 9;
    return tree;
}

/// <summary>
/// La clase BinaryTree<T> representa un árbol binario.
/// </summary>
/// <typeparam name="T">El tipo de datos almacenados en el árbol.</typeparam>
public class BinaryTree<T>
{

    // Obtiene o establece la raíz del árbol. Si la raíz es null, el árbol está vacío.
    public BinaryTreeNode<T>? Root { get; set; }
    // Obtiene o establece el número de nodos en el árbol.
    public int Count { get; set; }
}

/// <summary>
/// Nodo de un árbol binario. El nodo tiene dos hijos: Left y Right. BinaryTreeNode hereda de la clase TreeNode<T> 
/// </summary>
/// <typeparam name="T">El tipo de dato almacenado en el nodo.</typeparam>
public class BinaryTreeNode<T>
: TreeNode<T>
{
    // Almacena los hijos izquierdo (índice 0) y derecho (índice 1) del nodo.
    public new BinaryTreeNode<T>?[] Children { get; set; }
    = [null, null];

    /// <summary>
    /// Obtiene o establece el hijo izquierdo del nodo.
    /// </summary>
    /// <remarks>Puede ser null si el nodo no tiene hijo izquierdo.</remarks>
    public BinaryTreeNode<T>? Left
    {
        get { return Children[0]; }
        set { Children[0] = value; }
    }

    /// <summary>
    /// Obtiene o establece el hijo derecho del nodo.
    /// </summary>
    /// <remarks>Puede ser null si el nodo no tiene hijo derecho.</remarks>
    public BinaryTreeNode<T>? Right
    {
        get { return Children[1]; }
        set { Children[1] = value; }
    }
}

/// <summary>
/// Nodo de un árbol genérico
/// </summary>
/// <typeparam name="T">El tipo de dato almacenado en el nodo.</typeparam>
public class TreeNode<T>
{
    // El ? (nullable) indica que la propiedad puede contener un valor nulo.
    public T? Data { get; set; }
    public TreeNode<T>? Parent { get; set; }
    public List<TreeNode<T>> Children { get; set; } = [];
}