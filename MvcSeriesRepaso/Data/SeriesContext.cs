using Microsoft.EntityFrameworkCore;
using MvcSeriesRepaso.Models;

namespace MvcSeriesRepaso.Data
{
    public class SeriesContext : DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options) : base(options) { }

        public DbSet<Serie> Series { get; set; }
    }
}
