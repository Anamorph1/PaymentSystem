using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentSystem.Domain.Entities;

namespace PaymentSystem.Domain.Repositories
{
    public static class EmployeeRepository
    {
        private static IList<Employee> employees = new List<Employee>()
            {
                new Employee() {EmployeeId = 1, Name = "Emp1" , Address = "Addr1", Salary = 1000},
                new Employee() {EmployeeId = 2, Name = "Emp2" , Address = "Addr2", Salary = 2000},
                new Employee() {EmployeeId = 3, Name = "Emp3" , Address = "Addr3", Salary = 3000}
            };

        public static IEnumerable<Employee> Employees => employees;
        public static Employee Employee(int empId) => employees.FirstOrDefault(e => e.EmployeeId == empId);

        public static void AddEmployee(Employee employee)
        {
            if (employee.EmployeeId == 0)
            {
                employee.EmployeeId = employees.Max(e => e.EmployeeId) + 1;
                employees.Add(employee);
            }
            else
            {
                if (employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId) != null)
                    throw new ArgumentException();
                else
                    employees.Add(employee);
            }
        }
    }
}
