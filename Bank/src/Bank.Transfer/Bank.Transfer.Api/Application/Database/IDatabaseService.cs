
using Bank.Transfer.Api.Domain.Entities.Transfer;
using Microsoft.EntityFrameworkCore;

namespace Bank.Transfer.Api.Application.Database
{
    public interface IDatabaseService
    {
        DbSet<TransferEntity> Transfer { get; set; }
        Task<bool> SaveAsync();
    }
}
