using System;
using System.Collections.Generic;

namespace Core.Models.Product
{
    /// <summary>
    /// Ответ деталей изделия
    /// </summary>
    public class ProductDetailAnswer : IAnswerModel<ProductUpdateModel>
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

        public ProductUpdateModel GetUpdateModel()
        {
            return new ProductUpdateModel
            {
                Id = Id,
                Name = Name,
                Details = Details
            };
        }
    }
}