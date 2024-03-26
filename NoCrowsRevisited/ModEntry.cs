using HarmonyLib;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
// ReSharper disable InconsistentNaming

namespace NoCrowsRevisited;

public class ModEntry : Mod
{
    private static IMonitor? _modMonitor;

    public override void Entry(IModHelper helper)
    {
        _modMonitor = Monitor;
        helper.Events.GameLoop.GameLaunched += OnGameLaunched;
    }

    private static void OnGameLaunched(object? sender, GameLaunchedEventArgs e)
    {
        var harmony = new Harmony("Siweipancc.NoCrowsRevisited");
        harmony.Patch(
            AccessTools.Method(typeof(Farm), "addCrows"),
            new HarmonyMethod(typeof(FarmPatch), "addCrows"));
        harmony.Patch(
            AccessTools.Method(typeof(Farm), "doSpawnCrow", new[] { typeof(Vector2) }),
            new HarmonyMethod(typeof(FarmPatch), "doSpawnCrow"));
    }


    private static class FarmPatch
    {
        // ReSharper disable once UnusedMember.Local
        public static bool addCrows(Farm __instance)
        {
            _modMonitor?.Log($"skip addCrows in farm :{__instance.DisplayName}");
            return false;
        }

        // ReSharper disable once UnusedMember.Local
        public static bool doSpawnCrow(GameLocation __instance, Vector2 __0)
        {
            _modMonitor?.Log($"skip doSpawnCrow in farm :{__instance.DisplayName} in position: {__0.X}:{__0.Y}");
            return false;
        }
    }
}