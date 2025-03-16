using BookLibraryCleanArchitecture.Domain.Common.Interfaces;
using BookLibraryCleanArchitecture.Domain.UserAggregate;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookLibraryCleanArchitecture.Domain.Common
{
    public abstract class AuditableAggregate : AggregateRoot, IAuditable
    {
        [ForeignKey("ApplicationUser")]
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
