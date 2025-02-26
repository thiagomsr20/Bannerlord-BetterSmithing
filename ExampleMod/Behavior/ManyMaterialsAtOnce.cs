using ExampleMod.Getters;
using ExampleMod.Service;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.Refinement;
using TaleWorlds.InputSystem;

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
                var teste = craftingView.PlayerCurrentMaterials;
                
                // Get the input keys
                bool ctrl_IsPressed = Input.IsKeyDown(InputKey.LeftControl) || Input.IsKeyDown(InputKey.RightControl);
                bool shift_IsPressed = Input.IsKeyDown(InputKey.LeftShift) || Input.IsKeyDown(InputKey.RightShift);

                int refinmentRepeats = 10;
                
                if (shift_IsPressed) // TODO: Validar se o Hero tem materiais o suficiente para executar essa tarefa
                    refinmentRepeats = 5;

                else if (ctrl_IsPressed)
                    refinmentRepeats = RefinementCalculate.ActionRefiningCount(0, 0);

                while (refinmentRepeats != 0)
                {
                   // __instance.DoRefinement(currentCraftingHero);
                    refinmentRepeats--;
                }
            }
            return false;
        }
    }
}