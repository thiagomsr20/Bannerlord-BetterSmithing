using ExampleMod.Service;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting;
using TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.Refinement;

namespace ExampleMod.Behavior
{
    [HarmonyPatch(typeof(RefinementVM), "ExecuteSelectedRefinement", new Type[] { typeof(Hero) })]
    public class ManyMaterialsAtOnce
    {
        private static bool BehaviorActive = true;
        private static bool Prefix(RefinementVM __instance, Hero currentCraftingHero)
        {
            if (__instance.CurrentSelectedAction != null)
            {
                if (!BehaviorActive)
                    return true;

                var refineFormula = __instance.CurrentSelectedAction.RefineFormula;

                // TODO: Implementar lógica para verificar quantas vezes o Hero pode craftar o item segurando CTRL
                // 1. Já tenho os inputs das receitas de refinamento de cada seleção do Hero
                // 2. TODO: Preciso dos inputs de tecla SHIFT (para fazer 5) e CTRL (para fazer todos) // Olhar: public InputKeyItemVM ConfirmInputKey { get; set; }
                // 3. TODO: Preciso do input dos itens do iventário do Hero
                // para saber quantos ele ainda pode fazer daquele item
                // Com base nos materiais disponíveis no iventário para refinamento do item selecionado

                int refinmentRepeats = 0;

                // CraftingMaterials 

                // Pegar materiais do player
                //[DataSourceProperty
                //

                CraftingVM craftingView = Campaign.Current.GetCampaignBehavior<CraftingVM>();
                var teste = craftingView.PlayerCurrentMaterials;

                // Shift + Click => 5 refinamentos (Se tiver os itens)
                if (refinmentRepeats == 0)
                    refinmentRepeats = RefinementCalculate.RefiningCount();

                // Ctrl + Click => Máximo de refinamentos (Com base no que tiver de receita no iventário)
                else if (true)
                    refinmentRepeats = RefinementCalculate.RefiningCount();

                // Prevent stackoverflow issue
                BehaviorActive = false;

                while (refinmentRepeats != 0)
                {
                    __instance.ExecuteSelectedRefinement(currentCraftingHero);
                    refinmentRepeats--;
                }

                // Finished multi crafting re-enable the behavior for next run
                BehaviorActive = true;
            }
            return false;
        }
    }
}