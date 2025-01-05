Pedido pedido = new Pedido();

pedido.AgregarProducto(new Producto { Nombre = "Producto 1", Precio = 10.99m });
pedido.AgregarProducto(new Producto { Nombre = "Producto 2", Precio = 5.99m });
pedido.AgregarProducto(new Producto { Nombre = "Producto 3", Precio = 7.99m });

foreach (Producto producto in pedido.Productos)
{
    Console.WriteLine($"Nombre: {producto.Nombre}, Precio: {producto.Precio}");
}

public class Pedido
{
    private List<Producto> productos;

    public Pedido()
    {
        productos = new List<Producto>();
    }

    //IEnumerable es una interfaz que se utiliza para
    //definir una colección que se puede iterar, pero no proporciona
    //métodos para agregar o eliminar elementos de la colección.

    // forma tradicional de definir una propiedad con get. Es como un metodo, solo que no tiene el ():
    public IEnumerable<Producto> Productos 
    {
        get { return productos; }
    }

    //esta es la unica forma de añadir productos a la lista, tocando el field privado. 
    //Como queremos protegerlo, lo hacemos privado, y solo lo devolvemos para iterar a traves del "metodo"
    // get de la propiedad Productos, que es Inemurable.
    public void AgregarProducto(Producto producto)
    {
        productos.Add(producto);
    }
}

public class Producto
{
    //el compilador de C# convierte la propiedad
    //en un campo privado y dos métodos públicos: uno
    //para obtener el valor (get) y otro para establecer el valor (set)

    // forma a partir de c#6.0 de definir una propiedad con get o  set:
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
}