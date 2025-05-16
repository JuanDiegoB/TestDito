using Microsoft.EntityFrameworkCore.Storage;

namespace TestDito.Application.Interfaces;

public interface IUnitOfWork
{
	Task<IDbContextTransaction> BeginTransactionAsync();

	Task SaveChangesAsync();
}
