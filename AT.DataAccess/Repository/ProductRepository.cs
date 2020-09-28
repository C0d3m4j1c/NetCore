using System.Collections.Generic;
using System.Linq;
using AT.DataAccess.Data;
using AT.IDataAccess.IRepository;
using AT.Model.Common;

namespace AT.DataAccess.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ATDbContext context;
        public ProductRepository(ATDbContext Context)
        {
            context = Context;
        }       

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(int Id)
        {
            return context.Products.Find(Id);
        }

        public Product Update(Product Entity)
        {
            var productToBeUpdated = context.Products.Find(Entity.Id);
            if(productToBeUpdated != null)
            {
                productToBeUpdated.ProductName = Entity.ProductName;
                productToBeUpdated.ProductTypeId = Entity.ProductTypeId;
                context.Products.Update(productToBeUpdated);
                context.SaveChanges();
                return productToBeUpdated;
            }
            return null; 
        }

        public Product Create(Product Entity)
        {
            context.Products.Add(Entity);
            context.SaveChanges();
            return Entity;
        }

        public Product Delete(Product Entity)
        {
            var productsToBeDeleted = context.Products.Find(Entity.Id);
            if(productsToBeDeleted != null)
            {
                context.Products.Remove(productsToBeDeleted);
                context.SaveChanges();
                return productsToBeDeleted;
            }
            return null; 
        }
    }
}