
using System;

namespace Core.Models.Material
{
    /// <summary>
    /// Модель-ответ деталей материала
    /// </summary>
    public class MaterialDetailAnswer : IAnswerModel<MaterialUpdateModel>
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
        public MaterialUpdateModel GetUpdateModel()
        {
            return new MaterialUpdateModel
            {
                Id = Id,
                Name = Name,
                Count = Count
            };
        }
    }
}
