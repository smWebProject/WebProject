﻿namespace DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string CategoryName { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
