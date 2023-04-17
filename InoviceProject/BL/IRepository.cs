using System.Collections.Generic;

namespace InoviceProject.BL
{
    public interface IRepository<TEntity>where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity Entity);
        void Update(TEntity Entity);
        void Delete(int id);
    }
}
