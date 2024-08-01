using OfferAPI.Data;
using OfferAPI.Models;

namespace OfferAPI
{
    public class Seed
    {
        private readonly OfferAPIContext _context;
        public Seed(OfferAPIContext context) => _context = context;

        public void SeedDataContext()
        {
            var coolAutoProvider = new ProviderModel
            {
                Name = "Крутое авто",
                CreationDate = new DateTime(2022, 03, 15)
            };
            var rusProvider = new ProviderModel
            {
                Name = "RUSAUTO",
                CreationDate = new DateTime(2022, 03, 15)
            };
            var pontAutoProvider = new ProviderModel
            {
                Name = "Понт авто",
                CreationDate = new DateTime(2022, 03, 15)
            };
            var familyAutoProvider = new ProviderModel
            {
                Name = "Cемейное авто",
                CreationDate = new DateTime(2022, 03, 15)
            };
            var fastAuto = new ProviderModel
            {
                Name = "Гонка авто",
                CreationDate = new DateTime(2022, 03, 15)
            };
            _context.Providers.Add(coolAutoProvider);
            _context.Providers.Add(rusProvider);
            _context.Providers.Add(pontAutoProvider);
            _context.Providers.Add(fastAuto);
            _context.Providers.Add(familyAutoProvider);
            _context.SaveChanges();
            // if(!_context.Offers.Any())
            //{
            var offers = new List<OfferModel>()
                {
                    new OfferModel
                    {
                        Brand = "Хундай",
                        Model = "Solaris",
                        Provider = coolAutoProvider
                    },
                    new OfferModel
                    {
                        Brand = "Тойота",
                        Model = "Камри",
                        Provider = pontAutoProvider,
                        RegistationDate = new DateTime(2023, 06, 18)
                    },
                    new OfferModel
                    {
                        Brand = "Lada",
                        Model = "2114",
                        Provider = rusProvider,
                        RegistationDate = new DateTime(2023, 06, 18)
                    },
                    new OfferModel
                    {
                        Brand = "Lada",
                        Model = "2114",
                        Provider = fastAuto,
                        RegistationDate = new DateTime(2023, 06, 18)
                    },
                    new OfferModel
                    {
                        Brand = "Lada",
                        Model = "Vesta",
                        Provider = rusProvider,
                        RegistationDate = new DateTime(2023, 06, 18)
                    },
                    new OfferModel
                    {
                        Brand = "Lada",
                        Model = "2108",
                        Provider = fastAuto,
                        RegistationDate = new DateTime(2023, 06, 18)
                    },
                    new OfferModel
                    {
                        Brand = "Lada",
                        Model = "2112",
                        Provider = rusProvider,
                        RegistationDate = new DateTime(2023, 06, 18)
                    },
                    new OfferModel
                    {
                        Brand = "Lada",
                        Model = "2115",
                        Provider = rusProvider,
                        RegistationDate = new DateTime(2023, 06, 18)
                    },
                    new OfferModel
                    {
                        Brand = "Lada",
                        Model = "2114",
                        Provider = rusProvider,
                        RegistationDate = new DateTime(2023, 06, 18)
                    }
                };
                _context.Offers.AddRange(offers);
                _context.SaveChanges();
            //}
        }
    }
}
