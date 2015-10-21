using System.Collections.Generic;

namespace SharedModels.Data.ContextInterfaces
{
    /// <summary>
    /// Generic interface implemented by repositories
    /// </summary>
    /// <typeparam name="TEntity">Type of model implemented</typeparam>
    /// <typeparam name="TKey">Type of key used for identification</typeparam>
    public interface IRepositoryContext<TEntity, in TKey> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetById(TKey id);
        TEntity Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
    }
}