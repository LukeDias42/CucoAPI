using Cuco.Commons.Base;
using Microsoft.EntityFrameworkCore;

namespace Cuco.Infra.Data.Services.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly CucoDbContext Db;

    protected Repository(CucoDbContext db)
    {
        Db = db;
    }

    public async Task<TEntity> GetAsync(long id)
    {
        return await Db.Set<TEntity>()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<TEntity> GetAsNoTrackingAsync(long id)
    {
        return await Db.Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Db.Set<TEntity>()
            .ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsNoTrackingAsync()
    {
        return await Db.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();
    }

    public void Insert(TEntity entity)
    {
        Db.Set<TEntity>().Add(entity);
    }

    public void Delete(TEntity entity)
    {
        Db.Set<TEntity>()
            .Remove(entity);
    }
}