using System.Data.Entity;

namespace BioMiniSlim.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        int CommitAllChanges();

        int CommitAllChangesAsync();

        IDbSet<TEntity> Repository<TEntity>() where TEntity : class;


    }
}
