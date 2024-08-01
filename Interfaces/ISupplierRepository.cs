using Microsoft.AspNetCore.Mvc;
using OfferAPI.Dto;
using OfferAPI.Models;

namespace OfferAPI.Interfaces
{
    public interface ISupplierRepository
    {
        public Task<ICollection<PopularSupplierDto>> GetPopularSuppliers();
    }
}
