using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferAPI.Models;

namespace OfferAPI.EntityTypeConfig
{
    public class OfferConfiguration : IEntityTypeConfiguration<OfferModel>
    {
        public void Configure(EntityTypeBuilder<OfferModel> builder)
        {
            builder.HasKey(offer => offer.Id);
            builder.HasIndex(offer => offer.Id).IsUnique();
            builder.HasOne(offer => offer.Provider);
            builder.ToTable("Offer");
        }
    }
}
