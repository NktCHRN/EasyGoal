using EasyGoal.Backend.Application.Abstractions.Infrastructure.Database;
using Microsoft.EntityFrameworkCore.Storage;

namespace EasyGoal.Backend.Infrastructure.Database;
public sealed class TransactionProvider : ITransactionProvider
{
    private readonly ApplicationDbContext _applicationDbContext;

    public TransactionProvider(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return _applicationDbContext.Database.BeginTransactionAsync();
    }

}
