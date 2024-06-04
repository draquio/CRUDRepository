using CRUPersonRepository.Context;
using CRUPersonRepository.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CRUPersonRepository.Repository
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly AppDBContext _dbContext;

        public GenericRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TModel>> GetAll()
        {
            try
            {
                List<TModel> model = await _dbContext.Set<TModel>().ToListAsync();
                return model;
            }
            catch
            {
                throw;
            }
        }
        public async Task<TModel> GetById(int id)
        {
            try
            {
                TModel model = await _dbContext.Set<TModel>().FindAsync(id);
                return model;
            }
            catch
            {
                throw;
            }
        }
        public async Task<TModel> Create(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Update(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            { 
                return false; 
            } 
            catch (DbUpdateException)
            {
                return false;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Delete(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            catch (DbUpdateException)
            {
                return false;
            }
            catch
            {
                throw;
            }
        }

    }
}
