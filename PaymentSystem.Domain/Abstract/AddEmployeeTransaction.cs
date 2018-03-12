using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentSystem.Domain.Entities;
using PaymentSystem.Domain.Repositories;

namespace PaymentSystem.Domain.Abstract
{
    public abstract class AddEmployeeTransaction : ITransaction
    {
        int empId;
        string name;
        string address;

        public AddEmployeeTransaction(int empId, string name, string address)
        {
            this.empId = empId;
            this.name = name;
            this.address = address;
        }

        public abstract PaymentClassification GetClassification();
        public abstract PaymentSchedule GetSchedule();

        public virtual void Execute()
        {
            PaymentClassification pc = GetClassification();
            PaymentSchedule ps = GetSchedule();
            PaymentMethod pm = new HoldMethod();
            Employee emp = new Employee() { EmployeeId = empId,
                                            Name = name,
                                            Address = address,
                                            PaymentClassification = pc,
                                            PaymentSchedule = ps,
                                            PaymentMethod = pm};
            EmployeeRepository.AddEmployee(emp);
        }

    }
}
