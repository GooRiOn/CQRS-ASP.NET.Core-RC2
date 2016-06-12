namespace CQRS.ReadSide.Entities
{
    public class ItemEntity : InternalEntity
    {
        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}
