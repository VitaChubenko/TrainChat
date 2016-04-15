
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainChat.Web.Api.Controllers;

namespace UnitTests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexActionReturnsIndexView()
        {
            string expected = "Index";
            HomeController controller = new HomeController();

            var result = controller.Index() as ViewResult;
            Assert.AreEqual(expected, result.ViewName);
        }
    }
}
