using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using HarmonyLib;

namespace CustomStatExtension
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class CustomStatExtension : BaseUnityPlugin
    {
        private const string ModId = "com.willuwontu.rounds.customstatextension";
        private const string ModName = "Custom Stat Extension";
        public const string Version = "0.0.1"; // What version are we on (major.minor.patch)?

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {

        }
    }
}