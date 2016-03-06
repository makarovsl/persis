namespace DAL.Common.Entity
{
    public interface IRemovableEntity : IEntity
    {
         bool IsDeleted { get; set; }
    }
}