using HarmonyLib;
using TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting;

namespace ExampleMod.Getters
{
    [HarmonyPatch(typeof(CraftingVM), "UpdateCurrentMaterialsAvailable")]
    public static class CraftingMaterialsCraftingVmGetter
    {
        public static CraftingVM CraftingVM;
        static void Prefix(CraftingVM __instance) => CraftingVM = __instance;
    }
}
