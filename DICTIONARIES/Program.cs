var employees = new List<Employee>
{
    new Employee("John Doe", "Sales", 50000m),
    new Employee("Jane Smith", "Marketing", 60000m),
    new Employee("Bob Johnson", "IT", 70000m),
    new Employee("Alice Brown", "Sales", 55000m),
    new Employee("Mike Davis", "Finance", 65000m),
    new Employee("Karla Sela", "Sales", 70000m),
    new Employee("Walter White", "IT", 80000m)
};

var result = CalculateAverageSalaryPerDepartment(employees);

Console.ReadKey();





Dictionary<string, decimal> CalculateAverageSalaryPerDepartment( IEnumerable<Employee> employees )
{
    var employeesPerDepartments = new Dictionary<string, List<Employee>>();

    foreach( var employee in employees )
    {
        if (!employeesPerDepartments.ContainsKey(employee.Department))
        {
            employeesPerDepartments[employee.Department] = new List<Employee>();
        }

        employeesPerDepartments[employee.Department].Add(employee);
    }

    var result = new Dictionary<string, decimal>();

    foreach( var employeesPerDepartment in employeesPerDepartments)
        {
        decimal sumOfSalaries = 0;

        foreach(var employee in employeesPerDepartment.Value )
        {
            sumOfSalaries += employee.Salary;
        }

        var average = sumOfSalaries / employeesPerDepartment.Value.Count;

        result[employeesPerDepartment.Key] = average;
    }

    return result;

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