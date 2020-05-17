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
    public class BillControllerTest
    {
        [TestMethod]
        public void IndexModelNotNull()
        {
            //Arrange
            BillController controller = new BillController(new SqlBillData(new CounsellorDbContext()), new SqlClientData(new CounsellorDbContext()), new SqlCounsellorData(new CounsellorDbContext()), new SqlBookData(new CounsellorDbContext()));
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result.Model);
        }
    }
}
