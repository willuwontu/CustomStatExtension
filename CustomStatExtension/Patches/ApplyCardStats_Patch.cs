using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using CustomStatExtension.Utils;
using UnityEngine;

namespace CustomStatExtension.Patches
{
    class ApplyCardStats_Patch
    {
        [HarmonyPrefix]
        static void CustomStatsApplied(ApplyCardStats __instance, Player ___playerToUpgrade, Gun ___myGunStats, CharacterStatModifiers ___myPlayerStats, Block ___myBlock)
        {
            var player = ___playerToUpgrade.GetComponent<Player>();
            var gun = ___playerToUpgrade.GetComponent<Holding>().holdable.GetComponent<Gun>();
            var characterData = ___playerToUpgrade.GetComponent<CharacterData>();
            var healthHandler = ___playerToUpgrade.GetComponent<HealthHandler>();
            var gravity = ___playerToUpgrade.GetComponent<Gravity>();
            var block = ___playerToUpgrade.GetComponent<Block>();
            var gunAmmo = gun.GetComponentInChildren<GunAmmo>();
            var characterStatModifiers = player.GetComponent<CharacterStatModifiers>();

            //StatDictionary.CopyCustomStats(player, gun, characterData, healthHandler, gravity, block, gunAmmo, characterStatModifiers, ___myGunStats, ___myPlayerStats, ___myBlock);
        }
    }
}
