using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Teknoroma.Application.Repositories;
using Teknoroma.Domain.Interfaces;

using Teknoroma.Persistence.Context;

namespace Teknoroma.Persistence.Repositories
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly TeknoromaContext _context;
        private readonly DbSet<TEntity> _entities;

        public BaseRepository(TeknoromaContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        #region Add
       
        public async Task AddAsync(TEntity entity)
        {
			await _entities.AddAsync(entity);
			await _context.SaveChangesAsync();
		}
        
        public async Task AddRangeAsync(List<TEntity> entities)
        {
			await _context.AddRangeAsync(entities);
			await _context.SaveChangesAsync();
		}
        #endregion
        #region Update
        public async Task UpdateAsync(TEntity entity)
        {
            //todo: ip işlemleri
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedComputerName = Environment.MachineName;
            entity.UpdatedIpAddress = "";
            entity.Status = Domain.Enums.DataStatus.Updated;

            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(List<TEntity> entities)
        {
            entities.ForEach(entity =>
            {
                //todo: ip işlemleri
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedComputerName = Environment.MachineName;
                entity.UpdatedIpAddress = "";
                entity.Status = Domain.Enums.DataStatus.Updated;
            });

            _entities.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
        #endregion
     
        #region Destroy
        
        public async Task DeleteAsync(TEntity entity)
        {
            //todo: ip işlemleri
            entity.DeletedDate = DateTime.Now;
            entity.DeletedComputerName = Environment.MachineName;
            entity.DeletedIpAddress = "";
            entity.Status = Domain.Enums.DataStatus.Deleted;
            entity.IsActive = false;

            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(List<TEntity> entities)
        {
            entities.ForEach(entity =>
            {
                //todo: ip işlemleri
                entity.DeletedDate = DateTime.Now;
                entity.DeletedComputerName = Environment.MachineName;
                entity.DeletedIpAddress = "";
                entity.Status = Domain.Enums.DataStatus.Deleted;
                entity.IsActive = false;
            });

            _entities.UpdateRange(entities);
           await _context.SaveChangesAsync();
        }
        #endregion
        #region Get
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
            return _entities.Where(x => x.IsActive == true).AnyAsync(filter).Result;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.Where(x=>x.IsActive == true).FirstOrDefaultAsync(filter);
        }
        #endregion
        #region GetAll
        
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                var getList = await _entities.Where(x => x.IsActive == true).ToListAsync();
                return getList;
            }
            else
            {
                var getList = await _entities.Where(x => x.IsActive == true).Where(filter).ToListAsync();
                return getList;
            }
        }

        #endregion
    }
}

