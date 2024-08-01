using Microsoft.EntityFrameworkCore;
using OfferAPI.Data;
using OfferAPI.Dto;
using OfferAPI.Interfaces;

namespace OfferAPI.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly OfferAPIContext _context;
        public SupplierRepository(OfferAPIContext context) => _context = context;
        public async Task<ICollection<PopularSupplierDto>> GetPopularSuppliers()
        {
            var topOffers = await _context.Offers
                .Select(o => o.Provider)
                .GroupBy(p => p)
                .Select(g => new PopularSupplierDto { Name = g.Key.Name, OffersCount = g.Count() })
                .OrderByDescending(o => o.OffersCount)
                .Take(3)
                .ToListAsync();

            return topOffers;
        }
    }
}
