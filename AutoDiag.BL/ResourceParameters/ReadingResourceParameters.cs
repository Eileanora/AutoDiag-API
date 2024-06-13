namespace AutoDiag.BL.ResourceParameters;

public class ReadingResourceParameters : BaseResourceParameters
{
    private int _pageSize = 50;
    private const int MaxPageSize = 100;

    public ReadingResourceParameters()
    {
        OrderBy = "CreatedDate desc";
    }

    public string? CreatedDate { get; set; }

    public override int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
}
