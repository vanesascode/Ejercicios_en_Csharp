using static System.Runtime.InteropServices.JavaScript.JSType;

string[] names = ["Marcin", "Adam", "Martyna"];

DateTime[] dates = [new(1988, 11, 9), new(1995, 4, 25), new(2003, 7, 24)];

float[] temperatures = [36.6f, 39.1f, 35.9f];

Console.WriteLine($"{"Name",-8} {"Birth date",-50} {"Temp. [C]",20} -> Result");

for (int i = 0; i < names.Length; i++)
{
    string line = $"{names[i],-8} {dates[i],-50:dd.MMMM.yyyy} {temperatures[i],20:F1} -> {temperatures[i] switch
    {
        > 40.0f => "Very high",
        > 37.0f => "High",
        > 36.0f => "Normal",
        > 35.0f => "Low",
        _ => "Very low"
    }}";
    Console.WriteLine(line);
}

//////////////////////////////////////////////////////////////////////////////////////


int numero = PedirNumeroEntre1y3();

Console.WriteLine($"Tu número es el {numero}");

//switch (numero)
//{
//    case 1:
//        Console.WriteLine("Has introducido el número uno. Qué poco.");
//        break;
//    case 2:
//        Console.WriteLine("Has introducido el número dos. Bueno bueno.");
//        break;
//    case 3:
//        Console.WriteLine("Has introducido el número tres. Eso está mejor.");
//        break;
//    default:
//        Console.WriteLine("Número fuera del rango 1-3.");
//        break;
//}

string mensaje = numero switch
{
    1 => "Has introducido el número uno. Qué poco.",
    2 => "Has introducido el número dos. Bueno bueno.",
    3 => "Has introducido el número tres. Eso está mejor.",
    _ => "Número fuera del rango 1-3."
};

Console.WriteLine(mensaje);

Console.ReadKey();


static int PedirNumeroEntre1y3()
{
    int numero;
    string input;

    do
    {
        Console.Write("Ingrese un número del 1 al 3: ");
        input = Console.ReadLine();

        if (!int.TryParse(input, out numero))
        {
            Console.WriteLine("Error: Debe ingresar un número válido.");
        }
        else if (numero < 1 || numero > 3)
        {
            Console.WriteLine("Error: El número debe estar entre 1 y 3.");
        }
        else
        {
            return numero;
        }

    } while (true);
}