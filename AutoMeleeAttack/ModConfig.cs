using StardewModdingAPI;

namespace AutoMeleeAttack;

public sealed class ModConfig
{
    public bool SkipRockCrab { get; set; }

    public int DetectTiles { get; set; } = 3;

    public SButton Toggle { get; set; } = SButton.Q;

    public SortedDictionary<string, bool>? SkipAlso { get; set; }
}