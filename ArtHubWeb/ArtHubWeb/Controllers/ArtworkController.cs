using ArtHubWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace ArtHubWeb.Controllers
{
    public class ArtworkController : Controller
    {
        private readonly ApplicationDbContext context;
        public ArtworkController(ApplicationDbContext context) 
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var artworks = context.Artworks.ToList();
            return View(artworks);
        }
    }
}
