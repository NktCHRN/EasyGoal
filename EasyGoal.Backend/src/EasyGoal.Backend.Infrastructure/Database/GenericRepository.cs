using Ardalis.Specification.EntityFrameworkCore;
using EasyGoal.Backend.Domain.Abstractions;

namespace EasyGoal.Backend.Infrastructure.Database;
public class GenericRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
    protected readonly ApplicationDbContext ApplicationDbContext;

    public GenericRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public T AddAsUnsaved(T entity)
    {
        ApplicationDbContext.Set<T>().Add(entity);

        return entity;
    }
}
