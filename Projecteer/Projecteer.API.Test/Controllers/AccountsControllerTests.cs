//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Projecteer.API.Controllers;
//using Projecteer.Core.Infrastructure;
//using Moq;
//using Projecteer.Core.Models;
//using System.Web.Http.Results;
//using System.Threading.Tasks;

//namespace Projecteer.API.Test.Controllers
//{
//    [TestClass]
//    public class AccountsControllerTests
//    {
//        [TestMethod]
//        public async Task RegisterUserShouldRegisterUser()
//        {
//            // Arrange
//            var _authRepository = new Mock<IAuthorizationRepository>(); // make fake IAuthorizationRepository
//            var controller = new AccountsController(_authRepository.Object);

//            // Act
//            // pretend like you're calling the method
//            var registration = new RegistrationModel
//            {
//                FirstName = "Elizabeth",
//                LastName = "Maraan",
//                UserName = "Elizabeth",
//                Password = "something12",
//                ConfirmPassword = "something12",
//                EmailAddress = "elizabeth@maraan.com"
//            };

//            var response = await controller.RegisterAdmin(registration);

//            // Assert
//            Assert.IsInstanceOfType(response, typeof(OkResult));

//        }
//    }
//}
