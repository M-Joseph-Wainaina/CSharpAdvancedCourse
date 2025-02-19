using System.Text;
using HrAdministrationAPI;

namespace FactoryDesignPattern
{
    public enum EmployeeType
    {
        Teacher,
        HeadOfDepartment,
        DeputyHeadMaster,
        HeadMaster

    }
    internal class Program
    {

        static void Main(string[] args)
        {
            decimal salaries;

            List<IEmployee> employees = new List<IEmployee>();

            SeedData(employees);

            salaries = employees.Sum(e => e.Salary);

            Console.WriteLine(salaries);

        }

        public static void SeedData(List<IEmployee> employees) 
        {
            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Joseph", "Wainaina", 100 ) ;
            employees.Add(teacher1) ;

            IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Stephen", "Karanja", 100);
            employees.Add(teacher1);

            IEmployee headOfDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 1, "Hoza", "Hoza", 100);
            employees.Add(headOfDepartment);

            IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 1, "Joseph", "Wainaina", 100);
            employees.Add(deputyHeadMaster);

            IEmployee HeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 1, "Joseph", "Wainaina", 100);
            employees.Add(HeadMaster);

          }


    }
    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal Salary)
            {
                IEmployee employee = null;

            switch (employeeType)
            {
                case EmployeeType.Teacher:
                    employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                    break;

                case EmployeeType.HeadOfDepartment:
                    employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
                    break;
                case EmployeeType.DeputyHeadMaster:
                    employee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
                    break;
                case EmployeeType.HeadMaster:
                    employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
                    break;
                default:
                    break;

            }

            if (employee != null)
            {
                employee.Id = id;
                employee.Salary = Salary;
                employee.FirstName = firstName;
                employee.LastName = lastName;
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
        public override decimal Salary { get => base.Salary + base.Salary * 0.05m;  }
    }

}
