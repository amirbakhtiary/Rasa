using CardApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardApi.Data
{
    public class CardsContextSeed
    {
        public static void SeedAsync(CardsContext cardsContext)
        {
            if (!cardsContext.Cards.Any())
            {
                var movies = new List<Card>
                {
                    new Card
                    {
                        Id = 1,
                        Title = "Normal",
                        CardNo="5894631532021234",
                        ExpiryYear=2022,
                        ExpiryMonth=5,
                        CVV2=223,
                        HolderName="Amir"
                    },
                    new Card
                    {
                        Id = 2,
                        Title = "Visa",
                        CardNo="2345631532021234",
                        ExpiryYear=2023,
                        ExpiryMonth=9,
                        CVV2=456,
                        HolderName="John"
                    },
                    new Card
                    {
                        Id = 3,
                        Title = "Master",
                        CardNo="9878341532021234",
                        ExpiryYear=2024,
                        ExpiryMonth=1,
                        CVV2=855,
                        HolderName="Smith"
                    },
                    new Card
                    {
                        Id = 4,
                        Title = "Visa",
                        CardNo="4326761532021234",
                        ExpiryYear=2025,
                        ExpiryMonth=7,
                        CVV2=675,
                        HolderName="Rasoul"
                    }

                };
                cardsContext.Cards.AddRange(movies);
                cardsContext.SaveChanges();
            }
        }
    }
}
