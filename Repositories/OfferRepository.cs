using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfferAPI.Data;
using OfferAPI.Dto;
using OfferAPI.Interfaces;
using OfferAPI.Models;

namespace OfferAPI.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly OfferAPIContext _context;
        public OfferRepository(OfferAPIContext context) => _context = context;

        public async Task<OfferModel> CreateOffer(CreateOfferDto offer)
        {
            var newOffer = new OfferModel();
            var supplier = await _context.Providers.Where(x => x.Id == offer.ProviderId).FirstOrDefaultAsync();
            if (supplier != null)
            {
                newOffer = new OfferModel
                {
                    Brand = offer.Brand,
                    Model = offer.Model,
                    Provider = supplier,
                    RegistationDate = DateTime.Now,
                };
                _context.Offers.Add(newOffer);
                await _context.SaveChangesAsync();
                return newOffer;
            }
            return newOffer;
        }

        public async Task<ICollection<OfferModel>> FindOffers(string searchingValue)
        {
            var offers = await _context.Offers
                .Include(prov => prov.Provider)
                .Where(offer => offer.Brand.Contains(searchingValue)
                    || offer.Model.Contains(searchingValue)
                    || offer.Provider.Name.Contains(searchingValue))
                .ToListAsync();
            return offers;
        }
    }
}
