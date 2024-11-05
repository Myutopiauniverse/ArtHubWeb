﻿namespace BlazorApp2.Data
{
    public class Artwork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Type { get; set; } // Medium type
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
    }
}
