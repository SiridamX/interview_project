using System.Threading;
using Microsoft.EntityFrameworkCore;
using BackEnd.Application.Interfaces;
using BackEnd.Application.Interfaces.Repositories;
using BackEnd.Domain.Common;
using BackEnd.Infrastructure.Context;

namespace BackEnd.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IUserRepository Users { get; }

    public UnitOfWork(
        ApplicationDbContext context,
        IUserRepository userRepository)
    {
        _context = context;
        Users = userRepository;
    }

    public async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void MarkAsModified<TEntity>(TEntity entity)
        where TEntity : BaseEntity
    {
        _context.Entry(entity).State = EntityState.Modified;
    }
}

