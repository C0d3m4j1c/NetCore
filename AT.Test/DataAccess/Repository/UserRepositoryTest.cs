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
    }
}