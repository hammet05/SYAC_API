namespace Pedidos.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; init; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }


        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }
    }
}
