// Data/DbInitializer.cs
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BlazorApp2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            // Check if Artworks table already has data
            if (context.Artworks.Any())
            {
                return; // DB has already been seeded
            }

            var artworks = new[]
            {
                new Artwork { Name = "Sunfire", ImageUrl = "/images/image1.jpg", Medium = "Watercolor", Description = "Description of Sunfire", Status = "SOLD" },
                new Artwork { Name = "The Silent Shore", ImageUrl = "/images/image2.jpg", Medium = "Acrylic Paint", Description = "Description of The Silent Shore", Status = "R14 000" },
                // Add more artworks as needed
            };

            context.Artworks.AddRange(artworks);
            context.SaveChanges();
        }
    }
}
