using Microsoft.AspNetCore.Mvc;
using OfferAPI.Dto;
using OfferAPI.Models;

namespace OfferAPI.Interfaces
{
    public interface IOfferRepository
    {
        public Task<ICollection<OfferModel>> FindOffers(string searchingValue);
        public Task<OfferModel> CreateOffer(CreateOfferDto offer);
    }
}
