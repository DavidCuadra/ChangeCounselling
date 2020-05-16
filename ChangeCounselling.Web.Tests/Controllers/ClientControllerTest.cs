using ChangeCounselling.Data.Services;
using ChangeCounselling.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChangeCounselling.Web.Tests.Controllers
{
    [TestClass]
    public class ClientControllerTest
    {
        [TestMethod]
        public void IndexModelNotNull()
        {
            //Arrange
            ClientController controller = new ClientController(new SqlClientData(new CounsellorDbContext()));
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result.Model);
        }
        [TestMethod]
        public void Details_ModeisNull()
        {
            //Arrange
            ClientController controller = new ClientController(new SqlClientData(new CounsellorDbContext()));
            // Act
            HttpNotFoundResult result = controller.Details(1) as HttpNotFoundResult;
            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }
        //[TestMethod]
        //public void DetailElModeloNoEsNUll()
        //{
        //    //Arrange
        //    ClientController controller = new ClientController(new SqlClientData(new CounsellorDbContext()));
        //    // Act
        //    ViewResult result = controller.Details(1) as ViewResult;
        //    // Assert
        //    Assert.IsNotNull(result);
        //    //Assert.IsNotNull(result.Model);
        //}

    } 
}
