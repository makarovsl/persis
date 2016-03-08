using System.Security.Cryptography.X509Certificates;

namespace Core.Models
{
    public interface IAnswerModel<TUpdateModel>
    {
        TUpdateModel GetUpdateModel();

    }
}
