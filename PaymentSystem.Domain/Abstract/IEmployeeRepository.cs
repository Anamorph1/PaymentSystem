using PaymentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Domain.Abstract
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Employees { get; }
        Employee Employee(int empId);
        void AddEmployee(Employee employee);
    }
}
