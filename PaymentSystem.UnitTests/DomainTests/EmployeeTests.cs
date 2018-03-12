using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentSystem.Domain.Entities;
using PaymentSystem.Domain.Repositories;
using PaymentSystem.Domain.Abstract;

namespace PaymentSystem.UnitTests.DomainTests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void Add_Salaried_Employee_Test()
        {
            int empId = 4;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Emp4", "Addr4", 4000);
            t.Execute();

            Employee e = EmployeeRepository.Employee(empId);
            Assert.AreEqual(e.Name, "Emp4");

            PaymentClassification pc = e.PaymentClassification;
            Assert.IsInstanceOfType(pc, typeof(SalariedClassification));

            PaymentSchedule ps = e.PaymentSchedule;
            Assert.IsInstanceOfType(ps, typeof(MonthlySchedule));

            Assert.AreEqual(e.PaymentClassification.Salary, 4000);

            PaymentMethod pm = e.PaymentMethod;
            Assert.IsInstanceOfType(pm, typeof(HoldMethod));
        }
    }
}
