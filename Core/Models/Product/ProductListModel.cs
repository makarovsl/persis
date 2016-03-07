namespace Core.Models.Product
{
    /// <summary>
    /// Параметры запроса для списка изделий
    /// </summary>
    public class ProductListModel
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