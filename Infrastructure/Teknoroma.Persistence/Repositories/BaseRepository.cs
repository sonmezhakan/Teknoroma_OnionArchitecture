using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Teknoroma.Application.Helpers.IpAddressHelpers;
using Teknoroma.Application.Services.Repositories;
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
            entity.CreatedComputerName = Environment.MachineName;
            entity.CreatedIpAddress = IpAddressFinder.GetHostName();
            entity.CreatedDate = DateTime.Now;
            entity.Status = Domain.Enums.DataStatus.Created;

			await _entities.AddAsync(entity);
			await _context.SaveChangesAsync();
		}
        
        public async Task AddRangeAsync(List<TEntity> entities)
        {
            entities.ForEach(entity =>
            {
                entity.CreatedComputerName = Environment.MachineName;
                entity.CreatedIpAddress = IpAddressFinder.GetHostName();
                entity.CreatedDate = DateTime.Now;
                entity.Status = Domain.Enums.DataStatus.Created;
            });

			await _context.AddRangeAsync(entities);
			await _context.SaveChangesAsync();
		}
        #endregion
        #region Update
        public async Task UpdateAsync(TEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedComputerName = Environment.MachineName;
            entity.UpdatedIpAddress = IpAddressFinder.GetHostName();
            entity.Status = Domain.Enums.DataStatus.Updated;

            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(List<TEntity> entities)
        {
            entities.ForEach(entity =>
            {
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedComputerName = Environment.MachineName;
                entity.UpdatedIpAddress = IpAddressFinder.GetHostName();
                entity.Status = Domain.Enums.DataStatus.Updated;
            });

            _entities.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
        #endregion
     
        #region Delete
        
        public async Task DeleteAsync(TEntity entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DeletedComputerName = Environment.MachineName;
            entity.DeletedIpAddress = IpAddressFinder.GetHostName();
            entity.Status = Domain.Enums.DataStatus.Deleted;
            entity.IsActive = false;

            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(List<TEntity> entities)
        {
            entities.ForEach(entity =>
            {
                entity.DeletedDate = DateTime.Now;
                entity.DeletedComputerName = Environment.MachineName;
                entity.DeletedIpAddress = IpAddressFinder.GetHostName();
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
			IQueryable<TEntity> query = _entities;
			return await query.Where(x=>x.IsActive == true).FirstOrDefaultAsync(filter);
        }
        #endregion
        #region GetAll
        
        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
			IQueryable<TEntity> query = _entities;

			if (filter == null)
            {
				query = query.Where(x => x.IsActive == true);
                return query;
            }

			query = query.Where(x => x.IsActive == true).Where(filter);
			return query;
		}
		#endregion




	}
}

