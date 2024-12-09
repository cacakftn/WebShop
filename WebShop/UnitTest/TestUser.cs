using BusinessLayer.Implementation;
using DataAccessLayer;
using Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class TestUser
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly UserBusiness _userBusiness;

        public TestUser()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockOrderRepository = new Mock<IOrderRepository>();
            _userBusiness = new UserBusiness(_mockUserRepository.Object, _mockOrderRepository.Object);
        }

        [TestMethod]
        public void Add_ValidUser_ReturnsSuccess()
        {
            // Arrange
            var user = new User
            {
                IdUser = 1,
                FrstName = "Test",
                LastName = "User",
                Email = "test@example.com",
                PasswordHash = "password123",
                Satus = true,
                CreatedDate = DateTime.UtcNow,
                IdRole = 2
            };

            _mockUserRepository.Setup(repo => repo.Add(It.IsAny<User>())).Returns(true);

            // Act
            var result = _userBusiness.Add(user);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Uspenso dodat", result.Message);
        }


        [TestMethod]
        public void Add_InvalidUser_ReturnsValidationError()
        {
            // Arrange
            var user = new User { IdUser = 1 }; // Missing required fields
            _mockUserRepository.Setup(repo => repo.Add(It.IsAny<User>())).Returns(false);

            // Act
            var result = _userBusiness.Add(user);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Message.Contains("Ime je obavezno."));
        }

        [TestMethod]
        public void Delete_UserWithOrders_ReturnsError()
        {
            // Arrange
            var user = new User { IdUser = 1 };
            _mockOrderRepository.Setup(repo => repo.GetOrderByUserId(user.IdUser)).Returns(1);

            // Act
            var result = _userBusiness.Delete(user);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Korisnicki nalog je povezan sa tabelom order", result.Message);
        }

        [TestMethod]
        public void Delete_UserWithoutOrders_ReturnsSuccess()
        {
            // Arrange
            var user = new User { IdUser = 1 };
            _mockOrderRepository.Setup(repo => repo.GetOrderByUserId(user.IdUser)).Returns(0);
            _mockUserRepository.Setup(repo => repo.Delete(user)).Returns(true);

            // Act
            var result = _userBusiness.Delete(user);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Uspesno obrisan nalog", result.Message);
        }


        [TestMethod]
        public void GetById_ExistingUser_ReturnsUser()
        {
            // Arrange
            var user = new User { IdUser = 1 };
            _mockUserRepository.Setup(repo => repo.GetAll()).Returns(new List<User> { user });

            // Act
            var result = _userBusiness.GetById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.IdUser);
        }

        [TestMethod]
        public void GetById_NonExistingUser_ReturnsEmptyUser()
        {
            // Arrange
            _mockUserRepository.Setup(repo => repo.GetAll()).Returns(new List<User>());

            // Act
            var result = _userBusiness.GetById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.IdUser);
        }
    }
}
