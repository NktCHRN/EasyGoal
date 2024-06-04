using Ardalis.Specification.EntityFrameworkCore;
using EasyGoal.Backend.Domain.Abstractions;

namespace EasyGoal.Backend.Infrastructure.Database;
public sealed class GenericRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
    public GenericRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
    }
}
