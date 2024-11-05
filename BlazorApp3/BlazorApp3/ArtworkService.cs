using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BlazorApp3
{
    public class ArtworkService
    {
        private readonly ArtHubContext _context;

        public ArtworkService(ArtHubContext context)
        {
            _context = context;
        }

        public async Task<List<Artwork>> GetArtworksAsync()
        {
            return await _context.Artworks.ToListAsync();
        }
    }
}
