using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using BioMiniSlim.Core.Domains.Persons;
using BioMiniSlim.Data.Mappings.Persons;

namespace BioMiniSlim.Data.UnitOfWork
{
    public class UnitOfWork : DbContext, IUnitOfWork, IDisposable
    {
        #region Public Constructors

        public UnitOfWork() : base("ApplicationConnction")
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public IDbSet<TEntity> Repository<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public int CommitAllChanges()
        {
            try
            {
                base.SaveChanges();

            }
            catch (Exception ex)
            {
                var a = ex;
                
            }
            return 0;
        }

        public int CommitAllChangesAsync()
        {
            base.SaveChangesAsync();
            return 0;
        }

        public void Dispose()
        {
            base.Dispose();
        }

        public void RollbackAllChanges()
        {
            base.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        public void MarkAsModified<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Modified;
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add(new PluralizeConvention());

            modelBuilder.Entity<Person>().ToTable("BM_Persons");
            modelBuilder.Entity<PersonTemplate>().ToTable("BM_PersonTemplates");

            //modelBuilder.Configurations.Add(new PersonMap());
            //modelBuilder.Configurations.Add(new PersonTemplateMap());

            //var model = modelBuilder.Build(Database.Connection);
            //IDatabaseCreator sqliteDatabaseCreator = new SqliteDatabaseCreator();
            //sqliteDatabaseCreator.Create(Database, model);
            
        }

        #endregion Protected Methods
    }
}