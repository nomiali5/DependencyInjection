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
    public class MedicJournalControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var mockTypeJournal = new Mock<IMedicJournallService>();
            var mockTypeRepo = new Mock<IJournalTypeService>();
             // Arrange
            var controller = new MedicJournalController(mockTypeJournal.Object, mockTypeRepo.Object);
            // Act
            var response = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Model); // add additional checks on the Model
            Assert.IsTrue(string.IsNullOrEmpty(response.ViewName) || response.ViewName == "Index");
        }

        [TestMethod]
        public void CreateEditMedicJournal()
        {
            var mockTypeJournal = new Mock<IMedicJournallService>();
            var mockTypeRepo = new Mock<IJournalTypeService>();
            // Arrange
            MedicJournalController controller = new MedicJournalController(mockTypeJournal.Object, mockTypeRepo.Object);
            // Act
            var response = controller.CreateEditMedicJournal(It.IsAny<int>());
            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void PostCreateEditMedicJournal()
        {
            var mockTypeJournal = new Mock<IMedicJournallService>();
            var mockTypeRepo = new Mock<IJournalTypeService>();
            var mockTypeUpload = new HttpPostedFileBase[] { };
            var mockTypeImage = new HttpPostedFileBase[] { };
            var mockTypeObject = new MedicalJournalModel();
            // Arrange
            MedicJournalController controller = new MedicJournalController(mockTypeJournal.Object, mockTypeRepo.Object);
            // Act
            var response = controller.CreateEditMedicJournal(mockTypeObject, mockTypeUpload, mockTypeImage);
            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void DetailJournalType()
        {
            var mockTypeJournal = new Mock<IMedicJournallService>();
            var mockTypeRepo = new Mock<IJournalTypeService>();
            // Arrange
            MedicJournalController controller = new MedicJournalController(mockTypeJournal.Object, mockTypeRepo.Object);
            // Act
            var response = controller.DetailMedicJournal(It.IsAny<int>());
            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void DeleteJournalType()
        {
            var mockTypeJournal = new Mock<IMedicJournallService>();
            var mockTypeRepo = new Mock<IJournalTypeService>();
            // Arrange
            MedicJournalController controller = new MedicJournalController(mockTypeJournal.Object, mockTypeRepo.Object);
            // Act
            var response = controller.DeleteMedicJournal(1);
            // Assert
            Assert.IsNotNull(response);
        }
    }
}
