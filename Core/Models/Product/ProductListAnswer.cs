using System;

namespace Core.Models.Product
{
    /// <summary>
    /// Модель-ответ для вывода табличного представления изделий
    /// </summary>
    public class ProductListAnswer
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
        /// Количество изделий, кторые можно произвести
        /// </summary>
        public decimal Count { get; set; }

    }
}