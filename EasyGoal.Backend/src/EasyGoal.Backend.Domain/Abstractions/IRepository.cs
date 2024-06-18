using Ardalis.Specification;

namespace EasyGoal.Backend.Domain.Abstractions;
public interface IRepository<T> : IRepositoryBase<T> where T : class
{
    T AddAsUnsaved(T entity);
}
