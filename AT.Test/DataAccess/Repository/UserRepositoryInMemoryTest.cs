using AT.DataAccess.Data;
using AT.DataAccess.Repository;
using AT.IDataAccess.IRepository;
using AT.Model.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Linq;

namespace AT.Test.DataAccess.Repository
{
    [TestFixture]
    public class UserRepositoryInMemoryTest
    {
        ATDbContext context;
        IConfiguration configuration;
        
        [SetUp]
        public void Setup()
        {
            configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var options = new DbContextOptionsBuilder<ATDbContext>()
            .UseInMemoryDatabase(databaseName : "ATWebApi")
            .Options;

            context = new ATDbContext(options, configuration);
        }

        [TestCase("Juan Perez", "Juan Perez")]
        [Test]
        public void ShouldCreateNewUser(string UserName, string ExpectedUserName)
        {
            var userToBeCreated = new User {Id = 0, UserName = UserName};
            IRepository<User> userRepository = new UserRepository(context);
            var createdUser = userRepository.Create(userToBeCreated);
            Assert.AreEqual(createdUser.UserName, ExpectedUserName);
            Assert.Greater(createdUser.Id,0);
        }

        [TestCase(1)]
        [Test]
        public void ShouldGetUserById(int Id)
        {
            IRepository<User> userRepository = new UserRepository(context);
            var findedUser = userRepository.GetById(Id);
            Assert.AreEqual(findedUser.Id, Id);
        }

        [Test]
        public void ShouldGetAllUsers()
        {
            IRepository<User> userRepo=new UserRepository(context);
            var userList=userRepo.GetAll();
            Assert.Greater(userList.Count(),0);
        }        

        [TestCase(1,"test", false)]
        [Test]
        public void ShouldUpdateAUser(int Id, string Username, bool isDeleted)
        {
            IRepository<User> userRepo = new UserRepository(context);
            User userToBeUpdated = new User {Id = Id, UserName = Username, IsDeleted = isDeleted};
            User result = userRepo.Update(userToBeUpdated);
            Assert.That(result.UserName, Is.EqualTo(userToBeUpdated.UserName));
        }

        [TestCase(1)]
        [Test]
        public void ShouldDeleteAUserThatExists(int Id)
        {
            IRepository<User> userRepo = new UserRepository(context);
            User userToBeDeleated = new User {Id = Id};
            User result = userRepo.Delete(userToBeDeleated);
            Assert.That(result.Id, Is.EqualTo(userToBeDeleated.Id)); 
        }

    }
}