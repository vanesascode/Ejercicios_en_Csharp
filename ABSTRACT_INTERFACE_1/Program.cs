IPedido pedido = new PedidoOnline("Juan", 100, new PagoTarjeta());
PedidoService pedidoService = new PedidoService(pedido);
pedidoService.ProcesarPedido();

public interface IPedido
{
    void ProcesarPedido();
    void CancelarPedido();
}

public interface IPago
{
    void RealizarPago(decimal total);
}

// se utiliza como base para otras clases que heredan de ella
public abstract class Pedido : IPedido
{
    //definir cliente y total en la clase Pedido permite crear una
    //base común para todos los tipos de pedidos, evitar la duplicación
    //de código y crear una jerarquía de clases más clara y organizada.
    protected string cliente;
    protected decimal total;

    public Pedido(string cliente, decimal total)
    {
        this.cliente = cliente;
        this.total = total;
    }

    public abstract void ProcesarPedido();
    public abstract void CancelarPedido();

    public void ImprimirPedido()
    {
        Console.WriteLine($"Pedido de {cliente} por un total de {total}");
    }
}

public class PedidoOnline : Pedido
{
    private readonly IPago pago;

    // como la clase abstracta tiene un constructor, debemos pasarle los fields tanto en los 
    //parametros como en la parte de base: 
    public PedidoOnline(string cliente, decimal total, IPago pago) : base(cliente, total)
    {
        this.pago = pago;
    }

    public override void ProcesarPedido()
    {
        Console.WriteLine("Procesando pedido online...");
        pago.RealizarPago(total);
    }

    public override void CancelarPedido()
    {
        Console.WriteLine("Cancelando pedido online...");
    }
}


public class PagoTarjeta : IPago
{
    public void RealizarPago(decimal total)
    {
        Console.WriteLine($"Realizando pago con tarjeta por un total de {total}");
    }
}

public class PagoEfectivo : IPago
{
    public void RealizarPago(decimal total)
    {
        Console.WriteLine($"Realizando pago en efectivo por un total de {total}");
    }
}

public class PedidoService
{
    private readonly IPedido pedido;

    public PedidoService(IPedido pedido)
    {
        this.pedido = pedido;
    }

    public void ProcesarPedido()
    {
        pedido.ProcesarPedido();
    }

    public void CancelarPedido()
    {
        pedido.CancelarPedido();
    }
}