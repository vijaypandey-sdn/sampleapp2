using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApp.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Test
{
    [TestClass]
    public class Home
    {

        [TestMethod]
        public void GetHome_Success()
        {
            // I am writing a sample test case.
            HomeController controller = new HomeController();
            var result = (OkObjectResult)controller.Get();
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNotNull(result.Value);
            Assert.AreEqual("Hello world!!", result.Value);
        }
    }
}
