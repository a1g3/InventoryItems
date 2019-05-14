using InventoryItems.Data.Infastructure;
using InventoryItems.Data.Repositories;
using InventoryItems.Data.Tests.Utils;
using InventoryItems.Domain.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InventoryItems.Data.Tests.Repositories {
    [TestClass]
    public class ProjectRepositoryTests : TestBase {
        [TestMethod]
        public void ProjectRepository_Basic() {
            using (var context = DataCreation.CreateDb("ProjectRepository_Basic")) {
                //ARRANGE
                var repo = new ProjectRepository(new DatabaseFactory(context));
                var projects = DataCreation.CreateProjects();
                context.AddRange(projects);
                context.SaveChanges();

                //ACT
                var project = repo.GetById(projects[1].Id);

                //ASSERT
                Assert.IsInstanceOfType(project, typeof(ProjectDto));
                Assert.AreEqual("Project 2", project.Name);
                Assert.AreEqual(projects[1].Id, project.Id);
            }
        }

        [TestMethod]
        public void ProjectRepository_ProjectNotFound() {
            using (var context = DataCreation.CreateDb("ProjectRepository_ProjectNotFound")) {
                //ARRANGE
                var repo = new ProjectRepository(new DatabaseFactory(context));
                var projects = DataCreation.CreateProjects();
                context.AddRange(projects);
                context.SaveChanges();

                //ACT
                var project = repo.GetById(Guid.NewGuid());

                //ASSERT
                Assert.IsNull(project);
            }
        }
    }
}
