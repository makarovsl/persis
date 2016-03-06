using System;

namespace Core.Models.Detail
{
    /// <summary>
    /// Модель-ответ для вывода табличного представления деталей
    /// </summary>
    public class DetailListAnswer : IListAnswer
    {
        /// <summary>
        /// Идентификатор детали
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование детали
        /// </summary>
        public string Name { get; set; }
    }
}