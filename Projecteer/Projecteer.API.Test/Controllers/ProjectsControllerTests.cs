using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Projecteer.Core.Repository;
using Projecteer.Core.Domain;
using Projecteer.Core.Infrastructure;
using Projecteer.API.Controllers;
using System.Web.Http.Results;
using Projecteer.Core.Models;
using System.Web.Http;
using System.Linq.Expressions;

namespace Projecteer.API.Test.Controllers
{
    [TestClass]
    public class ProjectsControllerTests
    { 
        //[TestMethod]
        //public void GetProjectsShouldReturnAllProjects()
        //{

        //}

        [TestMethod]
        public void GetProjectShouldReturnOk()
        {

        }

        [TestMethod]
        public void PutProjectShouldReturnNoContent()
        {

        }

        [TestMethod]
        public void PostShouldReturnOkWithContent()
        {
            WebApiConfig.CreateMaps();
            var _mockProjectRepo = new Mock<IProjectRepository>();
            var _mockUserRepo = new Mock<IProjecteerUserRepository>();
            var _mockParticipantRepo = new Mock<IParticipantRepository>();
            var _mockUnitOfWork = new Mock<IUnitOfWork>();

            _mockUserRepo.Setup(m => m.GetFirstOrDefault(It.IsAny<Expression<Func<ProjecteerUser, bool>>>()))
                         .Returns(new ProjecteerUser
                         {
                             Id = "userid",
                             UserName = "emaraan",
                             PasswordHash = "password",
                             SecurityStamp = "security",
                             FirstName = "Elizabeth",
                             LastName = "Maraan",
                             Email = "emaraan@gmail.com"
                         });

            Participant participant = new Participant
            {
                ProjecteerUserId = "userid",
                ProjectId = 10
            };

            _mockParticipantRepo.Setup(m => m.Add(participant));

            var controller = new ProjectsController(_mockProjectRepo.Object, _mockUserRepo.Object, _mockParticipantRepo.Object, _mockUnitOfWork.Object);

            // Act
            IHttpActionResult actionResult = controller.Post(new ProjectsModel
            {
                ProjectId = 10,
                Name = "The Cool Project Name Generator",
                Description = "Make a generator that generates cool project names",
                CreatedDate = new DateTime(2014, 02, 20),
                ModifiedDate = new DateTime(2014, 03, 19)
            });

            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<ProjectsModel>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(10, createdResult.RouteValues["id"]);
        }

        [TestMethod]
        public void DeleteProjectShouldReturnOk()
        {
            // Arrange
            WebApiConfig.CreateMaps();
            var _mockProjectRepo = new Mock<IProjectRepository>();
            _mockProjectRepo.Setup(m => m.GetById(1))
                            .Returns(new Project
                            {
                                ProjectId = 1,
                                Name = "The Cool Project Name Generator",
                                Description = "Make a generator that generates cool project names",
                                CreatedDate = new DateTime(2014, 02, 20),
                                ModifiedDate = new DateTime(2014, 03, 19)
                            });

            var _mockUserRepo = new Mock<IProjecteerUserRepository>();
            var _mockParticipantRepo = new Mock<IParticipantRepository>();
            var _mockUnitOfWork = new Mock<IUnitOfWork>();

            var controller = new ProjectsController(_mockProjectRepo.Object, _mockUserRepo.Object, _mockParticipantRepo.Object, _mockUnitOfWork.Object);

            // Act
            var response = controller.DeleteProject(1);

            // Assert
            Assert.IsNotNull(response);

            OkNegotiatedContentResult<ProjectsModel> okHttpResponse = (OkNegotiatedContentResult<ProjectsModel>)response;

            Assert.IsNotNull(okHttpResponse);
            Assert.IsNotNull(okHttpResponse.Content);

            var domainResponse = okHttpResponse.Content;

            Assert.AreEqual(domainResponse.ProjectId, 1);
        }
    }
}
