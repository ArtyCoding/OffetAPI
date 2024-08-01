using System.ComponentModel.DataAnnotations.Schema;

namespace OfferAPI.Models
{
    public class OfferModel
    {
        public int Id { get; private set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public ProviderModel Provider{ get; set; }
        public DateTime RegistationDate { get; set; }

    }
}
