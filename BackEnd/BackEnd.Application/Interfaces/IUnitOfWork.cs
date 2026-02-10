using System.Threading;
using System.Threading.Tasks;
using BackEnd.Application.Interfaces.Repositories;
using BackEnd.Domain.Common;

namespace BackEnd.Application.Interfaces;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    void MarkAsModified<TEntity>(TEntity entity) where TEntity : BaseEntity;
}


