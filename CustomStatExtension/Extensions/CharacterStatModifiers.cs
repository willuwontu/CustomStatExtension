using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CustomStatExtension.Utils;
using HarmonyLib;

namespace CustomStatExtension.Extensions
{
    [Serializable]
    public class CustomStatsData
    {
        public Dictionary<string, object> stats;

        public CustomStatsData()
        {
            stats = new Dictionary<string, object>();
            foreach (var stat in CustomStatManager.instance.RegisteredStats)
            {
                stats.Add(stat.Key, stat.Value);
            }
        }
    }

    public static class CharacterStatModifiersExtension
    {
        public static readonly ConditionalWeakTable<CharacterStatModifiers, CustomStatsData> data =
            new ConditionalWeakTable<CharacterStatModifiers, CustomStatsData>();

        public static CustomStatsData GetCustomStats(this CharacterStatModifiers statModifiers)
        {
            return data.GetOrCreateValue(statModifiers);
        }

        public static void AddData(this CharacterStatModifiers statModifiers, CustomStatsData value)
        {
            try
            {
                data.Add(statModifiers, value);
            }
            catch (Exception) { }
        }
    }

    [HarmonyPatch(typeof(CharacterStatModifiers), "ResetStats")]
    class CharacterStatModifiersPatchResetStats
    {
        private static void Prefix(CharacterStatModifiers __instance)
        {
            __instance.GetCustomStats().stats = new Dictionary<string, object>();
            foreach (var stat in CustomStatManager.instance.RegisteredStats)
            {
                __instance.GetCustomStats().stats.Add(stat.Key, stat.Value);
            }
        }
    }
}
