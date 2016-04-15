using System;
using System.NUnit;

[TestFixture]
public class HomeControllerTest
{
    [Test]
    public void IndexActionReturnsIndexView()
    {
        string expected = "Index";
        HomeController controller = new HomeController();

        var result = controller.Index() as ViewResult;

        Assert.AreEqual(expected, result.ViewName);
    }
}