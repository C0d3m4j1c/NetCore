using System.Collections.Generic;
using System.Linq;
using AT.IDataAccess.IRepository;
using AT.Model.Common;
using AT.Model.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AT.WebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> userRepository;
        private readonly IMapper mapper;
        public UserController(IRepository<User> userRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserForList>> GetAll()
        {
            return Ok(userRepository.GetAll().ToList().Select(mapper.Map<User,UserForList>));
        }

        [HttpGet("Id")]
        public ActionResult<User> GetById(int Id)
        {
            return Ok(mapper.Map<User,UserForList>(userRepository.GetById(Id)));
        }

        [HttpPost]
        public ActionResult<User> Create(UserForRegistration UserForRegistration)
        {
            return Ok(userRepository.Create(mapper.Map<UserForRegistration, User>(UserForRegistration)));
        }
        

        [HttpDelete]
        public ActionResult DeleteUser(User User)
        {
            userRepository.Delete(User);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateUser(User User)
        {
            var userUpdated = userRepository.Update(User);
            return Ok(userUpdated);
        }
    }
}