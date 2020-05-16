using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChangeCounselling.Web;
using ChangeCounselling.Web.Controllers;
using ChangeCounselling.Data.Services;
using ChangeCounselling.Data.Models;

namespace ChangeCounselling.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexResultNotNull()
        {
            //Arrange
           HomeController controller = new HomeController(new SqlCounsellorData(new CounsellorDbContext()) );
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);  
        }

        [TestMethod]
        public void About()
        {
            //Arrange
            HomeController controller = new HomeController(new SqlCounsellorData(new CounsellorDbContext()));

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            //Arrange
            HomeController controller = new HomeController(new SqlCounsellorData(new CounsellorDbContext()));

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
