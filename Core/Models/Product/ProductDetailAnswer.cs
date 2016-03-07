using System;
using System.Collections.Generic;

namespace Core.Models.Product
{
    /// <summary>
    /// Ответ деталей изделия
    /// </summary>
    public class ProductDetailAnswer
    {
        /// <summary>
        /// Идентификатор изделия
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование изделия
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список выбранных деталей
        /// </summary>
        public List<ContainObjectItem> Details;
    }
}