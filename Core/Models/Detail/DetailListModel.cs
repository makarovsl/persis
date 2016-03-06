namespace Core.Models.Detail
{
    /// <summary>
    /// Параметры запроса для списка деталей
    /// </summary>
    public class DetailListModel
    {
        /// <summary>
        /// Номер запрашиваемой страницы
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Размер страницы
        /// </summary>
        public int PageSize { get; set; }
    }
}