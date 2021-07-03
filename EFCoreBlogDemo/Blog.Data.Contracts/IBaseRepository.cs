using System.Collections.Generic;
using System.Threading.Tasks;

using Blog.Data.Contracts.Specifications;
using Blog.Data.EF;

namespace Blog.Data.Contracts
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id, IBaseSpecifications<TEntity> baseSpecifications = null);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(int id);
    }
}
