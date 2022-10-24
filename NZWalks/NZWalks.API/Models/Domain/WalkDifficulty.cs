namespace NZWalks.API.Models.Domain;

public class WalkDifficulty
{
    public WalkDifficulty()
    {
        Code = string.Empty;
    }

    public Guid Id { get; set; }
    public string Code { get; set; }
}
