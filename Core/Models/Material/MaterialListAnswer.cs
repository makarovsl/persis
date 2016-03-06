
using System;

namespace Core.Models.Material
{
    /// <summary>
    /// Модель-ответ для вывода табличного представления материалов
    /// </summary>
    public class MaterialListAnswer : IListAnswer
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
