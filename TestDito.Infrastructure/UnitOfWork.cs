using Microsoft.EntityFrameworkCore.Storage;
using TestDito.Application.Interfaces;

namespace TestDito.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
	private DatabaseContext DatabaseContext { get; }

	public UnitOfWork(DatabaseContext databaseContext)
	{
		DatabaseContext = databaseContext;
	}

	public async Task<IDbContextTransaction> BeginTransactionAsync()
	{
		return await DatabaseContext.Database.BeginTransactionAsync();
	}

	public async Task SaveChangesAsync()
	{
		await DatabaseContext.SaveChangesAsync();
	}
}
