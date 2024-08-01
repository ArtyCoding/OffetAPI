using OfferAPI.Models;

namespace OfferAPI.Dto
{
    public class CreateOfferDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProviderId { get; set; }

    }
}
