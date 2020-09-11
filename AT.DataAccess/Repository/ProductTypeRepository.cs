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
            var productsTypeBeDeleted = context.ProductTypes.Find(Entity.Id);
            if(productsTypeBeDeleted != null)
            {
                productsTypeBeDeleted.ProductTypeName = Entity.ProductTypeName;
                context.ProductTypes.Update(productsTypeBeDeleted);
                context.SaveChanges();
            }
            return productsTypeBeDeleted; 
        }        

        public ProductType Create(ProductType Entity)
        {
            context.ProductTypes.Add(Entity);
            context.SaveChanges();
            return Entity;
        }

        public void Delete(ProductType Entity)
        {
            var productsToBeDeleted = context.ProductTypes.Find(Entity.Id);
            if(productsToBeDeleted != null)
            {
                context.ProductTypes.Remove(productsToBeDeleted);
                context.SaveChanges();
            }
        }
    }
}