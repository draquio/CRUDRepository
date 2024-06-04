using System.Linq.Expressions;

namespace CRUPersonRepository.Repository.Interface
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> GetById(int id);
        Task<TModel> Create(TModel model);
        Task<bool> Update(TModel model);
        Task<bool> Delete(TModel model);
    }
}
