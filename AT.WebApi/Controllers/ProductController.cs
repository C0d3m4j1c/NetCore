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
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> productRepository;
        
        public ProductController(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(productRepository.GetAll().ToList());
        }

        [HttpGet("Id")]
        public ActionResult<Product> GetById(int Id)
        {
            return Ok(productRepository.GetById(Id));
        }

        [HttpPost]
        public ActionResult<Product> Create(Product ProductToBeCreated)
        {
            return Ok(productRepository.Create(ProductToBeCreated));
        }

        [HttpDelete]
        public ActionResult DeleteUser(Product Product)
        {
            productRepository.Delete(Product);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateUser(Product Product)
        {
            var productUpdated = productRepository.Update(Product);
            return Ok(productUpdated);
        }
    }
}