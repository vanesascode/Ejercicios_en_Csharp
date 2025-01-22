// 1. Crear un árbol binario de búsqueda de strings.
BinarySearchTree<string> arbol = new();

// 2. Construir el árbol (MANUALMENTE para este ejemplo).
arbol.Root = new BinaryTreeNode<string> { Data = "Manzana" };
arbol.Root.Left = new BinaryTreeNode<string> { Data = "Banana" };
arbol.Root.Right = new BinaryTreeNode<string> { Data = "Naranja" };
arbol.Root.Left.Left = new BinaryTreeNode<string> { Data = "Arándano" };
arbol.Root.Left.Right = new BinaryTreeNode<string> { Data = "Cereza" };

// 3. Usar el método Contains para buscar elementos.
Console.WriteLine($"¿El árbol contiene 'Manzana'?: {arbol.Contains("Manzana")}"); // Imprime: True
Console.WriteLine($"¿El árbol contiene 'Uva'?: {arbol.Contains("Uva")}");       // Imprime: False

Console.WriteLine(arbol.Root.Data); // Imprime: Manzana
Console.WriteLine(arbol.Root.Children[0]?.Data); // Imprime: Banana

// 4. Añadir elementos al árbol.
arbol.Add("Uva");
Console.WriteLine($"¿El árbol contiene 'Uva'?: {arbol.Contains("Uva")}");       // Imprime: True

Console.WriteLine(arbol.Root.Right.Right?.Data); // Imprime: Uva

/// <summary>
/// La restricción where T : IComparable indica que el tipo genérico T debe implementar la interfaz IComparable. 
/// Esta interfaz proporciona el método CompareTo necesario para comparar elementos del tipo T
/// </summary>
/// <typeparam name="T"></typeparam>
public class BinarySearchTree<T> : BinaryTree<T>
where T : IComparable
{
    // 'data' representa el elemento que se busca en el árbol.
    public bool Contains(T data)
    {
        // Se inicializa node con el nodo raíz del árbol binario de búsqueda (Root).
        BinaryTreeNode<T>? node = Root;

        // El bucle continuará iterando siempre que haya un nodo actual válido en el árbol de búsqueda.
        while (node != null)
        {
            // Se compara el elemento buscado (data) con el dato del nodo actual (node.Data).
            int result = data.CompareTo(node.Data);
            // == 0: data es igual a node.Data. Se ha encontrado el elemento en el árbol.
            if (result == 0) { return true; }
            // < 0: data es menor que node.Data. Se busca en el subárbol izquierdo.
            else if (result < 0) { node = node.Left; }
            // > 0: data es mayor que node.Data. Se busca en el subárbol derecho.
            else { node = node.Right; }
        }
        return false;
    }
    public void Add(T data)
    {
        // Se obtiene el nodo padre apropiado para el nuevo nodo.
        BinaryTreeNode<T>? parent = GetParentForNewNode(data);

        // Se crea un nuevo nodo con el dato especificado y se establece su padre.
        BinaryTreeNode<T> node = new()
        {
            Data = data,
            Parent = parent
        };
        // Se establece el nuevo nodo como hijo izquierdo o derecho del nodo padre.
        // Si parent es null, el nuevo nodo es la raíz del árbol.
        if (parent == null)
        {
            Root = node;
        }
        // Si data es menor que el dato del nodo padre, se agrega como hijo izquierdo. Si es mayor, se agrega como hijo derecho.
        else if (data.CompareTo(parent.Data) < 0)
        {
            parent.Left = node;
        }
        else
        {
            parent.Right = node;
        }
        // Se incrementa el contador de nodos en el árbol.
        Count++;
    }

    // Método auxiliar para obtener el nodo padre adecuado para un nuevo nodo con el dato especificado.
    private BinaryTreeNode<T>? GetParentForNewNode(T data)
    {
        // Se inicializa el nodo actual con la raíz del árbol y el nodo padre con null.
        BinaryTreeNode<T>? current = Root;
        BinaryTreeNode<T>? parent = null;

        // Se recorre el árbol hasta encontrar el nodo hoja donde se insertará el nuevo nodo.
        while (current != null)
        {
            // Se actualiza el nodo padre y se mueve al nodo izquierdo o derecho según sea necesario.
            parent = current;
            // Se compara el dato del nodo actual con el dato del nuevo nodo.
            int result = data.CompareTo(current.Data);
            // Si el dato es igual, se lanza una excepción ya que el nodo ya existe en el árbol.
            if (result == 0)
            {
                throw new ArgumentException($"The node {data} already exists.");
            }
            // Si el dato es menor, se mueve al subárbol izquierdo.
            else if (result < 0) { current = current.Left; }
            // Si el dato es mayor, se mueve al subárbol derecho.
            else { current = current.Right; }
        }
        return parent;
    }
}



/// Para cualquier nodo N en un BST:

//Todos los nodos en el subárbol izquierdo de N contienen valores menores que el valor de N.
//Todos los nodos en el subárbol derecho de N contienen valores mayores que el valor de N.
//Esta propiedad asegura que los datos estén organizados de una manera que facilita la búsqueda eficiente.




// Todo lo siguiente está explicado en el fichero BINARY_TREE: 

public class BinaryTree<T>
{
    public BinaryTreeNode<T>? Root { get; set; }
    public int Count { get; set; }
}

public class BinaryTreeNode<T>
: TreeNode<T>
{
    public new BinaryTreeNode<T>?[] Children { get; set; }
    = [null, null];

    public BinaryTreeNode<T>? Left
    {
        get { return Children[0]; }
        set { Children[0] = value; }
    }

    public BinaryTreeNode<T>? Right
    {
        get { return Children[1]; }
        set { Children[1] = value; }
    }
}

public class TreeNode<T>
{
    public T? Data { get; set; }
    public TreeNode<T>? Parent { get; set; }
    public List<TreeNode<T>> Children { get; set; } = [];
}