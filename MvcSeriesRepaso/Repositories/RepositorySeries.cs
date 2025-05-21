using Microsoft.EntityFrameworkCore;
using MvcSeriesRepaso.Data;
using MvcSeriesRepaso.Models;

namespace MvcSeriesRepaso.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;
        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        private async Task<int> GetMaxIdSeriesAsync()
        {
            return await this.context.Series.MaxAsync(x => x.IdSerie) + 1;
        }

        public async Task CreateSerieAsync(string nombre, string imagen, int anyo)
        {
            Serie serie = new Serie();
            serie.IdSerie = await this.GetMaxIdSeriesAsync();
            serie.Nombre = nombre;
            serie.Imagen = imagen;
            serie.Anyo = anyo;

            await this.context.Series.AddAsync(serie);
            await this.context.SaveChangesAsync();
        }

        public async Task<Serie> FindSerieAsync(int id)
        {
            return await this.context.Series.FirstOrDefaultAsync(x => x.IdSerie == id);
        }

        public async Task UpdateSerieAsync(int id, string nombre, string imagen, int anyo)
        {
            Serie serie = await this.FindSerieAsync(id);
            if (serie != null)
            {
                serie.Nombre = nombre;
                serie.Imagen = imagen;
                serie.Anyo = anyo;

                this.context.Series.Update(serie);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task DeleteSerieAsync(int id)
        {
            Serie serie = await this.FindSerieAsync(id);
            if (serie != null)
            {
                this.context.Series.Remove(serie);
                await this.context.SaveChangesAsync();
            }
        }

    }
}
