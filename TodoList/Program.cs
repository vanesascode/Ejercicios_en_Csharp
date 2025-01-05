using System;
using System.ComponentModel.DataAnnotations;

var todos = new List<string>();

Console.WriteLine("¡Hola!");
Console.WriteLine("¡Bienvenid@ a tu C# TODOLIST!");

Console.WriteLine();

bool shallExit = false;

while (!shallExit)
{

    Console.WriteLine("Escoge qué quieres hacer:");
    Console.WriteLine();
    Console.WriteLine("[V]er todas las tareas");
    Console.WriteLine("[A]ñadir nueva tarea");
    Console.WriteLine("[E]liminar una tarea");
    Console.WriteLine("[B]orrar todas las tareas");
    Console.WriteLine("[S]alir");
    Console.WriteLine();

    var userChoice = Console.ReadLine();

    switch (userChoice)
    {
        case "S":
        case "s":
            Console.WriteLine("¡Adiós!");
            shallExit = true;
            break;
        case "V":
        case "v":
            SeeAllTodos();
            break;
        case "A":
        case "a":
            AddTodo();
            break;

        case "E":
        case "e":
            RemoveATodo();
            break;
        case "B":
        case "b":
            RemoveTodos();
            break;
        default:
            Console.WriteLine("Opción inválida");
            break;

    }
}

Console.ReadKey();

// HIGH LEVEL METHODS

void SeeAllTodos()
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }

    Console.WriteLine();
    for (int i = 0; i < todos.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todos[i]}");
    }
    Console.WriteLine();

}

void AddTodo()
{
    string description;
    do
    {
        Console.WriteLine("Añade la nueva tarea:");
        description = Console.ReadLine();

    }
    while (!IsDescriptionValid(description));

    todos.Add(description);
}

void RemoveTodos()
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }
    bool isDeleted = false;

    Console.WriteLine("Seguro que quieres eliminar todas las tareas?");
    Console.WriteLine("[S]i");
    Console.WriteLine("[N]o");

    var userChoice = Console.ReadLine();

    while (!isDeleted)
    {
        switch (userChoice)
        {
            case "S":
            case "s":
                todos.Clear();
                isDeleted = true;
                break;
            case "N":
            case "n":
                Console.WriteLine("Ok");
                isDeleted = true;
                break;
        }
    }
}

void RemoveATodo()
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }
    int index;
    do
    {
        Console.WriteLine("Escribe el número de la tarea que quieres eliminar:");
        SeeAllTodos();
    }
    while (!TryReadIndex(out index));

    RemoveTodoAtIndex(index - 1);
}

// LOW LEVEL METHODS:

void RemoveTodoAtIndex(int index)
{

    var todoToBeRemoved = todos[index];
    todos.RemoveAt(index);
    Console.WriteLine("Todo removed: " + todoToBeRemoved);
}



bool TryReadIndex(out int index)
{
    var userInput = Console.ReadLine();
    if (userInput == "")
    {
        index = 0;
        Console.WriteLine("Debes escoger un número primero");
        return false;
    }
    if (int.TryParse(userInput, out index) &&
        index >= 1 &&
        index <= todos.Count)
    {
        return true;
    }

    Console.WriteLine("En número que escribiste no es válido");
    return false;

}

void ShowNoTodosMessage()
{
    Console.WriteLine("No hay tareas en la lista");
}

bool IsDescriptionValid(string description)
{
    if (description == "")
    {
        Console.WriteLine("La descripción no puede estar vacía");
        return false;
    }
    if (todos.Contains(description))
    {
        Console.WriteLine("La descripción debe ser única");
        return false;
    }
    return true;
}