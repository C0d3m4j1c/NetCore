using System.Collections.Generic;
using AT.IModel.Common;
namespace AT.Model.Common
{
    public class ProductType: IEntity
    {
        public ProductType () 
        {
            Products = new HashSet<Product>();
        }
        public int Id {get; set;}
        
        public string ProductTypeName {get; set;}

        public ICollection<Product> Products {get; set;}

        public string Comments {get; set;}
    }
}