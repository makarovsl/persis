using System;

namespace Core.Models.Material
{
    public class MaterialOfDetailItem
    {
        public Guid MaterialId { get; set; }
        public string MaterialName { get; set; }
        public decimal MaterialCount { get; set; }
    }
}
