using Microsoft.EntityFrameworkCore;
using BackEnd.Application.Interfaces.Repositories;
using BackEnd.Domain.Entities;
using BackEnd.Infrastructure.Context;

namespace BackEnd.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
        => await _context.Users.AddAsync(user, cancellationToken);

    public Task DeleteAsync(User user, CancellationToken cancellationToken = default)
    {
        _context.Users.Remove(user);
        return Task.CompletedTask;
    }

    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _context.Users.ToListAsync(cancellationToken);

    public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _context.Users.FindAsync(new object[] { id }, cancellationToken);

    public Task UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        _context.Users.Update(user);
        return Task.CompletedTask;
    }

}
