using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Models.Domain;

public class Walk
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Length { get; set; }

    [ForeignKey("Region")]
    public Guid? RegionId { get; set; }

    [ForeignKey("WalkDifficulty")]
    public Guid? WalkDifficultyId { get; set; }

    // Navigation property
    public Region Region { get; set; }
    public WalkDifficulty WalkDifficulty { get; set; }
}
