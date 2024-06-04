using Microsoft.EntityFrameworkCore.Storage;

namespace EasyGoal.Backend.Application.Abstractions.Infrastructure.Database;
public interface ITransactionProvider
{
    Task<IDbContextTransaction> BeginTransactionAsync();
}
