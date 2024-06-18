using Ardalis.Specification.EntityFrameworkCore;
using EasyGoal.Backend.Domain.Abstractions;

namespace EasyGoal.Backend.Infrastructure.Database;
public sealed class GenericRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
    private readonly ApplicationDbContext _applicationDbContext;

    public GenericRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public T AddAsUnsaved(T entity)
    {
        _applicationDbContext.Set<T>().Add(entity);

        return entity;
    }
}
