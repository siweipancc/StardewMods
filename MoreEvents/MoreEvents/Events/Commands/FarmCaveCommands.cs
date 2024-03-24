using MoreEvents.Events.Precondition;
using StardewValley;
using StardewValley.Locations;

namespace MoreEvents.Events.Commands;

public class FarmCaveCommands
{
    ///  <summary> 洞穴升级.
    /// 见 <see cref="FarmCavePreconditions.FarmCaveFirstComplete"/></summary>
    public static void FarmCaveUpgrade(Event @event, string[] args, EventContext context)
    {
        var wrapper = Game1.MasterPlayer.caveChoice;
        var lastCave = wrapper?.Value;
        switch (lastCave)
        {
            // 水果 + 蘑菇
            case 1:
                Game1.RequireLocation<FarmCave>("FarmCave").setUpMushroomHouse();
                break;
            // 蘑菇 + 水果
            case 2:
                wrapper!.Set(1);
                ++@event.CurrentCommand;
                break;
            // 错误状态
            default:
                context.LogErrorAndSkip("必须在洞穴事件后");
                break;
        }

        ++@event.CurrentCommand;
    }
}