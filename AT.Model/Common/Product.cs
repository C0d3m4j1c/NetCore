using AT.IModel.Common;
namespace AT.Model.Common
{
    public class Product: IEntity
    {
        public int Id {get; set;}

        public int ProductName {get; set;}

        public int ProductTypeId {get; set;}

        public ProductType ProductType {get; set;}
    }
}