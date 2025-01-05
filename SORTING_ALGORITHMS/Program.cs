using System.Diagnostics;
using System.Timers;

int[] arrayOriginal = new int[10000]; // Array de 10,000 elementos
Random rnd = new Random();
for (int i = 0; i < arrayOriginal.Length; i++)
{
    arrayOriginal[i] = rnd.Next(-100000, 100001); // Números aleatorios entre -100000 y 100000
}

Console.WriteLine(arrayOriginal.Length -1);

int[] array1 = (int[])arrayOriginal.Clone(); 
Stopwatch stopwatch1 = Stopwatch.StartNew();
selectionSort(array1);
stopwatch1.Stop();
Console.WriteLine("Selection Sort: " + stopwatch1.ElapsedMilliseconds + " ms");

int[] array2 = (int[])arrayOriginal.Clone();
Stopwatch stopwatch2 = Stopwatch.StartNew();
insertionSort(array2);
stopwatch2.Stop();
Console.WriteLine("Insertion Sort: " + stopwatch2.ElapsedMilliseconds + " ms");

int[] array3 = (int[])arrayOriginal.Clone();
Stopwatch stopwatch3 = Stopwatch.StartNew();
bubbleSort(array3);
stopwatch3.Stop();
Console.WriteLine("Bubble Sort: " + stopwatch3.ElapsedMilliseconds + " ms");

int[] array4 = (int[])arrayOriginal.Clone();
Stopwatch stopwatch4 = Stopwatch.StartNew();
mergeSort(array4);
stopwatch4.Stop();
Console.WriteLine("Merge Sort: " + stopwatch4.ElapsedMilliseconds + " ms");

int[] array5 = (int[])arrayOriginal.Clone();
Stopwatch stopwatch5 = Stopwatch.StartNew();
quickSort(array5);
stopwatch5.Stop();
Console.WriteLine("Quick Sort: " + stopwatch5.ElapsedMilliseconds + " ms");


// como el array es una estructura de dato de referencia, si le haces algo con una función void, no es necesario retornar nada, ya que el array original se modifica:
//int[] array = [-11, 12, -42, 0, 1, 90, 68, 6, -9]; 
//quickSort(array);
//Console.WriteLine(string.Join(" | ", array));

Console.ReadKey();


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// SELECTION SORT
/// 
/// First, the sorted part is empty. 
/// 
/// In the following iterations, the algorithm finds the smallest element in the unsorted part and exchanges it with the first element in the sorted part. Thus, the sorted part increases by one element.
/// 
/// El nombre "selección" se debe a que este algoritmo trabaja seleccionando repetidamente el elemento mínimo (o máximo, dependiendo del orden) del resto de la lista no ordenada y colocándolo en su posición correcta.

void selectionSort(int[] a)
{
    for (int i = 0; i < a.Length - 1; i++)// 9
    {
        int minIndex = i;
        int minValue = a[i];

        for (int j = i + 1; j < a.Length; j++) 
        {
            if (a[j] < minValue)
            {
                minIndex = j;
                minValue = a[j];
            }
        }
        (a[i], a[minIndex]) = (a[minIndex], a[i]);

        //(a[i], a[minIndex]): Esto crea una tupla que contiene los valores de a[i] (el elemento en el índice i) y a[minIndex] (el elemento en el índice minIndex).
        //(a[minIndex], a[i]): Esto crea otra tupla, pero con los valores en orden inverso. Contiene el valor de a[minIndex] primero y luego el valor de a[i].
        //=: El operador de asignación en este contexto realiza una desestructuración de tuplas.

        //Esto significa que los valores de la tupla de la derecha se asignan a
        //las variables de la tupla de la izquierda, en el orden correspondiente.(a[i], a[minIndex]): Esto crea una tupla que contiene los valores de a[i] (el elemento en el índice i) y a[minIndex] (el elemento en el índice minIndex).
        //(a[minIndex], a[i]): Esto crea otra tupla, pero con los valores en orden inverso. Contiene el valor de a[minIndex] primero y luego el valor de a[i].
        //=: El operador de asignación en este contexto realiza una desestructuración de tuplas. Esto significa que los valores de la tupla de la derecha se asignan a las variables de la tupla de la izquierda, en el orden correspondiente.

        //Console.WriteLine($"num: {i}: {string.Join(" | ", a)}");
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////
/// INSERTION SORT
/// 
/// At the beginning, the first element is included in the sorted part. 
/// 
/// In each iteration, the algorithm takes the first element from the unsorted part and places it in a suitable location within the sorted part, to leave the sorted part in the correct order.
///
/// El nombre "inserción" proviene de la forma en que este algoritmo construye la lista ordenada: insertando cada elemento en la posición correcta dentro de la parte ya ordenada de la lista.

void insertionSort(int[] a)
{
    for (int i = 1; i < a.Length; i++)
    {
        int j = i;
        while (j > 0 && a[j] < a[j - 1])
        {
            (a[j], a[j - 1]) = (a[j - 1], a[j]);
            j--;
        }
    }
}


////////////////////////////////////////////////////////////////////////////////////////////////////////
/// BUBBLE SORT
/// The algorithm just iterates through the array and compares adjacent elements. If they are located in an incorrect order, they are swapped.

void bubbleSort(int[] a)
{
    for (int i = 0; i < a.Length; i++)
    {
        //bool isAnyChange = false;
        for (int j = 0; j < a.Length - 1; j++)
        {
            if (a[j] > a[j + 1])
            {
                //isAnyChange = true;
                (a[j], a[j + 1]) = (a[j + 1], a[j]);
            }
        }
        //if (!isAnyChange) { break; }
    }
}


////////////////////////////////////////////////////////////////////////////////////////////////////
/// MERGE SORT
/// This algorithm recursively splits the array in half until the array contains only one element, which is sorted. 
/// Then, the algorithm merges the already sorted subarrays (starting with these with only one element) into the sorted array.

void mergeSort(int[] a)
{
    if (a.Length <= 1) { return; }

    int m = a.Length / 2;  //Se calcula la mitad de la longitud del arreglo a y se almacena en la variable m.

    int[] left = GetSubarray(a, 0, m - 1); // Se llama a la función GetSubarray para obtener una submatriz del arreglo a que comienza en el índice 0 y termina en el índice m - 1.
    int[] right = GetSubarray(a, m, a.Length - 1);  //Se llama a la función GetSubarray para obtener una submatriz del arreglo a que comienza en el índice m y termina en el índice a.Length - 1.

    mergeSort(left); // Se llama a la función mergeSort de manera recursiva para ordenar la submatriz left.

    mergeSort(right); // Se llama a la función mergeSort de manera recursiva para ordenar la submatriz right.

    int i = 0, j = 0, k = 0; // Estas variables se utilizarán como índices para recorrer las submatrices left y right.

    while (i < left.Length && j < right.Length) // Se inicia un bucle while que se ejecutará mientras i sea menor que la longitud de la submatriz left y j sea menor que la longitud de la submatriz right.
                                                //En cada iteración del bucle, se compararán los elementos de las submatrices left y right en las posiciones i y j, respectivamente.
    {
        if (left[i] <= right[j]) { a[k] = left[i++]; } // Si el elemento de la submatriz left en la posición i es menor o igual que el elemento de la submatriz right en la posición j, se asigna el elemento de left a la posición k del arreglo original a. Se incrementa el índice i para apuntar al siguiente elemento de la submatriz left.
        else { a[k] = right[j++]; } //Si el elemento de la submatriz left en la posición i es mayor que el elemento de la submatriz right en la posición j, se asigna el elemento de right a la posición k del arreglo original a. Se incrementa el índice j para apuntar al siguiente elemento de la submatriz right.
        k++; //Se incrementa el índice k para apuntar a la siguiente posición del arreglo original a.
        //Esto es lo mismo que: 
        //if (left[i] <= right[j])
        //{
        //    a[k] = left[i];
        //    i++;
        //}
        //else
        //{
        //    a[k] = right[j];
        //    j++;
        //}
        //k++;
        // Esto: "a[k] = left[++i]" aumenta el valor de i en 1 y luego asigna el valor de left[i] a a[k], que no es lo que queremos. 
    }

    // es posible que uno de los arreglos (left o right) tenga más elementos que el otro.Entonces:

    while (i < left.Length) { a[k++] = left[i++]; } // El primer bucle while copia los elementos restantes de left al arreglo a, empezando desde la posición k actual. El índice i se incrementa en cada iteración para apuntar al siguiente elemento de left.
    while (j < right.Length) { a[k++] = right[j++]; } // El segundo bucle while copia los elementos restantes de right al arreglo a, empezando desde la posición k actual. El índice j se incrementa en cada iteración para apuntar al siguiente elemento de right.

    /*    Supongamos que left es [2, 4, 6, 8] y right es [1, 3, 5]. El arreglo original a está vacío.
    Después de comparar y copiar los elementos de left y right, el arreglo a queda así: [1, 2, 3, 4, 5].
    Sin embargo, todavía quedan 2 elementos en left que no han sido copiados: [6, 8].
    El primer bucle while copia estos elementos al arreglo a, empezando desde la posición 5: [1, 2, 3, 4, 5, 6, 8].Supongamos que left es [2, 4, 6, 8] y right es [1, 3, 5]. El arreglo original a está vacío.
    Después de comparar y copiar los elementos de left y right, el arreglo a queda así: [1, 2, 3, 4, 5].
    Sin embargo, todavía quedan 2 elementos en left que no han sido copiados: [6, 8].
    El primer bucle while copia estos elementos al arreglo a, empezando desde la posición 5: [1, 2, 3, 4, 5, 6, 8].*/
}

int[] GetSubarray(int[] a, int ini, int fin)
{
    int[] result = new int[fin - ini + 1]; // está creando un array de una longitud específica
    //Array.Copy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length);
    Array.Copy(a, ini, result, 0, fin - ini + 1);
    return result;
}

////////////////////////////////////////////////////////////////////////////////////////////////////
/// MERGE SORT
/// https://www.youtube.com/watch?v=Vtckgz38QHs

void quickSort(int[] a)
{
    // Llama a la función recursiva SortPart con los índices inicial y final del arreglo.
    SortPart(a, 0, a.Length - 1); //a.Lenght = 10000, a.Length - 1 = 9999
}

// Función recursiva que realiza la partición y el ordenamiento.
void SortPart(int[] array, int cero, int arrayLastIndex)
{
    // Caso base de la recursión: si el subarreglo tiene 0 o 1 elementos, ya está ordenado.
    if (cero >= arrayLastIndex) { return; }

    // Se elige el último elemento del subarreglo como pivote.
    // Otras estrategias comunes son elegir el primer elemento o un elemento aleatorio.
    int pivot = array[arrayLastIndex];

    // j se utiliza para rastrear la posición del último elemento menor que el pivote.
    // Inicialmente, se establece en cero - 1, ya que aún no se ha encontrado ningún elemento menor.
    int j = cero - 1;

    // Bucle que recorre el subarreglo desde el inicio hasta el penúltimo elemento.
    for (int i = cero; i < arrayLastIndex; i++)

    {

        if (array[i] < pivot) // Si el elemento actual es menor que el pivote, se incrementa j para indicar que se ha encontrado un elemento menor.
        {

            j++;

            // Se intercambian los elementos en las posiciones j e i.
            // Esto coloca los elementos menores que el pivote a la izquierda de j.
            // Esta sintaxis es un "tuple swap" de C# que realiza el intercambio de forma eficiente.
            (array[j], array[i]) = (array[i], array[j]);
        }
    }

    // Después del bucle, j + 1 es la posición correcta para el pivote.
    // Todos los elementos a la izquierda de p son menores que el pivote,
    // y todos los elementos a la derecha de p son mayores o iguales que el pivote.
    int p = j + 1;

    // Se coloca el pivote en su posición final intercambiándolo con el elemento en la posición p.
    (array[p], array[arrayLastIndex]) = (array[arrayLastIndex], array[p]);




    // Llamadas recursivas para ordenar los subarreglos a la izquierda y a la derecha del pivote.
    SortPart(array, cero, p - 1); // Subarreglo izquierdo.
    SortPart(array, p + 1, arrayLastIndex); // Subarreglo derecho.

    Console.WriteLine(string.Join(" | ", array));
}