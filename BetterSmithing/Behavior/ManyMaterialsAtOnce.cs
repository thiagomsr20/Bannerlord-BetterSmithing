using BetterSmithing.Getters;
using BetterSmithing.Service;
using HarmonyLib;
using System;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.Refinement;
using TaleWorlds.InputSystem;

namespace BetterSmithing.Behavior
{
    [HarmonyPatch(typeof(RefinementVM), "ExecuteSelectedRefinement", new Type[] { typeof(Hero) })]
    public class ManyMaterialsAtOnce
    {
        private static bool Prefix(RefinementVM __instance, Hero currentCraftingHero)
        {
            if (__instance.CurrentSelectedAction != null)
            {
                bool ctrl_IsPressed = Input.IsKeyDown(InputKey.LeftControl) || Input.IsKeyDown(InputKey.RightControl);
                bool shift_IsPressed = Input.IsKeyDown(InputKey.LeftShift) || Input.IsKeyDown(InputKey.RightShift);

                int refinmentRepeats = 0;
                var refineFormula = __instance.CurrentSelectedAction.RefineFormula;

                if (!ctrl_IsPressed && !shift_IsPressed)
                {
                    refinmentRepeats = 1;
                }
                else
                {
                    var heroIventory = CraftingMaterialsCraftingVmGetter.CraftingVM.PlayerCurrentMaterials;

                    int input1_AvaiableInHeroInventory = heroIventory.First(mtrl => mtrl.ResourceMaterial == refineFormula.Input1).ResourceAmount;
                    int input2_AvaiableInHeroInventory = heroIventory.First(mtrl => mtrl.ResourceMaterial == refineFormula.Input2).ResourceAmount;

                    if (refineFormula.Input2Count != 0) // If refinement needs more than one input to make
                    {
                        refinmentRepeats = RefinementCalculate.ActionRefiningCount(refineFormula.Input1Count, input1_AvaiableInHeroInventory,
                                                                                       refineFormula.Input2Count, input2_AvaiableInHeroInventory,
                                                                                       shift_IsPressed);
                    }
                    else
                        refinmentRepeats = RefinementCalculate.ActionRefiningCount(refineFormula.Input1Count, input1_AvaiableInHeroInventory, shift_IsPressed);
                }

                var craftingBehavior = Campaign.Current.GetCampaignBehavior<ICraftingCampaignBehavior>();
                while (refinmentRepeats != 0)
                {
                    craftingBehavior.DoRefinement(currentCraftingHero, refineFormula);
                    refinmentRepeats--;
                }

                // Att the refinement list based on the avaiable materials.
                __instance.RefreshRefinementActionsList(currentCraftingHero);
            }
            return false;  
        }
    }
}