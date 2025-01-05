
using System.Globalization;

CultureInfo culture = new("es");

// ARRAYS: 

string[] months = new string[12];

string[] days = new string[12];

for (int month = 1; month <= 12; month++)
{
    DateTime firstDay = new(DateTime.Now.Year, month, 1);
    string name = firstDay.ToString("MMMM", culture);
    months[month - 1] = name;
}

for (int day = 1; day <=7; day++)
{
    DateTime weekDay = new(DateTime.Now.Year, 1, day);
    string name = weekDay.ToString("dddd", culture);
    days[day - 1] = name;
}
foreach (string m in months)
{
    Console.WriteLine(m);
}

foreach (string d in days)
{
    Console.WriteLine(d);
}

// LISTS: 

List<string> meses = Enumerable.Range(1, 12)
    .Select(m => new DateTime(DateTime.Now.Year, m, 1).ToString("MMMM", culture))
    .ToList();

List<string> dias = Enumerable.Range(1, 7)
    .Select(d => new DateTime(DateTime.Now.Year, 1, d).ToString("dddd", culture))
    .ToList();

Console.WriteLine(string.Join(Environment.NewLine, meses));
Console.WriteLine(string.Join(Environment.NewLine, dias));

Console.ReadKey();



//En general, los arrays (string[]) son más eficientes que las listas (List<string>) en términos de rendimiento y uso de memoria.

//Aquí hay algunas razones por las que los arrays son más eficientes:

//Uso de memoria: Los arrays tienen un tamaño fijo y no requieren memoria adicional para almacenar metadatos, como la
//longitud de la lista. Las listas, por otro lado, requieren memoria adicional para almacenar la longitud de la lista y otros metadatos.
//Acceso a elementos: Los arrays permiten acceso directo a los elementos mediante su índice, lo que es más rápido que el acceso
//a los elementos en una lista, que requiere una búsqueda lineal.
//Inserción y eliminación de elementos: Los arrays no permiten la inserción o eliminación de elementos en medio de la secuencia,
//lo que reduce la sobrecarga de memoria y tiempo. Las listas, por otro lado, permiten la inserción y eliminación de elementos
//en cualquier posición, lo que puede requerir reorganización de la memoria y tiempo adicional.

//Sin embargo, las listas tienen algunas ventajas sobre los arrays:

//Flexibilidad: Las listas pueden crecer o disminuir dinámicamente, lo que las hace más flexibles que los arrays.
//Métodos adicionales: Las listas proporcionan métodos adicionales para manipular la secuencia, como Add, Remove, Sort, etc.
//En resumen, si necesitas trabajar con una secuencia de elementos de tamaño fijo y no necesitas realizar operaciones de
//inserción o eliminación, los arrays pueden ser una mejor opción. Sin embargo, si necesitas trabajar con una secuencia de
//elementos de tamaño variable y necesitas realizar operaciones de inserción o eliminación, las listas pueden ser una mejor opción.