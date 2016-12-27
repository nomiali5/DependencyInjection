namespace MedicalJournal.Tests.Controllers
{
    using Moq;
    using MedicalJournal.Controllers;
    using MedicalJournal.Service;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Mvc;

    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            
            var mockJournalRepo = new Mock<IMedicJournallService>();
            var mockTypeRepo = new Mock<IJournalTypeService>();
            var mockSubscriberRepo = new Mock<IJournalSubscriberService>();
             // Arrange
            var controller = new HomeController(mockJournalRepo.Object,mockTypeRepo.Object,mockSubscriberRepo.Object);
            // Act
            var response = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Model); // add additional checks on the Model
            Assert.IsTrue(string.IsNullOrEmpty(response.ViewName) || response.ViewName == "Index");
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void TestSubscribe()
        {
            var mockJournalRepo = new Mock<IMedicJournallService>();
            var mockTypeRepo = new Mock<IJournalTypeService>();
            var mockSubscriberRepo = new Mock<IJournalSubscriberService>();
            // Arrange
            var controller = new HomeController(mockJournalRepo.Object, mockTypeRepo.Object, mockSubscriberRepo.Object);
            
            //Act
            var result = controller.Subscribe("test@gmail.com", "1");

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestSearch()
        {
            var mockJournalRepo = new Mock<IMedicJournallService>();
            var mockTypeRepo = new Mock<IJournalTypeService>();
            var mockSubscriberRepo = new Mock<IJournalSubscriberService>();
            // Arrange
            var controller = new HomeController(mockJournalRepo.Object, mockTypeRepo.Object, mockSubscriberRepo.Object);
            
            //Act
            PartialViewResult result = controller.Search("test");

            //Assert
            Assert.AreEqual("_SearchResult", result.ViewName);
        }
    }
}
