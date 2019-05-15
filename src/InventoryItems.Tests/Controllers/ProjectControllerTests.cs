using InventoryItems.Controllers;
using InventoryItems.Domain.Tests.Utils;
using InventoryItems.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;

namespace InventoryItems.Tests.Controllers {
    [TestClass]
    public class ProjectControllerTests {
        [TestMethod]
        public void ProjectController_Get_Basic() {
            //ARRANGE
            var projectId = Guid.NewGuid();
            var controller = MockUtils.MockProperties<ProjectsController>();
            Mock.Get(controller.ProjectFacade).Setup(x => x.GetById(projectId)).Returns(
                new Domain.Dtos.ProjectDto() { Id = projectId, Name = "Project 543" }
            );

            //ACT
            var project = controller.Get(projectId).Value as ProjectViewModel;

            //ASSERT
            Assert.AreEqual(projectId, project.Id);
            Assert.AreEqual("Project 543", project.Name);
        }
    }
}
