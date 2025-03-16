
namespace BookLibraryCleanArchitecture.Domain.Common
{
    public class AggregateRoot : BaseEntity
    {
        protected AggregateRoot(int id) : base(id) { }
        protected AggregateRoot() { }
    }
}
