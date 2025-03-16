using BookLibraryCleanArchitecture.Domain.Common.Interfaces;

namespace BookLibraryCleanArchitecture.Domain.Common
{
    public abstract class BaseEntity : IEquatable<BaseEntity>, IHasDomainEvents
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        
        public int Id { get; protected set; }

        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        
        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
        
        protected BaseEntity(int id)
        {
            Id = id;
        }
        protected BaseEntity() { }
        
        public override bool Equals(object? obj)
        {
            return obj is BaseEntity entity && Id.Equals(entity.Id);
        }

        public bool Equals(BaseEntity? other)
        {
            return Equals((object?)other);
        }

        public static bool operator ==(BaseEntity left, BaseEntity right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(BaseEntity left, BaseEntity right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
