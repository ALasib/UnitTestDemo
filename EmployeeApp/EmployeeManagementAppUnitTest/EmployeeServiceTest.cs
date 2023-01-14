using EmployeeManagementApp.Models;
using EmployeeManagementApp.Repositories;
using EmployeeManagementApp.Repositories.Interfaces;
using EmployeeManagementApp.Services;
using EmployeeManagementApp.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAppUnitTest
{
    [TestFixture]
    public class EmployeeServiceTest
    {
        private IEmployeeService _service;
        private Mock<IEmployeeRepository> _mockRepository;
        private Mock<ITaxService> _mockTaxService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<IEmployeeRepository>(MockBehavior.Strict);
            _mockTaxService= new Mock<ITaxService>(MockBehavior.Strict);
            _service = new EmployeeService(_mockRepository.Object, _mockTaxService.Object);
        }

        // Method naming convention : Tested Method Name + When + Scenario + Returns + Result
        [Test]
        [TestCase(5000, 0.10, "1/1/2018", "4/30/2018", 2000)]
        [TestCase(10000, 0.10, "1/1/2018", "4/30/2018", 4000)]
        [TestCase(2500, 0.10, "1/1/2018", "4/30/2018", 1000)]
        public void CalculateTaxWithSampleEmployeeReturnsProperTax(int salary, double taxRate, string joiningDate, string toDate, double expected)
        {
            //arrange

            //mocking the get method of the repository to return the following
            // defined employee regardless of any employee id
            _mockRepository.Setup(r => r.Get(It.IsAny<int>())).Returns(new Employee
            {
                Name = "John Smith",
                Id= 1,
                JoiningDate = DateTime.Parse(joiningDate),
                Salary = salary
            });
            //mocking the GetTax method
            _mockTaxService.Setup(s=>s.GetTaxRate()).Returns(taxRate);

            // act
            var obtainedResult = _service.CalculateTax(1, DateTime.Parse(toDate));
            
            //assert
            Assert.AreEqual(expected, obtainedResult);
        }
    }
}
