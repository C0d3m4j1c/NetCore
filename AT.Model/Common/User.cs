using AT.IModel.Common;
namespace AT.Model.Common
{
    public class User : IEntity
    {
        public int Id {get; set;}
        
        public string UserName {get; set;}

        public bool IsDeleted {get; set;}
        
    }
}