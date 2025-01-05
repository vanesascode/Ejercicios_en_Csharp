using System.Globalization;
using System.Text;

//ARRAYS: 


int[] numbers = new int[3];
Console.WriteLine(numbers[0]);
Console.WriteLine(numbers[1]);
Console.WriteLine(numbers[2]);

Console.WriteLine(Environment.NewLine);

////////////////////////////////////////////////////////////

//int[] myNumbers = new[] { 2, 3, 5, 7 };
int[] myNumbers = [ 2, 3, 5, 7 ];

var sum = 0;
for (int i = 0; i < myNumbers.Length; i++)
{
    sum += myNumbers[i];
    Console.WriteLine(myNumbers[i]);
}
Console.WriteLine(sum);

var amount = myNumbers.GetLength(0);
Console.WriteLine("length " + amount);

Console.WriteLine(Environment.NewLine);

////////////////////////////////////////////////////////////

Console.WriteLine(Environment.NewLine);

//string[] words = new string[] { "hola", "capricornio" };
string[] words = ["hola", "capricornio"];
int length = 5;

foreach (var word in words)
{
    if (length < word.Length)
    {
        Console.WriteLine("true");
    }
    else
    {
        Console.WriteLine("false");
    }
}


// MULTIDIMENSIONAL ARRAYS - Matrices

// Sin definir (y definiendo después)

char[,] letters = new char[2, 3];

letters[0, 0] = 'a';
letters[0, 1] = 'b';
letters[0, 2] = 'c';
letters[1, 0] = 'd';
letters[1, 1] = 'e';
letters[1, 2] = 'f';

// Definiendo a la vez: 

var letters2 = new char[,] { { 'a', 'b', 'c' }, { 'd', 'e', 'f' } }; 


var height = letters.GetLength(0); // longitud de las filas
var width = letters.GetLength(1); // altura de las columnas
Console.WriteLine("height " + height);
Console.WriteLine("width " + width);


Console.WriteLine(Environment.NewLine);

//for (int i = 0; i < height; i++)
//{ 
//    Console.WriteLine(i);

//    for (var j = 0; j < width; j++)
//    {
//    Console.WriteLine(letters[i, j]);
//    }
//}

for (int i = 0; i < letters2.GetLength(0); i++)
{
    for (int j = 0; j < letters2.GetLength(1); j++)
    {
        Console.Write(letters2[i, j] + " ");
    }
    Console.WriteLine(Environment.NewLine);
}

////////////////////////////////////////////////////////////

int[,] results = new int[10, 10];

for (int i = 0; i < results.GetLength(0); i++)
{
    for (int j = 0; j < results.GetLength(1); j++)
    {
        results[i, j] = (i + 1) * (j + 1);
        Console.Write($"{results[i, j],4}");
    }
    Console.WriteLine();
}

//   1   2   3   4   5   6   7   8   9  10
//   2   4   6   8  10  12  14  16  18  20
//   3   6   9  12  15  18  21  24  27  30
//   4   8  12  16  20  24  28  32  36  40
//   5  10  15  20  25  30  35  40  45  50
//   6  12  18  24  30  36  42  48  54  60
//   7  14  21  28  35  42  49  56  63  70
//   8  16  24  32  40  48  56  64  72  80
//   9  18  27  36  45  54  63  72  81  90
//  10  20  30  40  50  60  70  80  90 100


////////////////////////////////////////////////////////////
Console.WriteLine(Environment.NewLine);

ConsoleColor GetColor(char terrain)
{
    return terrain switch
    {
        'g' => ConsoleColor.Green,
        's' => ConsoleColor.Magenta,
        'w' => ConsoleColor.Blue,
        _ => ConsoleColor.White
    };
}
char GetChar(char terrain)
{
    return terrain switch
    {
        'g' => '\u201c',
        's' => '\u25cb',
        'w' => '\u2248',
        _ => '\u25cf'
    };
}

char[,] map =
{
{ 's', 's', 's', 'g', 'g', 'g', 'g', 'g' },
{ 's', 's', 's', 'g', 'g', 'g', 'g', 'g' },
{ 's', 's', 's', 's', 's', 'b', 'b', 'b' },
{ 's', 's', 's', 's', 's', 'b', 's', 's' },
{ 'w', 'w', 'w', 'w', 'w', 'b', 'w', 'w' },
{ 'w', 'w', 'w', 'w', 'w', 'b', 'w', 'w' }
};

//Console.OutputEncoding: Esta propiedad de la clase Console controla
//cómo se interpretan los bytes que se envían a la salida de la consola.
//Si no se establece explícitamente, la consola utiliza una codificación
//predeterminada que depende del sistema operativo y la configuración
//regional. Esta codificación predeterminada a menudo no es UTF-8.
Console.OutputEncoding = Encoding.UTF8;

for (int r = 0; r < map.GetLength(0); r++)
{
    for (int c = 0; c < map.GetLength(1); c++)
    {
        Console.ForegroundColor = GetColor(map[r, c]);
        Console.Write(GetChar(map[r, c]) + " ");
    }
    Console.WriteLine();
}
Console.ResetColor();

//○ ○ ○ “ “ “ “ “
//○ ○ ○ “ “ “ “ “
//○ ○ ○ ○ ○ ● ● ●
//○ ○ ○ ○ ○ ● ○ ○
//≈ ≈ ≈ ≈ ≈ ● ≈ ≈
//≈ ≈ ≈ ≈ ≈ ● ≈ ≈



//////////////////////////////////////////////////////////
///JAGGED ARRAYS - Arrays escalonados


//Usa int[][] cuando necesites flexibilidad en la longitud de
//las "filas" (arrays internos). Usa int[,] cuando tengas una
//estructura de datos rectangular donde todas las "filas" deben
//tener la misma cantidad de "columnas". En la mayoría de los
//casos donde se representa una matriz matemática o una tabla,
//int[,] es la opción más adecuada y eficiente.

int[][] jaggedArray = new int[3][]; // Un array de 3 arrays de enteros

jaggedArray[0] = new int[5]; // El primer array interno tiene 5 elementos
jaggedArray[1] = new int[3]; // El segundo array interno tiene 3 elementos
jaggedArray[2] = new int[7]; // El tercer array interno tiene 7 elementos

// Inicialización con valores
jaggedArray[0][2] = 10; // Accediendo al tercer elemento del primer array interno
jaggedArray[1][1] = 20; // Accediendo al segundo elemento del segundo array interno
jaggedArray[2][5] = 30; // Accediendo al sexto elemento del tercer array interno

// Recorriendo el array escalonado
for (int i = 0; i < jaggedArray.Length; i++)
{
    Console.Write($"Fila {i}: ");
    for (int j = 0; j < jaggedArray[i].Length; j++)
    {
        Console.Write($"{jaggedArray[i][j], 3} ");
    }
    Console.WriteLine();
}

//Ejemplos de inicialización directa:
int[][] jaggedArray2 = new int[][] {
    new int[] {1,3,5,7,9},
    new int[] {0,2},
    new int[] {11,22,33,44}
};

int[][] jaggedArray3 = [
    new int[] {1,3},
    null!,
    new int[] {11,22,33,44}
];

int[][] jaggedArray4 = [
    [1,3],
    null!,
    [11,22,33,44]
];

//////////////////////////////////////////////////////////

Random random = new();

int meansCount = Enum.GetNames<MeanEnum>().Length;

Console.WriteLine($"meansCount: {meansCount}"); // 5

int year = DateTime.Now.Year;

Console.WriteLine($"year {year}");

//Esta es la característica principal de un ARRAY ESCALONADO:
//el tamaño de las columnas aún no está definido.
MeanEnum[][] means = new MeanEnum[12][];

for (int m = 1; m <= 12; m++)
{
    int daysCount = DateTime.DaysInMonth(year, m);
    means[m - 1] = new MeanEnum[daysCount];

    for (int d = 1; d <= daysCount; d++)
    {
        int mean = random.Next(meansCount);
        //Casting (MeanEnum)mean converts the random integer (mean) to its
        //corresponding MeanEnum value before assigning it to the array element.
        means[m - 1][d - 1] = (MeanEnum)mean;
        //Console.WriteLine(means[m - 1][d - 1]);
    }
}

string[] months = GetMonthNames();

// .Max(n => n.Length) (LINQ) iterates through each string in the months collection,
// gets its length, and returns the largest of those lengths.
int nameLength = months.Max(n => n.Length) + 2;

for (int m = 1; m <= 12; m++)
{
    string month = months[m - 1];
    Console.Write($"{month}:".PadRight(nameLength));
    for (int d = 1; d <= means[m - 1].Length; d++)
    {
        MeanEnum mean = means[m - 1][d - 1];

        // La función Get(mean) busca el carácter y el color correspondientes
        // basándose en el valor de MeanEnum y los devuelve como una tupla
        // (un par de valores). Los valores devueltos se almacenan en
        // variables separadas character y color.
        (char character, ConsoleColor color) = Get(mean);
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = color;
        Console.Write(character);
        Console.ResetColor();
        Console.Write(" ");
    }
    Console.WriteLine();
}


Console.ReadKey();

string[] GetMonthNames()
{
    CultureInfo culture = new("en");
    string[] names = new string[12];
    foreach (int m in Enumerable.Range(1, 12))
    {
        DateTime firstDay = new(DateTime.Now.Year, m, 1);
        string name = firstDay.ToString("MMMM", culture);
        names[m - 1] = name;
    }
    return names;
}

(char Char, ConsoleColor Color) Get(MeanEnum mean)
{
    return mean switch
    {
        MeanEnum.Bike => ('B', ConsoleColor.Blue),
        MeanEnum.Bus => ('U', ConsoleColor.DarkGreen),
        MeanEnum.Car => ('C', ConsoleColor.Red),
        MeanEnum.Subway => ('S', ConsoleColor.Magenta),
        MeanEnum.Walk => ('W', ConsoleColor.DarkYellow),
        _ => throw new Exception("Unknown type")
    };
}

public enum MeanEnum { Car, Bus, Subway, Bike, Walk }