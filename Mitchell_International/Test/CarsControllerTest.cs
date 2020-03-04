using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mitchell_International.Controllers;
using Microsoft.VisualStudio.TestTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Mitchell_International.Models;

namespace Mitchell_International.Controllers
{
    [TestClass]
    public class CarsControllerTest
    {
        //Testing the Error Controller
        [TestMethod]
        public void TestErrorView()
        {
            var controller = new CarsController();
            var test = controller.Cars_Error() as ViewResult;
            //var result = (RedirectToRouteResult)controller.Cars_Error();
            Assert.IsNotNull(test);
           // Assert.AreEqual("Cars_Error", test.ViewName);
        }

        //Testing Details Controller
        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new CarsController();
            var test = controller.Details(2002) as ViewResult;
            var check = (Car)test.ViewData.Model;
            Assert.AreEqual("Suzuki", check.Make);
            //Assert.IsNotNull(test);
        }

        //Testing the Create Controller
        [TestMethod]
        public void TestCreateView()
        {
            var controller = new CarsController();
            Car c = new Car(); c.Year = 2014; c.Make = "Nissan"; c.Model = "Sedan";
            var test = (RedirectToRouteResult)controller.Create(c);
            Assert.AreEqual("Index", test.RouteValues["action"]);
            //Assert.IsNotNull(test);
        }


        //Testing the Search Controller
        [TestMethod]
        public void TestSearch()
        {
            var controller = new CarsController();
            var test = (RedirectToRouteResult)controller.Select(4002);
            Assert.AreEqual("Details", test.RouteValues["action"]);
        }
    }
}