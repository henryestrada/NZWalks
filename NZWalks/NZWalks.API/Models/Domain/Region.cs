namespace NZWalks.API.Models.Domain;

public class Region
{
    public Region()
    {
        Code = string.Empty;
        Name = string.Empty;
        Walks = new List<Walk>();
    }

    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public double Area { get; set; }
    public double Lat { get; set; }
    public double Long { get; set; }
    public long population { get; set; }

    // Navigation property
    public IEnumerable<Walk> Walks { get; set; }

}
