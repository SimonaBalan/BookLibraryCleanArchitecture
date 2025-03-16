

using BookLibraryCleanArchitecture.Domain.UserAggregate;

namespace BookLibraryCleanArchitecture.Domain.Common.Interfaces
{
    public interface IAuditable
    {
        Guid? CreatedBy { get; set; } 
        DateTime CreatedOn { get; set; }
    }
}
