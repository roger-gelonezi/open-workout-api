namespace OpenWorkout.Services.Abstractions.Dto
{
    public class ListParamsDto
    {
        public DateTime? LastUpdateSince { get; set; }
        public string? OrderBy { get; set; }
        public int? PageSize { get; set; }
        public int? Page { get; set; }
    }
}
