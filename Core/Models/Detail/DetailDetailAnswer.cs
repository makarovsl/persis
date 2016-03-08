using System;
using System.Collections.Generic;

namespace Core.Models.Detail
{
    /// <summary>
    /// Модель-ответ деталей сущности "Деталь"
    /// </summary>
    public class DetailDetailAnswer: IAnswerModel<DetailUpdateModel>
    {
        /// <summary>
        /// Идентификатор детали
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование детали
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список выбранных материалов
        /// </summary>
        public List<ContainObjectItem> Materials;

        public DetailUpdateModel GetUpdateModel()
        {
            return new DetailUpdateModel
            {
                Id = Id,
                Name = Name,
                Materials = Materials
            };
        }
    }
}