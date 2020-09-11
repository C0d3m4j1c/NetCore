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
    public class ProductTypeController : ControllerBase
    {
        private readonly IRepository<ProductType> productTypesRepository;
        
        public ProductTypeController(IRepository<ProductType> productTypesRepository)
        {
            this.productTypesRepository = productTypesRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductType>> GetAll()
        {
            return Ok(productTypesRepository.GetAll().ToList());
        }

        [HttpGet("Id")]
        public ActionResult<ProductType> GetById(int Id)
        {
            return Ok(productTypesRepository.GetById(Id));
        }

        [HttpPost]
        public ActionResult<ProductType> Create(ProductType ProductToBeCreated)
        {
            return Ok(productTypesRepository.Create(ProductToBeCreated));
        }

        [HttpDelete]
        public ActionResult DeleteUser(ProductType Product)
        {
            productTypesRepository.Delete(Product);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateUser(ProductType Product)
        {
            var productUpdated = productTypesRepository.Update(Product);
            return Ok(productUpdated);
        }
        
    }
}