using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleApp.Controllers;
using SampleApp.Repository;

namespace SampleApp.Test
{
    [TestClass]
    public class Values
    {
        private readonly Mock<ITestRepository> _repo;
        public Values()
        {
            _repo = new Mock<ITestRepository>();
        }
        [TestMethod]
        public void GetEmployees_Success()
        {
            ValuesController controller = new ValuesController(_repo.Object);
            _repo.Setup(a => a.GetEmployees()).Returns(new System.Collections.Generic.List<Models.Employee>
            {
                new Models.Employee{ Name="Ajay",Salary=10000}
            });
            var result = (OkObjectResult)controller.Get();
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNotNull(result.Value);
        }
        [TestMethod]
        public void GetEmployees_NoRecords()
        {
            ValuesController controller = new ValuesController(_repo.Object);
            _repo.Setup(a => a.GetEmployees()).Returns(new System.Collections.Generic.List<Models.Employee>());
            var result = (NotFoundResult)controller.Get();
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void GetEmployees_Exception()
        {
            ValuesController controller = new ValuesController(_repo.Object);
            _repo.Setup(a => a.GetEmployees()).Throws(new System.Exception());
            var result = (StatusCodeResult)controller.Get();
            Assert.AreEqual(500, result.StatusCode);
        }

        [TestMethod]
        public void GetHighestSalary_Success()
        {
            ValuesController controller = new ValuesController(_repo.Object);
            _repo.Setup(a => a.GetEmployees()).Returns(new System.Collections.Generic.List<Models.Employee>
            {
            new Models.Employee{Name="Ajay",Salary=100000, Department="Engg"},
            new Models.Employee{Name="Vijay", Salary=150000, Department="Testing"},
            new Models.Employee{Name="Vishal",Salary=96000 ,Department="Engg"},
            new Models.Employee{Name="Manish", Salary=850000, Department="Engg"},
            new Models.Employee{Name="Suresh",Salary=9888000, Department="Testing"}
            });
            var result = (OkObjectResult)controller.Get("Engg");
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNotNull(result.Value);
        }

        // Write other possible cases during session.
    }
}
