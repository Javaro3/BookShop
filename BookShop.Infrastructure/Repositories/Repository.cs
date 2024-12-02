using BookShop.Domains.Entities;
using BookShop.Infrastructure.Interfaces;
using BookShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Repositories;

/// <summary>
/// Базовый репозиторий
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
public class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly BookShopDbContext Context;
    protected readonly DbSet<T> DbSet;

    public Repository(BookShopDbContext context)
    {
        Context = context;
        DbSet = Context.Set<T>();
    }

    public virtual IQueryable<T> GetAll()
    {
        return DbSet.AsQueryable();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
        await Context.SaveChangesAsync();
    }
}