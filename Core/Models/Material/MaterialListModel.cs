
namespace Core.Models.Material
{
    /// <summary>
    /// Параметры запроса для списка материалов
    /// </summary>
    public class MaterialListModel
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
