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
    public class JournalTypeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            
            var mockTypeRepo = new Mock<IJournalTypeService>();
             // Arrange
            var controller = new JournalTypeController(mockTypeRepo.Object);
            // Act
            var response = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Model); // add additional checks on the Model
            Assert.IsTrue(string.IsNullOrEmpty(response.ViewName) || response.ViewName == "Index");
        }

        [TestMethod]
        public void CreateEditJournalType()
        {
            var mockTypeRepo = new Mock<IJournalTypeService>();
            // Arrange
            JournalTypeController controller = new JournalTypeController(mockTypeRepo.Object);
            // Act
            var response = controller.CreateEditJournalType(It.IsAny<int>());
            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void PostCreateEditJournalType()
        {
            var mockTypeRepo = new Mock<IJournalTypeService>();
            var mockTypeObject = new JournalTypeModel();
            var mockTypeUpload = new HttpPostedFileBase[] { };
            // Arrange
            JournalTypeController controller = new JournalTypeController(mockTypeRepo.Object);
            // Act
            var response = controller.CreateEditJournalType(mockTypeObject, mockTypeUpload);
            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void DetailJournalType()
        {
            var mockTypeRepo = new Mock<IJournalTypeService>();
            // Arrange
            JournalTypeController controller = new JournalTypeController(mockTypeRepo.Object);
            // Act
            var response = controller.DetailJournalType(It.IsAny<int>());
            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void DeleteJournalType()
        {
            var mockTypeRepo = new Mock<IJournalTypeService>();
            // Arrange
            JournalTypeController controller = new JournalTypeController(mockTypeRepo.Object);
            // Act
            var response = controller.DeleteJournalType(1);
            // Assert
            Assert.IsNotNull(response);
        }
    }
}
