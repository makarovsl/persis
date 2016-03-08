using System;

namespace Core.Models.Product
{
    public class MaterialOfProduct
    {
        public string ProductName { get; set; }
        public Guid ProductId { get; set; }
        public Guid MaterialId { get; set; }
        public decimal MaterialCount { get; set; }
    }
}