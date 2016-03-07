using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entity;

namespace Core.Models.Detail
{
    /// <summary>
    /// Класс модель для обновления данных детали
    /// </summary>
    public class DetailUpdateModel
    {
        /// <summary>
        /// Идентификатор детали
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование детали
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список выбранных материалов
        /// </summary>
        public List<ContainObjectItem> Materials;

        public DAL.Entity.Detail GetEntity()
        {
            return new DAL.Entity.Detail
            {
                Id = Id,
                Name = Name,
                IsDeleted = false
            };
        }

        public MaterialOfDetail[] GetMaterialOfDetailEntity()
        {
            return
                Materials.Where(w => w.Id != null)
                    .GroupBy(g => g.Id)
                    .Select(
                        s =>
                            new MaterialOfDetail
                            {
                                DetailId = Id,
                                MaterialId = s.Key??Guid.Empty,
                                MaterialCount = s.Sum(su => su.Count)
                            })
                    .ToArray();
        }
    }
}