using System.Collections.Generic;
using AT.IDataAccess.IRepository;
using AT.Model.Common;
using Microsoft.AspNetCore.Mvc;

namespace AT.WebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> userRepository;
        public UserController(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            return Ok(userRepository.GetAll());
        }

        [HttpGet("Id")]
        public ActionResult<User> GetById(int Id)
        {
            return Ok(userRepository.GetById(Id));
        }

        [HttpPost]
        public ActionResult<User> Create(User User)
        {
            return Ok(userRepository.Create(User));
        }

        [HttpDelete]
        public ActionResult DeleteUser(User User)
        {
            userRepository.Delete(User);
            return Ok();
        }
    }
}