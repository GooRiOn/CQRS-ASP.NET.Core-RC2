namespace CQRS.Infrastructure.Interfaces.ReadSide
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; }

        void SoftDelete();
    }
}