namespace MedicalJournal.Tests.Controllers
{
    using Moq;
    using MedicalJournal.Controllers;
    using MedicalJournal.Service;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Mvc;
    using System.Web;
    using MedicalJournal.Models;
    using MedicalJournal.Core.Data;

    [TestClass]
    public class PublisherControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var mockTypeRepo = new Mock<IPubService>();
             // Arrange
            var controller = new PublisherController(mockTypeRepo.Object);
            // Act
            var response = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Model); // add additional checks on the Model
            Assert.IsTrue(string.IsNullOrEmpty(response.ViewName) || response.ViewName == "Index");
        }

        [TestMethod]
        public void CreateEditPublisher()
        {
            var mockTypeRepo = new Mock<IPubService>();
            // Arrange
            var controller = new PublisherController(mockTypeRepo.Object);
            // Act
            var response = controller.CreateEditPublisher(It.IsAny<string>());
            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void DetailPublisher()
        {
            var mockTypeRepo = new Mock<IPubService>();
            // Arrange
            var controller = new PublisherController(mockTypeRepo.Object);
            // Act
            var response = controller.DetailPublisher(It.IsAny<string>());
            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void DeleteJournalType()
        {
            var mockTypeRepo = new Mock<IPubService>();
            // Arrange
            var controller = new PublisherController(mockTypeRepo.Object);
            // Act
            var response = controller.DeletePublisher("1");
            // Assert
            Assert.IsNotNull(response);
        }
    }
}
