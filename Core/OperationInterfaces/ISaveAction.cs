using System;
using Core.Models;

namespace Core.OperationInterfaces
{
    /// <summary>
    /// Интерфейс для выделения методов работы с созданием и изменением сущности
    /// </summary>
    /// <typeparam name="TUpdateModel">Класс модели обновления параметров</typeparam>
    /// <typeparam name="TAddModel">Класс модели добавления сущности</typeparam>
    /// <typeparam name="TDetailAnswer">Класс модели получения деталей</typeparam>
    public interface ISaveAction<TUpdateModel, TAddModel, TDetailAnswer> where TDetailAnswer: IAnswerModel<TUpdateModel>
    {
        Guid Update(TUpdateModel updateModel);
        Guid Add(TAddModel addModel);
        TDetailAnswer GetDetail(Guid id);
    }

}
