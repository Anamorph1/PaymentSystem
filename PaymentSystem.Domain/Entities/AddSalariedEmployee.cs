using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentSystem.Domain.Abstract;

namespace PaymentSystem.Domain.Entities
{
    public class AddSalariedEmployee : AddEmployeeTransaction
    {
        public decimal Salary { get; set; }

        public AddSalariedEmployee(int empId, string name, string address, decimal salary) : base(empId,name,address)
        {
            Salary = salary;
        }

        public override PaymentClassification GetClassification() => new SalariedClassification() { Salary = Salary };

        public override PaymentSchedule GetSchedule() => new MonthlySchedule();
    }
}
