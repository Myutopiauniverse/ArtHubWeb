using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ArtHubWeb.Data
{
    public class Artwork
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = "";
        [MaxLength(100)]
        public string Medium { get; set; } = "";   

        [MaxLength(100)]
        public string Image { get; set; } = "";
        [MaxLength(500)]
        public string Description { get; set; } = "";
        [MaxLength(100)]
        public string Type { get; set; } = "";
        [MaxLength(100)]
        public string Status { get; set; } = "";
        [Precision(16,2)]
        public double Height { get; set; }
        [Precision(16, 2)]
        public double Width { get; set; }
        [Precision(16, 2)]
        public double Depth { get; set; }
        [Precision(16, 2)]
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
