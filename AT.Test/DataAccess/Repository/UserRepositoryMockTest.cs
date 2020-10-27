using AT.DataAccess.Data;
using AT.DataAccess.Repository;
using AT.IDataAccess.IRepository;
using AT.Model.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Moq;
using System.Linq;
using System.Collections.Generic;

namespace AT.Test.DataAccess.Repository
{
    [TestFixture]
    public class UserRepositoryMockTest
    {
        private Mock<IRepository<User>> _userRepository;
        ATDbContext context;
        IConfiguration config;
        

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IRepository<User>>();
        }

        [TestCase(3)]
        [Test]
        public void ShouldGetUserById(int Id)
        {
            Mock<User> user = new Mock<User>();
            user.Object.Id = Id;
            _userRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(user.Object);
            var userFinded = _userRepository.Object.GetById(Id);
            Assert.AreEqual(userFinded.Id, Id);
        }

        [Test]
        public void ShouldGetAllUsers()
        {
            IList<User> usersList = new List<User>();
            usersList.Add(new User(){ Id = 1, UserName = "Dummy1"});
            usersList.Add(new User(){ Id = 2, UserName = "Dummy 2"});
            _userRepository.Setup(x => x.GetAll()).Returns(usersList);
            var userList = _userRepository.Object.GetAll();
            Assert.Greater(userList.Count(),0);
        }
        
        [TestCase(1,"Pedro")]
        [Test]
        public void ShouldCreateAndReturnTheUser(int Id, string UserName)
        {
            Mock<User> user = new Mock<User>();
            user.Object.Id = Id;
            user.Object.UserName = UserName;
            _userRepository.Setup(x => x.Create(user.Object)).Returns(user.Object);
            var userCreated = _userRepository.Object.Create(user.Object);
            Assert.AreEqual(userCreated.Id, Id);
        }

        [TestCase(1)]
        [Test]
        public void ShouldDeleteAndReturnTheUser(int Id)
        {
            Mock<User> user = new Mock<User>();
            user.Object.Id = Id;
            _userRepository.Setup(x => x.Delete(user.Object)).Returns(user.Object);
            var userCreated = _userRepository.Object.Delete(user.Object);
            Assert.AreEqual(userCreated.Id, Id);
        }
    }
}