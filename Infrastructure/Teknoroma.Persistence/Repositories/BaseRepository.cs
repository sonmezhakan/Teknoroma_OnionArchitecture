using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
            try
            {
                //todo: ip işlemleri
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedComputerName = Environment.MachineName;
                entity.UpdatedIpAddress = "";
                entity.Status = Domain.Enums.DataStatus.Updated;

                _entities.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateRangeAsync(List<TEntity> entities)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
     
        #region Destroy
        
        public async Task DeleteAsync(TEntity entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(List<TEntity> entities)
        {
            _entities.RemoveRange(entities);
           await _context.SaveChangesAsync();
        }
        #endregion
        #region Get
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
            return _entities.AnyAsync(filter).Result;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.FirstOrDefaultAsync(filter);
        }
        #endregion
        #region GetAll
        
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                if(filter == null)
                {
                    var getList = await _entities.ToListAsync();
                    return getList;
                }
                else
                {
                    var getList = await _entities.Where(filter).ToListAsync();
                    return getList;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
       
        public async Task<List<TEntity>> GetAllActivesAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                if(filter != null)
                {
                    var getList = await _entities.Where(x => x.IsActive == true).Where(filter).ToListAsync();
                    return getList;
                }
                else
                {
                    var getList = await _entities.Where(x => x.IsActive == true).ToListAsync();
                    return getList;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        
        public async Task<List<TEntity>> GetAllPassivesAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                if (filter != null)
                {
                    var getList = await _entities.Where(x => x.IsActive == false).Where(filter).ToListAsync();
                    return getList;
                }
                else
                {
                    var getList = await _entities.Where(x => x.IsActive == false).ToListAsync();
                    return getList;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}

