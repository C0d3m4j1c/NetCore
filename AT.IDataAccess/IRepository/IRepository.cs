using System.Collections.Generic;

namespace AT.IDataAccess.IRepository
{
    public interface IRepository<IEntity>
    {
        IEnumerable<IEntity> GetAll();

        IEntity GetById(int Id);
        
        IEntity Create(IEntity Entity);

        IEntity Update(IEntity Entity);

        void Delete(IEntity Entity);

    }
}