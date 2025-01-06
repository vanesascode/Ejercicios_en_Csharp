var employees = new List<Employee>
{
    new("John Doe", "Sales", 50000m),
    new ("Jane Smith", "Marketing", 60000m),
    new ("Bob Johnson", "IT", 70000m),
    new ("Alice Brown", "Sales", 55000m),
    new ("Mike Davis", "Finance", 65000m),
    new ("Karla Sela", "Sales", 70000m),
    new ("Walter White", "IT", 80000m)
};

Dictionary<string, decimal> results = CalculateAverageSalaryPerDepartment(employees);

Console.WriteLine();

Console.WriteLine("List of departments:");

if (results.Count == 0) {Console.WriteLine("No departments found.");}

//foreach ((string department, decimal average) in results)
//{
//    Console.WriteLine($"{department}");
//}
results.Select(x => x.Key).ToList().ForEach(Console.WriteLine);

Console.WriteLine();

Console.WriteLine("Search by depart:");

string departmentChosen = Console.ReadLine() ?? string.Empty;
if (results.TryGetValue(departmentChosen, out decimal averageOfDepartment))
{
    Console.WriteLine($"Salary average of department {departmentChosen} is {averageOfDepartment:F2}");
}
else
{
    Console.WriteLine("That department doesn't exist.");
}

Console.ReadKey();

//Al utilizar IEnumerable, la función puede aceptar cualquier tipo de colección que implemente IEnumerable, como List, Array, HashSet, etc.
//Esto permite que la función sea más general y pueda ser utilizada con diferentes tipos de colecciones sin tener que modificarla.
//Además, al utilizar IEnumerable, se evita la necesidad de crear una copia de la colección, lo que puede ser útil
//si la colección es grande y no se desea realizar una copia innecesaria.
Dictionary<string, decimal> CalculateAverageSalaryPerDepartment(IEnumerable <Employee> employees)
{
    //var employeesPerDepartments = new Dictionary<string, List<Employee>>();
    //foreach (var employee in employees)
    //{
    //    if (!employeesPerDepartments.ContainsKey(employee.Department))
    //    {
    //        employeesPerDepartments[employee.Department] = new List<Employee>();
    //    }

    //    employeesPerDepartments[employee.Department].Add(employee);
    //}


    //el método GroupBy es para agrupar los empleados por departamento. 
    //g es un objeto de tipo IGrouping<string, Employee>, que representa un grupo de empleados que pertenecen al mismo departamento.
    //El método ToList() convierte el grupo de empleados en una lista de empleados.
    //La sintaxis g => g.ToList() es una forma de expresar una función lambda que toma un objeto g como entrada y devuelve una lista de empleados como salida.
    var employeesPerDepartments = employees.GroupBy(e => e.Department)
                                    .ToDictionary(g => g.Key, g => g.ToList());

    //foreach ((string department, List<Employee> employeesInDepartment) in employeesPerDepartments)
    //{
    //    Console.WriteLine($"{department}, {employeesInDepartment}");
    //}

    //En este código, se utiliza Select para crear una lista de cadenas, donde cada cadena tiene el formato {departamento}: {lista de nombres de empleados}.
    //Luego, se utiliza string.Join para concatenar todas las cadenas en una sola cadena, separadas por un salto de línea.
    Console.WriteLine("Employees per department (the value also holds the department and the salary data");
    var toPrint = string.Join("\n", employeesPerDepartments.Select(g => ($"{g.Key}: {string.Join(", ", g.Value.Select(e => e.Name))}")));
    Console.WriteLine(toPrint);

    Console.WriteLine();

    //var departmentAverageSalaries = new Dictionary<string, decimal>();
    //foreach (var employeesPerDepartment in employeesPerDepartments)
    //{
    //    decimal sumOfSalaries = 0;
    //    foreach (var employee in employeesPerDepartment.Value)
    //    {
    //        sumOfSalaries += employee.Salary;
    //    }
    //    var average = sumOfSalaries / employeesPerDepartment.Value.Count;
    //    departmentAverageSalaries[employeesPerDepartment.Key] = average;
    //}
    var departmentAverageSalaries = employeesPerDepartments.ToDictionary(g => g.Key, g => g.Value.Sum(e => e.Salary) / g.Value.Count);
    return departmentAverageSalaries;

}

public class Employee
{
    public Employee(string name, string department, decimal salary)
    {
        Name = name;
        Department = department;
        Salary = salary;
    }

    public string Name { get; init; }
    public string Department { get; init; }
    public decimal Salary { get; init; }

}