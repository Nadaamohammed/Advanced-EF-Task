namespace Advanced_EF.Dto;

public class PagedResult<T>
{
    public IReadOnlyList<T> Items { get; set; }
        = Array.Empty<T>();

    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public int TotalPages =>
        (int)Math.Ceiling((double)TotalCount / PageSize);
}
