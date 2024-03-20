using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Buildings;

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
            foreach (var building in Game1.getFarm().buildings)
            {
                if (building is not PetBowl bowl) continue;
                bowl.watered.Set(true);
            }
        }
    }
}