// See https://aka.ms/new-console-template for more information
using System;
using HrAdministrationAPI;



decimal salaries = 0;

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
    IEmployee teacher1 = new Teacher
    {
        Id = 1,
        FirstName  = "Bob",
        LastName = "Fisher",
        Salary = 40000

    };

    employees.Add(teacher1);

    IEmployee teacher2 = new Teacher
    {
        Id = 2,
        FirstName = "Joseph",
        LastName = "Wainaina",
        Salary = 10000000
    };

    employees.Add(teacher2);

    IEmployee headOFDepartment = new HeadOfDepartment
    {
        Id = 3,
        FirstName = "Lucy",
        LastName = "Omondi",
        Salary = 100000
    };

    employees.Add(headOFDepartment);

    IEmployee deputyHeadMaster = new DeputyHeadMaster
    {
        Id = 4,
        FirstName = "Stephen",
        LastName = "Weru",
        Salary = 20024800

    };

    employees.Add(deputyHeadMaster);

    IEmployee headMaster = new HeadMaster
    {
        Id = 5,
        FirstName = "Kennedy",
        LastName = "Langat",
        Salary = 1349493849
    };

    employees.Add(headMaster);  
        

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

