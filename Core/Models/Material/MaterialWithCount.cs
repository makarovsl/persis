using System;

namespace Core.Models.Material
{
    public class MaterialWithCount
    {
        /// <summary>
        /// Идентификатор материала
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование материала
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество материала
        /// </summary>
        public decimal Count { get; set; }

        public MaterialDetailAnswer GetDetailModel()
        {
            return new MaterialDetailAnswer
            {
                Id = Id,
                Name = Name,
                Count = Count
            };
        }
    }
}