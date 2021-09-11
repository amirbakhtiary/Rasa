using Microsoft.EntityFrameworkCore;

namespace CardApi.Data
{
    public class CardsContext : DbContext
    {
        public CardsContext(DbContextOptions<CardsContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Card> Cards { get; set; }
    }
}
