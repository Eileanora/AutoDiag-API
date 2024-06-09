namespace AutoDiag.BL.ResourceParameters;

public class CarSystemsResourceParameters : BaseResourceParameters
{
    public CarSystemsResourceParameters()
    {
        OrderBy = "CarSystemName";
    }
    // filters
    public string? CarSystemName { get; set; }
}
