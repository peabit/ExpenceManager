namespace DataTransferObjects;

public record ReportBaseDto<TPosition>
{
    public DateTime From { get; init; }
    public DateTime To { get; init; }
    public IReadOnlyCollection<TPosition> Positions { get; init; }
}