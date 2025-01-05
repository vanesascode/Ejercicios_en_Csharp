//Las listas doblemente enlazadas (en inglés, doubly linked lists)
//son una estructura de datos lineal en la que cada elemento, llamado nodo,
//contiene dos punteros o referencias: uno al nodo siguiente en la secuencia
//y otro al nodo anterior. Esta característica las diferencia de las listas
//enlazadas simples, que solo tienen un puntero al siguiente nodo.


Page p1 = new("Welcome to (...)");
Page p2 = new("While reading (...)");
Page p3 = new("As a developer (...)");
Page p4 = new("In the previous (...)");
Page p5 = new("So far, you (...)");
Page p6 = new("The current (...)");

Console.WriteLine(p1);

LinkedList<Page> pages = new();
pages.AddLast(p2);
LinkedListNode<Page> n4 = pages.AddLast(p4);
pages.AddLast(p6);
pages.AddFirst(p1);
pages.AddBefore(n4, p3);
pages.AddAfter(n4, p5);

LinkedListNode<Page> c = pages.First!;
int number = 1;
while (c != null)
{
    Console.Clear();

    string page = $"- {number} -";

    //Esta línea calcula el número de espacios necesarios para centrar el
    //encabezado de la página dentro de un ancho total de 90 caracteres. Resta
    //la longitud de la cadena page de 90 y luego divide por 2.
    int spaces = (90 - page.Length) / 2;

    //page.PadLeft(spaces + page.Length) utiliza el método PadLeft para agregar
    //espacios al lado izquierdo de la cadena page hasta que alcance una longitud total
    //de spaces + page.Length. Esto asegura que el encabezado de la página esté centrado.
    Console.WriteLine(page.PadLeft(spaces + page.Length));

    Console.WriteLine();

    //c.Value se refiere a un objeto de tipo Page. Y como Page se
    //define como un record que tiene un constructor posicional con un
    //parámetro string Content, entonces c.Value.Content accede a la
    //propiedad Content de ese objeto Page.
    string content = c.Value.Content;

    for (int i = 0; i < content.Length; i += 90)
    {
        string line = content[i..];
        line = line.Length > 90 ? line[..90] : line;
        Console.WriteLine(line.Trim());
    }

    Console.WriteLine($"\nQuote from (...)");

    Console.Write(c.Previous != null
    ? "< PREV [P]" : GetSpaces(14));

    Console.Write(c.Next != null
    //PadLeft() es un método de la clase string
    //que añade espacios en blanco al principio de una cadena hasta
    //que alcanza una longitud total especificada.
    ? "[N] NEXT >".PadLeft(76) : string.Empty);

    Console.WriteLine();

    //Console.ReadKey(true) el true hace que la letra tecleada no se muestre en consola
    //Key: Es un valor de la enumeración ConsoleKey que representa la tecla presionada (por ejemplo, ConsoleKey.A, ConsoleKey.Enter, ConsoleKey.UpArrow, etc.).
    ConsoleKey key = Console.ReadKey(true).Key;

    if (key == ConsoleKey.N && c.Next != null)
    {
        c = c.Next;
        number++;
    }
    else if (key == ConsoleKey.P && c.Previous != null)
    {
        c = c.Previous;
        number--;
    }
}

//null es el separador, con lo cual no hay. 

//Enumerable.Range() es un método de LINQ que genera una secuencia de enteros.
//El primer argumento (0) es el valor inicial de la secuencia.
//El segundo argumento (number) es la cantidad de números que se generarán.

//Select() aquí es tomar cada número de la secuencia generada por Enumerable.Range() y
//transformarlo en una cadena que contiene un espacio en blanco.

//Finalmente, string.Join toma la secuencia de espacios generada por Select()
//y las concatena en una sola cadena sin ningún separador.
string GetSpaces(int number) => string.Join(
null, Enumerable.Range(0, number).Select(n => " "));

public record Page(string Content);