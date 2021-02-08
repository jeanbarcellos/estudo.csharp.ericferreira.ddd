using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Restaurant.Domain.Entities;
using Restaurant.Infra.Data.Mappings;
using System;
using System.Linq;

namespace Restaurant.Infra.Data.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }

        public IDbContextTransaction Transaction { get; private set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            if (Database.GetPendingMigrations().Count() > 0)
            {
                Database.Migrate();
            }
        }

        // Configurar o banco de dados (e outras opções) a ser usado para este contexto
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        // configurar ainda mais o modelo que foi descoberto por convenção nos tipos de entidade
        // expostos nas propriedades DbSet <TEntity>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DishMap());
        }

        public IDbContextTransaction InitTransaction()
        {
            if (Transaction == null)
            {
                Transaction = this.Database.BeginTransaction();
            }

            return Transaction;
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        private void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        private void Save()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }

        public void SendChanges()
        {
            Save();
            Commit();
        }

    }
}
