using System;
using System.Collections.Generic;

namespace Core.Models.Detail
{
    /// <summary>
    /// Модель-ответ деталей сущности "Деталь"
    /// </summary>
    public class DetailDetailAnswer
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

    }
}