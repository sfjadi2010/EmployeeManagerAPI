using EmployeeManagerAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagerAPI.Services;

public static class EmployeeService
{
    private static List<Employee> _employees = new();

    private static int getEmployeeIndex(int id)
    {
        var employeeIndex = _employees.FindIndex(e => e.Id == id);

        if (employeeIndex == -1)
        {
            throw new Exception($"Employee with id {id} not found.");
        }

        return employeeIndex;
    }

    public static void Create(Employee employee)
    {
        var validationResult = new List<ValidationResult>();
        var validationContext = new ValidationContext(employee);

        if (!Validator.TryValidateObject(employee, validationContext, validationResult, true))
        {
            throw new ValidationException("Invalid employee data.");
        }

        _employees.Add(employee);
    }

    public static void Update(Employee employee)
    {
        _employees[getEmployeeIndex(employee.Id)] = employee;
    }

    public static void ChangeName(int id, string name)
    {
        _employees[getEmployeeIndex(id)].Name = name;
    }

    public static void Delete(int id)
    {
        _employees.RemoveAt(getEmployeeIndex(id));
    }

    public static Employee Get(int id)
    {
        return _employees[getEmployeeIndex(id)];
    }
}
