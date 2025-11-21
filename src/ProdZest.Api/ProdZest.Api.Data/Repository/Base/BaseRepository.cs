using Microsoft.EntityFrameworkCore;
using ProdZest.Api.Data.Context;
using ProdZest.Api.Domain.Interfaces.Repository.Base;
using System.Linq.Expressions;

namespace ProdZest.Api.Data.Repository.Base;
public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    protected readonly ProdZestContext _prodZestContext;
    protected readonly DbSet<TEntity> DbSet;

    public BaseRepository(ProdZestContext prodZestContext)
    {
        _prodZestContext = prodZestContext;
        DbSet = prodZestContext.Set<TEntity>();
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await _prodZestContext.Set<TEntity>().AddAsync(entity);
        await _prodZestContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task AddRangeAsync(IList<TEntity> entity)
    {
        await DbSet.AddRangeAsync(entity);
    }

    public async Task<TEntity> Delete(long Id)
    {
        var entity = await _prodZestContext.Set<TEntity>().FindAsync(Id);
        if (entity == null)
            return entity;

        _prodZestContext.Set<TEntity>().Remove(entity);
        await _prodZestContext.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> DeleteAsync(long Id)
    {
        var entity = await _prodZestContext.Set<TEntity>().FindAsync(Id);
        if (entity == null)
            return entity;

        _prodZestContext.Set<TEntity>().Remove(entity);
        await _prodZestContext.SaveChangesAsync();

        return entity;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _prodZestContext.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _prodZestContext.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
    }

    public async Task<TEntity> GetByIdAsync(long Id)
    {
        var result = await _prodZestContext.Set<TEntity>().FindAsync(Id);
        return result;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _prodZestContext.Entry(entity).State = EntityState.Modified;
        await _prodZestContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> models)
    {
        if (models == null)
            throw new ArgumentNullException(nameof(models));

        DbSet.UpdateRange(models);
    }
}
