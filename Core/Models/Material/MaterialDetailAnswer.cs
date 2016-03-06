
using System;

namespace Core.Models.Material
{
    /// <summary>
    /// Модель-ответ деталей материала
    /// </summary>
    public class MaterialDetailAnswer
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

    }
}
