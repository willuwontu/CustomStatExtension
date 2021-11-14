using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HarmonyLib;
using CustomStatExtension.Utils;
using CustomStatExtension.Extensions;
using UnityEngine;

namespace CustomStatExtension.Patches
{
    class ApplyCardStats_Patch
    {
        [HarmonyPrefix]
        static void CustomStatsApplied(ApplyCardStats __instance, Player ___playerToUpgrade, CharacterStatModifiers ___myPlayerStats)
        {
            var player = ___playerToUpgrade.GetComponent<Player>();
            var stats = player.GetComponent<CharacterStatModifiers>();
            var registeredStats = CustomStatManager.instance.RegisteredStats.Select((stat) => stat.Key).ToArray();

            foreach (var stat in ___myPlayerStats.GetCustomStats().stats)
            {
                if (registeredStats.Contains(stat.Key))
                {
                    try
                    {
                        var curr = stats.GetCustomStats().stats[stat.Key];

                        var newVal = CustomStatManager.instance.customStatApplyStatsOperation[stat.Key](curr, stat.Value);

                        stats.GetCustomStats().stats[stat.Key] = newVal;
                    }
                    catch (Exception)
                    {
                        UnityEngine.Debug.Log($"[CSE] Custom Stat operation failed for player {___playerToUpgrade.playerID}.\n\tCustom Stat: {stat.Key}\n\t\tCurrent Value: {stats.GetCustomStats().stats[stat.Key]} \n\t\tCurrent Type: {stats.GetCustomStats().stats[stat.Key].GetType()}\n\t\tIncoming value: {stat.Value}\n\t\tIncoming Type: {stat.Value.GetType()}");
                    }
                }
            }
        }
    }
}
