namespace BookLibraryCleanArchitecture.Application.Entities.DataTransferObjects
{
    public class ExternalAuthDto
    {
        public string? Provider { get; set; }
        public string? IdToken { get; set; }
    }
}
