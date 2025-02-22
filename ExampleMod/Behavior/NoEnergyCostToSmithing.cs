using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace ExampleMod.Behavior
{
    [HarmonyPatch(typeof(CraftingCampaignBehavior))]
    public class NoEnergyCostToSmithing : DefaultSmithingModel
    {
        public override int GetEnergyCostForRefining(ref Crafting.RefiningFormula refineFormula, Hero hero) => 0;
        public override int GetEnergyCostForSmithing(ItemObject item, Hero hero) => 0;
        public override int GetEnergyCostForSmelting(ItemObject item, Hero hero) => 0;

        // Set stamina of all heroes of main party to 1k
        [HarmonyPostfix]
        [HarmonyPatch(typeof(CraftingCampaignBehavior), nameof(CraftingCampaignBehavior.GetHeroCraftingStamina))]
        public static void GetHeroCraftingStamina(ref int __result, ref CraftingCampaignBehavior __instance, Hero hero)
        {
            __result = __instance.GetMaxHeroCraftingStamina(hero);
        }
        [HarmonyPostfix]
        [HarmonyPatch(typeof(CraftingCampaignBehavior), nameof(CraftingCampaignBehavior.GetMaxHeroCraftingStamina))]
        public static void GetMaxHeroCraftingStamina(ref int __result, ref CraftingCampaignBehavior __instance, Hero hero)
        {
            __result = 1000;
        }
    }
}
