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
using System.Net;

namespace Projecteer.API.Test.Controllers
{
    [TestClass]
    public class TagsControllerTests
    {
        [TestMethod]
        public void GetCurrentTagShouldReturnTag()
        {
            // Arrange
            WebApiConfig.CreateMaps();
            var _mockTagRepo = new Mock<ITagRepository>();
            _mockTagRepo.Setup(m => m.GetById(1))
                        .Returns(new Tag
                        {
                            TagId = 1,
                            TagTypeId = TagTypes.Project,
                            Name = "Tag Name"
                        });

            var _mockUnitOfWork = new Mock<IUnitOfWork>();
            var _mockUserRepo = new Mock<IProjecteerUserRepository>();
            var _mockProjectRepo = new Mock<IProjectRepository>();

            var controller = new TagsController(_mockTagRepo.Object, _mockProjectRepo.Object, _mockUserRepo.Object, _mockUnitOfWork.Object);

            // Act
            var response = controller.GetCurrentTag(1);

            // Assert
            Assert.IsNotNull(response);

            OkNegotiatedContentResult<TagsModel> okHttpReponse = (OkNegotiatedContentResult<TagsModel>)response;

            Assert.IsNotNull(okHttpReponse);
            Assert.IsNotNull(okHttpReponse.Content);

            var domainResponse = okHttpReponse.Content;

            Assert.AreEqual(domainResponse.TagId, 1);
        }

        [TestMethod]
        public void GetCurrentTagShouldReturnNotFoundIfTagDoesNotExist()
        {
            // Arrange
            WebApiConfig.CreateMaps();
            var _mockTagRepo = new Mock<ITagRepository>();
            _mockTagRepo.Setup(m => m.GetById(1))
                        .Returns(new Tag
                        {
                            TagId = 1,
                            TagTypeId = TagTypes.Project,
                            Name = "Tag Name"
                        });

            var _mockUnitOfWork = new Mock<IUnitOfWork>();
            var _mockUserRepo = new Mock<IProjecteerUserRepository>();
            var _mockProjectRepo = new Mock<IProjectRepository>();

            var controller = new TagsController(_mockTagRepo.Object, _mockProjectRepo.Object, _mockUserRepo.Object, _mockUnitOfWork.Object);

            // Act
            var response = controller.GetCurrentTag(2);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PutTagShouldReturnNoContent()
        {
            // Arrange
            var _mockTagRepo = new Mock<ITagRepository>();
            var _mockUnitOfWork = new Mock<IUnitOfWork>();
            var _mockUserRepo = new Mock<IProjecteerUserRepository>();
            var _mockProjectRepo = new Mock<IProjectRepository>();

            _mockTagRepo.Setup(m => m.GetById(1))
                        .Returns(new Tag
                        {
                            TagId = 1,
                            TagTypeId = TagTypes.Project,
                            Name = "Tag Name"
                        });

            TagsModel newTag = new TagsModel
            {
                TagId = 1,
                TagTypeId = TagTypes.Project,
                Name = "This Tag"
            };

            var controller = new TagsController(_mockTagRepo.Object, _mockProjectRepo.Object, _mockUserRepo.Object, _mockUnitOfWork.Object);

            // Act
            var response = controller.PutTag(1, newTag);
            StatusCodeResult result = response as StatusCodeResult;

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        //[TestMethod]
        //public void PutTagShouldReturnBadRequestWhenIdDoesNotMatch()
        //{
        //    // Arrange
        //    var _mockTagRepo = new Mock<ITagRepository>();
        //    var _mockUnitOfWork = new Mock<IUnitOfWork>();
        //    var _mockUserRepo = new Mock<IProjecteerUserRepository>();
        //    var _mockProjectRepo = new Mock<IProjectRepository>();

        //    _mockTagRepo.Setup(m => m.GetById(1))
        //                .Returns(new Tag
        //                {
        //                    TagId = 1,
        //                    TagTypeId = TagTypes.Project,
        //                    Name = "Tag Name"
        //                });

        //    TagsModel newTag = new TagsModel
        //    {
        //        TagId = 2,
        //        TagTypeId = TagTypes.Project,
        //        Name = "This Tag"
        //    };

        //    var controller = new TagsController(_mockTagRepo.Object, _mockProjectRepo.Object, _mockUserRepo.Object, _mockUnitOfWork.Object);

        //    // Act
        //    var response = controller.PutTag(1, newTag);
        //    StatusCodeResult result = response as StatusCodeResult;

        //    // Assert
        //    Assert.IsNotNull(response);
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        //}

        [TestMethod]
        public void PostTagShouldReturnOkAndTagContent()
        {
            // Arrange 
            var _mockTagRepo = new Mock<ITagRepository>();
            var _mockUnitOfWork = new Mock<IUnitOfWork>();
            var _mockUserRepo = new Mock<IProjecteerUserRepository>();
            var _mockProjectRepo = new Mock<IProjectRepository>();

            var controller = new TagsController(_mockTagRepo.Object, _mockProjectRepo.Object, _mockUserRepo.Object, _mockUnitOfWork.Object);

            // Act
            IHttpActionResult actionResult = controller.PostTag(new TagsModel { TagId = 10, Name = "JavaScript", TagTypeId = TagTypes.Project });
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<TagsModel>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(10, createdResult.RouteValues["id"]);
        }

        [TestMethod]
        public void DeleteTagShouldReturnTagContent()
        {
            // Arrange
            WebApiConfig.CreateMaps();
            var _mockTagRepo = new Mock<ITagRepository>();
            _mockTagRepo.Setup(m => m.GetById(1))
                        .Returns(new Tag
                        {
                            TagId = 1,
                            TagTypeId = TagTypes.Project,
                            Name = "Tag Name"
                        });

            var _mockUnitOfWork = new Mock<IUnitOfWork>();
            var _mockUserRepo = new Mock<IProjecteerUserRepository>();
            var _mockProjectRepo = new Mock<IProjectRepository>();

            var controller = new TagsController(_mockTagRepo.Object, _mockProjectRepo.Object, _mockUserRepo.Object, _mockUnitOfWork.Object);

            // Act
            var response = controller.DeleteTag(1);

            // Assert
            Assert.IsNotNull(response);

            OkNegotiatedContentResult<TagsModel> okHttpReponse = (OkNegotiatedContentResult<TagsModel>)response;

            Assert.IsNotNull(okHttpReponse);
            Assert.IsNotNull(okHttpReponse.Content);

            var domainResponse = okHttpReponse.Content;

            Assert.AreEqual(domainResponse.TagId, 1);
        }
    }
}
