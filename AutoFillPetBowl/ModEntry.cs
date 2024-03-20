using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace AutoFillPetBowl
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.DayStarted += FillBowl;
        }

        private static void FillBowl(object? sender, DayStartedEventArgs e)
        {
            var pet = Game1.MasterPlayer.getPet();
            pet?.GetPetBowl()?.watered.Set(true);
        }
    }
}