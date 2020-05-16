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
    public class DatepickerControllerTest
    {
        [TestMethod]
       public void IndexViewResultNotNull()
        {
            //Arrange
            DatepickerController controller = new DatepickerController();
            //act
            ViewResult result = controller.Index() as ViewResult;
            //assert
            Assert.IsNotNull(result);

        }
 

    }
}
