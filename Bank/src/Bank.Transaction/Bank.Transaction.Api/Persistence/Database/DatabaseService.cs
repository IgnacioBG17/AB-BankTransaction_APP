using Bank.Transaction.Api.Application.Database;
using Bank.Transaction.Api.Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;

namespace Bank.Transaction.Api.Persistence.Database
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public DatabaseService(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TransactionEntity> Transaction { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
