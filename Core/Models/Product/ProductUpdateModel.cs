using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entity;

namespace Core.Models.Product
{
    /// <summary>
    /// Модель обновления изделия
    /// </summary>
    public class ProductUpdateModel
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

        public DAL.Entity.Product GetEntity()
        {
            return new DAL.Entity.Product
            {
                Id = Id,
                Name = Name
            };
        }

        public List<DetailOfProduct> GetMaterialOfDetailEntity()
        {
            return
                Details.Where(w => w.Id != null)
                    .GroupBy(g => g.Id)
                    .Select(
                        s =>
                            new DetailOfProduct
                            {
                                ProductId = Id,
                                DetailId = s.Key ?? Guid.Empty,
                                DetailCount = s.Sum(su => su.Count)
                            })
                    .ToList();
        }
    }
}
