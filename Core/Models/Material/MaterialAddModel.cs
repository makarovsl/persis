namespace Core.Models.Material
{
    /// <summary>
    /// Модель для добавления материала
    /// </summary>
    public class MaterialAddModel
    {
        /// <summary>
        /// Наименование материала
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество материала
        /// </summary>
        public decimal? Count { get; set; }
        
        public DAL.Entity.Material GetEntity()
        {
            return new DAL.Entity.Material
            {
                Name = Name
            };
        }
    }
}
