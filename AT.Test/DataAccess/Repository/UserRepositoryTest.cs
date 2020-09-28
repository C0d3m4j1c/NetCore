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
    public class UserRepositoryTest
    {
        ATDbContext context;
        IConfiguration config;

        [SetUp]
        public void Setup()
        {
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var optionsBuilder= new DbContextOptionsBuilder<ATDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            context=new ATDbContext(optionsBuilder.Options,config);      
        }
        [Test]
        public void ShouldGetAllUsers()
        {
            IRepository<User> userRepo=new UserRepository(context);
            var userList=userRepo.GetAll();
            Assert.Greater(userList.Count(),0);
        }

        [TestCase(1)]
        [Test]
        public void ShouldGetAUser(int Id)
        {
            IRepository<User> userRepo = new UserRepository(context);
            var user = userRepo.GetById(Id);
            Assert.That(user.Id, Is.EqualTo(Id));
        }

        [Test]
        public void ShouldReturnNullOnIdThatDoesntExist()
        {
            IRepository<User> userRepo = new UserRepository(context);
            var user = userRepo.GetById(9999);
            Assert.That(user, Is.Null);
        }

        [Test]
        public void ShouldCreateAUser()
        {
            IRepository<User> userRepo = new UserRepository(context);
            User newUser = new User {UserName = "Pedro"};
            var result = userRepo.Create(newUser);
            Assert.That(newUser.UserName, Is.EqualTo(result.UserName));
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

        [TestCase(1,"test", false)]
        [Test]
        public void ShouldUpdateAUser(int Id, string Username, bool isDeleted)
        {
            IRepository<User> userRepo = new UserRepository(context);
            User userToBeUpdated = new User {Id = Id, UserName = Username, IsDeleted = isDeleted};
            User result = userRepo.Update(userToBeUpdated);
            Assert.That(result.UserName, Is.EqualTo(userToBeUpdated.UserName));
        }
    }
}