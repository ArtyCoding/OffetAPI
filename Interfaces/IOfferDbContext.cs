using Microsoft.EntityFrameworkCore;
using OfferAPI.Models;
using System.Configuration.Provider;

namespace OfferAPI.Interfaces
{
    public interface IOfferDbContext
    {
        DbSet<OfferModel> Offers { get; }
        DbSet<ProviderModel> Providers { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
