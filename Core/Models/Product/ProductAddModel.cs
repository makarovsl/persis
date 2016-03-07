using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entity;

namespace Core.Models.Product
{
    public class ProductAddModel
    {

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
                Name = Name
            };
        }

        public List<DetailOfProduct> GetMaterialOfDetailEntity(Guid id)
        {
            return
                Details.Where(w => w.Id != null)
                    .GroupBy(g => g.Id)
                    .Select(
                        s =>
                            new DetailOfProduct
                            {
                                ProductId = id,
                                DetailId = s.Key ?? Guid.Empty,
                                DetailCount = s.Sum(su => su.Count)
                            })
                    .ToList();
        }
    }
}
