using Zero_Hunger_Management.Data;
using Zero_Hunger_Management.Models;

namespace Zero_Hunger_Management.Repo
{
    public class EmployeeRepo
    {

        private readonly ZeroHungerDBContext db;

        public EmployeeRepo(ZeroHungerDBContext context)
        {
            db = context;
        }
        //_____________________________Get Employee_______________________________________________

        public  List<Employee> Get()
        {
            //var db = new ZeroHungerDBContext();
            var employees = new List<Employee>();

            foreach (var item in db.Employees)
            {
                employees.Add(new Employee()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Location = item.Location,
                    Email = item.Email,
                    Password = item.Password
                });
            }
            return employees;

        }



        //_______________________________________Get Employee Details___________________________________

        public  Employee EmployeeDetails(int id)
        {
            //var db = new ZeroHungerDBContext();
            var employee = new Employee();

            var dbe = db.Employees.Find(id);


            employee.ID = dbe.ID;
            employee.Name = dbe.Name;
            employee.Location = dbe.Location;
            employee.Email = dbe.Email;
            employee.Password = dbe.Password;

            return employee;


        }


        //________________________________Add Employee_________________________________________

        public  void AddEmployee(Employee dbe)
        {
            //var db = new ZeroHungerDBContext();
            var employee = new Employee();



            //employee.ID = dbe.ID;
            employee.Name = dbe.Name;
            employee.Location = dbe.Location;
            employee.Email = dbe.Email;
            employee.Password = dbe.Password;

            db.Employees.Add(employee);
            db.SaveChanges();
        }


        //_______________________________Delete Employee_______________________________________

        public  void DeleteEmployee(int id)
        {
            //var db = new ZeroHungerDBContext();

            var dbe = db.Employees.Find(id);

            db.Employees.Remove(dbe);
            db.SaveChanges();
        }

        //_______________________________Update Employee_________________________________________

        public  void UpdateEmployee(int id, Employee employee)
        {
            //var db = new ZeroHungerDBContext();

            var dbe = db.Employees.Find(id);


            dbe.ID = employee.ID;
            dbe.Name = employee.Name;
            dbe.Location = employee.Location;
            dbe.Email = employee.Email;
            dbe.Password = employee.Password;

            db.SaveChanges();


        }
    }
}
