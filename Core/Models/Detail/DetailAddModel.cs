using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entity;

namespace Core.Models.Detail
{
    /// <summary>
    /// Модель для добавления детали
    /// </summary>
    public class DetailAddModel
    {
   
        /// <summary>
        /// Наименование детали
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список выбранных материалов
        /// </summary>
        public List<ContainObjectItem> Materials;

        /// <summary>
        /// Получение сущности "Деталь" из модели
        /// </summary>
        /// <returns></returns>
        public DAL.Entity.Detail GetEntity()
        {
            return new DAL.Entity.Detail
            {
                Name = Name,
                IsDeleted = false
            };
        }

        /// <summary>
        /// Получение сущности "Материалы в составе детали" из модели
        /// </summary>
        /// <param name="detailId">Идентфикатор детали</param>
        /// <returns></returns>
        public List<MaterialOfDetail> GetMaterialOfDetailEntity(Guid detailId)
        {
            return
                Materials.Where(w => w.Id != null)
                    .GroupBy(g => g.Id)
                    .Select(
                        s =>
                            new MaterialOfDetail
                            {
                                DetailId = detailId,
                                MaterialId = s.Key ?? Guid.Empty,
                                MaterialCount = s.Sum(su => su.Count)
                            })
                    .ToList();
        }
    }
}