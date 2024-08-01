using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OfferAPI.Models;

namespace OfferAPI.EntityTypeConfig
{
    public class ProviderConfiguration : IEntityTypeConfiguration<ProviderModel>
    {
        public void Configure(EntityTypeBuilder<ProviderModel> builder)
        {
            builder.HasKey(provider => provider.Id);
            builder.HasIndex(provider => provider.Id).IsUnique();
            builder.ToTable("Provider");
        }
    }
}
