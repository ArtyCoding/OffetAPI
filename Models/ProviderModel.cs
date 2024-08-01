using System.ComponentModel.DataAnnotations.Schema;

namespace OfferAPI.Models
{
    public class ProviderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public ProviderModel()
        {
            CreationDate = DateTime.Now;
        }
    }
}
