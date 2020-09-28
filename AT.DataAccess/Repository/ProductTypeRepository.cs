using System.Collections.Generic;
using System.Linq;
using AT.DataAccess.Data;
using AT.IDataAccess.IRepository;
using AT.Model.Common;

namespace AT.DataAccess.Repository
{
    public class ProductTypeRepository : IRepository<ProductType>
    {
        private readonly ATDbContext context;
        public ProductTypeRepository(ATDbContext Context)
        {
            context = Context;
        }
        
        public IEnumerable<ProductType> GetAll()
        {
            return context.ProductTypes.ToList();
        }

        public ProductType GetById(int Id)
        {
            return context.ProductTypes.Find(Id);
        }

        public ProductType Update(ProductType Entity)
        {
            var productsTypeToBeUpdated = context.ProductTypes.Find(Entity.Id);
            if(productsTypeToBeUpdated != null)
            {
                productsTypeToBeUpdated.ProductTypeName = Entity.ProductTypeName;
                productsTypeToBeUpdated.Comments = Entity.Comments;
                context.ProductTypes.Update(productsTypeToBeUpdated);
                context.SaveChanges();
            }
            return productsTypeToBeUpdated; 
        }        

        public ProductType Create(ProductType Entity)
        {
            context.ProductTypes.Add(Entity);
            context.SaveChanges();
            return Entity;
        }

        public ProductType Delete(ProductType Entity)
        {
            var productTypeToBeDeleted = context.ProductTypes.Find(Entity.Id);
            if(productTypeToBeDeleted != null)
            {
                context.ProductTypes.Remove(productTypeToBeDeleted);
                context.SaveChanges();
            }
            return productTypeToBeDeleted;
        }        
    }
}