using PaymentSystem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaymentSystem.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public ViewResult List()
        {
            return View(employeeRepository.Employees);
        }
    }
}