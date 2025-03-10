namespace FuncActionAndPredicate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //**************** Func
            MathClass math = new MathClass();



            //  Func<int, int, int> calc = delegate(int a , int b) { return a + b;  };

            

            Func<int, int, int> calc =  (a, b) => a + b;


            Func<decimal, decimal, decimal> calculateSellingPrice = (a, b) => (a *b) + a;

            Console.WriteLine(calculateSellingPrice(100, 0.16m));

            Console.WriteLine(calc(1, 2));

            //************ Action

            Action<string, string, string> displayDetails = (name, age, salary) => Console.WriteLine($"The name {name}, of age {age} receves a salary of {salary}");

            displayDetails("jose", "25", "20000000000");

            //************* Predicate

            List<Employee> employees = new List<Employee>();

            Employee employee1 = new Employee() { Id = 1, FirstName = "Johnstone", LastName = "Kamau", salary = 100000.0m, isManager = false };
            employees.Add(employee1);
            Employee employee2 = new Employee() { Id = 2, FirstName = "Sly", LastName = "Kariuki", salary = 5000m, isManager = false };
            employees.Add(employee2);
            Employee employee3 = new Employee() { Id = 3, FirstName = "Bernard", LastName = "Musyoki", salary = 1848347m, isManager = false };
            employees.Add(employee3);
            Employee employee4 = new Employee() { Id = 1, FirstName = "Ravji", LastName = "Mohammed", salary = 35800000m, isManager = true };

            //  List<Employee> filteredEmployees = FileterEmployees(employees, e => e.salary <= 5000m);

            List<Employee> filteredEmployees = employees.FileterEmployees(e => e.Id == 1);

            foreach (var filteredEmployee in  filteredEmployees)
            {
                Console.WriteLine($" Id : {filteredEmployee.Id}  FirstName : {filteredEmployee.FirstName}  LastName : {filteredEmployee.LastName} salary {filteredEmployee.salary}");
            }
        }

       
    }

    public static class Extensions
    {
        public static List<Employee> FileterEmployees(this List<Employee> employees, Predicate<Employee> predicate)
        {
            List<Employee> result = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (predicate(employee))
                {
                    result.Add(employee);
                }
            }

            return result;
        }

    }

    

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal salary { get; set; }

        public bool isManager { get; set; }

    }
    public class MathClass
    {
        public int sum(int a , int b)
        {
            return a + b;
        }
    }
}
