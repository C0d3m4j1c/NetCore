using AT.DataAccess.Data;
using AT.DataAccess.Repository;
using AT.IDataAccess.IRepository;
using AT.Model.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Moq;
using System.Linq;

namespace AT.Test.DataAccess.Repository
{
    [TestFixture]
    public class UserRepositoryMockTest
    {
        private UserRepository _userRepository;
        ATDbContext context;
        IConfiguration config;
        

        [SetUp]
        public void Setup()
        {
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var optionsBuilder= new DbContextOptionsBuilder<ATDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            context= new ATDbContext(optionsBuilder.Options,config); 
            _userRepository = new UserRepository(context);
            
        }

        [TestCase(3)]
        [Test]
        public void ShouldGetUserById(int Id)
        {
            Mock<User> user = new Mock<User>();
            user.Object.Id = Id;
            var userFinded = _userRepository.GetById(Id);
            Assert.AreEqual(userFinded.Id, Id);
        }

    }
}