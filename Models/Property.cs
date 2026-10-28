namespace wt_lab6_6minimalapi_kobzeva.Models;

public class Property
{
    public int Id { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public double Area { get; set; }
    public int Rooms { get; set; }
    public bool IsAvailable { get; set; }
}