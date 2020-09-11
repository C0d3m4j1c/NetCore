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
        private readonly IMapper mapper;
        
        public ProductTypeController(IRepository<ProductType> productTypesRepository, IMapper mapper)
        {
            this.productTypesRepository = productTypesRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductTypeForList>> GetAll()
        {
            return Ok(productTypesRepository.GetAll().ToList());
        }

        [HttpGet("Id")]
        public ActionResult<ProductType> GetById(int Id)
        {
            return Ok(productTypesRepository.GetById(Id));
        }

        [HttpPost]
        public ActionResult<ProductType> Create(ProductTypeForRegistration ProductTypeToBeCreated)
        {
            return Ok(productTypesRepository.Create(mapper.Map<ProductTypeForRegistration, ProductType>(ProductTypeToBeCreated)));
        }

        [HttpDelete]
        public ActionResult Delete(ProductTypeForDeletion ProductTypeToBeDeleted)
        {
            productTypesRepository.Delete(mapper.Map<ProductTypeForDeletion, ProductType>(ProductTypeToBeDeleted));
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(ProductTypeForUpdate ProductTypeToBeUpdated)
        {
            var productTypeUpdated = productTypesRepository.Update(mapper.Map<ProductTypeForUpdate, ProductType>(ProductTypeToBeUpdated));
            return Ok(productTypeUpdated);
        }
        
    }
}