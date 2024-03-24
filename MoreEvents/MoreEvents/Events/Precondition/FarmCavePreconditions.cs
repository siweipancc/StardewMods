using StardewValley;

namespace MoreEvents.Events.Precondition;

using static Logger;

public class FarmCavePreconditions
{
    /// <summary> 检查农场洞穴事件是否已经触发.</summary>
    /// <param name="location">The location which is checking the event.</param>
    /// <param name="eventId">The unique ID for the event being checked.</param>
    /// <param name="args">The space-delimited event precondition string, including the precondition name.</param>
    public static bool FarmCaveFirstComplete(GameLocation location,
        string eventId, string[] args)
    {
        int caveChoiceValue = Game1.MasterPlayer.caveChoice.Value;
        Trace(
            $"[FarmCaveFirstComplete] event : {eventId} , caveChoiceValue: {caveChoiceValue}");
        return caveChoiceValue is 1 or 2;
    }
}