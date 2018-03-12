using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentSystem.Domain.Abstract;

namespace PaymentSystem.Domain.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public PaymentClassification PaymentClassification { get; set; }
        public PaymentSchedule PaymentSchedule { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
