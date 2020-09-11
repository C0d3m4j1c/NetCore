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
        private readonly IMapper mapper;
        public ProductController(IRepository<Product> productRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductForList>> GetAll()
        {
            return Ok(productRepository.GetAll().ToList().Select(mapper.Map<Product,ProductForList>));
        }

        [HttpGet("Id")]
        public ActionResult<Product> GetById(int Id)
        {
            return Ok(mapper.Map<Product,ProductForList>(productRepository.GetById(Id)));
        }

        [HttpPost]
        public ActionResult<Product> Create(ProductForRegistration ProductToBeCreated)
        {
            return Ok(productRepository.Create(mapper.Map<ProductForRegistration, Product>(ProductToBeCreated)));
        }

        [HttpDelete]
        public ActionResult Delete(ProductForDeletion ProductToBeDeleted)
        {
            productRepository.Delete(mapper.Map<ProductForDeletion, Product>(ProductToBeDeleted));
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(ProductForUpdate ProductToBeUpdated)
        {
            var productUpdated = productRepository.Update(mapper.Map<ProductForUpdate, Product>(ProductToBeUpdated));
            return Ok(productUpdated);
        }
    }
}