using System;

namespace Core.Models.Material
{
    /// <summary>
    /// Материал для обновления значений материалов
    /// </summary>
    public class MaterialUpdateModel
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

        public DAL.Entity.Material GetEntity()
        {
            return new DAL.Entity.Material
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
