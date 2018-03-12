using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaymentSystem.Domain.Abstract;
using PaymentSystem.Domain.Entities;
using PaymentSystem.Domain.Repositories;

namespace PaymentSystem.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType) => kernel.TryGet(serviceType);

        public IEnumerable<object> GetServices(Type serviceType) => kernel.GetAll(serviceType);

        private void AddBindings()
        {
            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.Employees).Returns(EmployeeRepository.Employees);
            mock.Setup(m => m.AddEmployee(It.IsAny<Employee>())).Callback((Employee employee) => EmployeeRepository.AddEmployee(employee));
            mock.Setup(m => m.Employee(It.IsAny<int>())).Callback((int empId) => EmployeeRepository.Employee(empId));

            kernel.Bind<IEmployeeRepository>().ToConstant(mock.Object);
        }

        
    }
}