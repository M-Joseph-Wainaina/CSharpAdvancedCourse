// See https://aka.ms/new-console-template for more information
using System;
using HrAdministrationAPI;


//decimal salaries = 0;

List<IEmployee> employees = new List<IEmployee>();

SeedData(employees);

//foreach(var employee in employees)
//{
//    salaries += employee.Salary;
//}

//Console.WriteLine($"Salaries (Including Bonusses) : {salaries}");

// using Linq Technology

Console.WriteLine($"Salaries Including Bonusses {employees.Sum(e => e.Salary)}");




static void SeedData(List<IEmployee> employees)
{
    IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Bob", "Fisher", 40000);
      
    employees.Add(teacher1);

    IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Jenny", "Thomson", 40000);

    employees.Add(teacher2);

    IEmployee headOfDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 2, "Brenda", "Mullins", 50000);

    employees.Add(headOfDepartment);

    IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 2, "Devlin", "Brown", 60000);

    employees.Add(deputyHeadMaster);

    IEmployee headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 2, "Joseph", "Wainaina", 70000);

    employees.Add(headMaster);  
        

}

public enum EmployeeType
{
    Teacher,
    HeadOfDepartment,
    DeputyHeadMaster,
    HeadMaster

};

public static class EmployeeFactory
{
    public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
    {
        IEmployee employee = null;

        switch (employeeType)
        {
            case EmployeeType.Teacher:
                employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                break;
            case EmployeeType.HeadOfDepartment:
                employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance(); ;
                break;
            case EmployeeType.DeputyHeadMaster:
                employee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
                break;
            case EmployeeType.HeadMaster:
                employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance(); ;
                break;
            default:
                break;
        }

        if (employee != null)
        {
            employee.Id = id;
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Salary = salary;
        }

        else
        {
            throw new NullReferenceException();
        }

        return employee;
    }
}



public class Teacher : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); }
}

public class HeadOfDepartment : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); }
}

public class DeputyHeadMaster : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); }
}
public class HeadMaster : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); }
}

