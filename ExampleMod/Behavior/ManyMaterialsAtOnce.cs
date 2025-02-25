using ExampleMod.Service;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting;
using TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.Refinement;
using TaleWorlds.Library;

namespace ExampleMod.Behavior
{
    [HarmonyPatch(typeof(RefinementVM), "ExecuteSelectedRefinement", new Type[] { typeof(Hero) })]
    public class ManyMaterialsAtOnce
    {
        private static bool Prefix(RefinementVM __instance, Hero currentCraftingHero)
        {
            if (__instance.CurrentSelectedAction != null)
            {
                var refineFormula = __instance.CurrentSelectedAction.RefineFormula;


                var craftingView = CraftingMaterialsCraftingVmGetter.CraftingVM;
                foreach (var material in craftingView.PlayerCurrentMaterials)
                {
                    // TODO: Get the input materials count and avaiable materials count
                }

                int refinmentRepeats = 0;

                // If Shift + Click => 5 refinamentos (Se tiver os itens)
                if (refinmentRepeats == 0)
                    refinmentRepeats = RefinementCalculate.ActionRefiningCount(0, 0);

                // If Ctrl + Click => Máximo de refinamentos (Com base no que tiver de receita no iventário)
                else if (refinmentRepeats > 0)
                    refinmentRepeats = RefinementCalculate.ActionRefiningCount(0, 0);

                while (refinmentRepeats != 0)
                {
                    __instance.ExecuteSelectedRefinement(currentCraftingHero);
                    refinmentRepeats--;
                }
            }
            return false; // Return FALSE to dont run the original method
        }
    }
    [HarmonyPatch(typeof(CraftingVM), "UpdateCurrentMaterialsAvailable")]
    public static class CraftingMaterialsCraftingVmGetter
    {
        public static CraftingVM CraftingVM;
        static void GetCraftingVM(CraftingVM __instance) => CraftingVM = __instance;
    }
}