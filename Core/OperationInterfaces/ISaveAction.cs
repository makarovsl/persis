using System;
using Core.Models;

namespace Core.OperationInterfaces
{
    public interface ISaveAction<TUpdateModel, TAddModel, TDetailAnswer> where TDetailAnswer: IAnswerModel<TUpdateModel>
    {
        Guid Update(TUpdateModel updateModel);
        Guid Add(TAddModel addModel);
        TDetailAnswer GetDetail(Guid id);
    }

}
