using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronicle.Application.Repository;

namespace Chronicle.Application.Persistence
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
        Task<int> CommitIdentityAsync(CancellationToken cancellationToken = default);
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentityApplicationDbContext _identityContext;

        public UnitOfWork(IdentityApplicationDbContext identityContext)
        {
            _identityContext = identityContext;
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitIdentityAsync(CancellationToken cancellationToken = default)
        {
            return _identityContext.SaveChangesAsync(cancellationToken);
        }
    }
}
