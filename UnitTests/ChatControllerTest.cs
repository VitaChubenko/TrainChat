using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TrainChat.Web.Api.Controllers;
using Assert = NUnit.Framework.Assert;

namespace UnitTests
{
    [TestFixture]
    public class ChatControllerTest
    {
        [Test]
        public void CheckFields()
        {
            ChatController controller = new ChatController();
            string expectedView = "Chat";
            ViewResult result = controller.Chat("myLogin") as ViewResult;
            Assert.AreEqual(expectedView, result.ViewName);
        }
    }
}
