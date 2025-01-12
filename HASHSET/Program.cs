//COUPONS

//HashSet<int> usedCoupons = [];
//do
//{
//    Console.Write("Enter the number: ");
//    string number = Console.ReadLine() ?? string.Empty;
//    if (!int.TryParse(number, out int coupon)) { break; }
//    if (usedCoupons.Contains(coupon))
//    {
//        Console.WriteLine("Already used.");
//    }
//    else
//    {
//        usedCoupons.Add(coupon);
//        Console.WriteLine("Thank you!");
//    }
//}
//while (true);

//swimming pools

using System.Drawing;

Random random = new();

Dictionary<PoolTypeEnum, HashSet<int>> tickets = new()
{
{ PoolTypeEnum.Recreation, new() },
{ PoolTypeEnum.Competition, new() },
{ PoolTypeEnum.Thermal, new() },
{ PoolTypeEnum.Kids, new() }
};

for (int i = 1; i < 100; i++)
{
    foreach ((PoolTypeEnum p, HashSet<int> t) in tickets)
    {
        // Si el número aleatorio es 1, entonces se agrega el valor actual de i al conjunto t
        if (random.Next(2) == 1)
        {
            t.Add(i);
            Console.WriteLine($"{p}: {i}");
            //Recreation: 1
            //Kids: 1
            //Recreation: 2
            //Competition: 2
            //Recreation: 4
            //Thermal: 4
            //Kids: 4
            //Recreation: 5
            //Competition: 5
            //Kids: 5
            //Recreation: 6
            //Thermal: 6
            //Competition: 9 (Algún i se lo salta, por eso no hay 100 normalmente)
            //Recreation: 10
            //Competition: 10
            //Thermal: 10
            //Recreation: 11
            //Kids: 11
            //Recreation: 12
            //etc.
        }
    }
}

Console.WriteLine("Number of visitors by a pool type:");
foreach ((PoolTypeEnum p, HashSet<int> t) in tickets)
{
    Console.WriteLine($"- {p}: {t.Count}");
}

PoolTypeEnum maxVisitors = tickets
.OrderByDescending(t => t.Value.Count)
.Select(t => t.Key)
.FirstOrDefault();
Console.WriteLine($"{maxVisitors} - the most popular.");


//nuevo conjunto de enteros (HashSet<int>) llamado any y lo inicializa con los elementos
//de la lista tickets correspondiente a la clave PoolTypeEnum.Recreation
HashSet<int> any = new(tickets[PoolTypeEnum.Recreation]);
//utiliza el método UnionWith para agregar a any los elementos de las listas tickets
//correspondientes a las claves PoolTypeEnum.Competition, PoolTypeEnum.Thermal y PoolTypeEnum.Kids
any.UnionWith(tickets[PoolTypeEnum.Competition]);
any.UnionWith(tickets[PoolTypeEnum.Thermal]);
any.UnionWith(tickets[PoolTypeEnum.Kids]);
Console.WriteLine($"{any.Count} people visited at least one pool.");

HashSet<int> all = new(tickets[PoolTypeEnum.Recreation]);
all.IntersectWith(tickets[PoolTypeEnum.Competition]);
all.IntersectWith(tickets[PoolTypeEnum.Thermal]);
all.IntersectWith(tickets[PoolTypeEnum.Kids]);
Console.WriteLine($"{all.Count} people visited all pools.");
//si 1 aparece en todas las listas, entonces se cuenta como que visitó todas las piscinas
//si 2 aparece en todas las listas, entonces se cuenta como que visitó todas las piscinas
//etc

enum PoolTypeEnum
{
    Recreation,
    Competition,
    Thermal,
    Kids
};

