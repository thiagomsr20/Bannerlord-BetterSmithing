using BetterSmithing.Service;
using HarmonyLib;
using System;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.Smelting;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;

namespace BetterSmithing.Behavior
{
    [HarmonyPatch(typeof(SmeltingVM), "TrySmeltingSelectedItems", new Type[] { typeof(Hero) })]
    public class ManySmeltingAtOnce
    {
        private static bool Prefix(SmeltingVM __instance, Hero currentCraftingHero)
        {
            // Get the private properties actions to update values when selected other item or semelt
            var updateValuesOnSelectItemAction = (Action)AccessTools.Field(typeof(SmeltingVM), "_updateValuesOnSelectItemAction").GetValue(__instance);
            var updateValuesOnSmeltItemAction = (Action)AccessTools.Field(typeof(SmeltingVM), "_updateValuesOnSmeltItemAction").GetValue(__instance);

            bool ctrl_IsPressed = Input.IsKeyDown(InputKey.LeftControl) || Input.IsKeyDown(InputKey.RightControl);
            bool shift_IsPressed = Input.IsKeyDown(InputKey.LeftShift) || Input.IsKeyDown(InputKey.RightShift);

            int smeltingRepeats = 0;
            var item = __instance.CurrentSelectedItem;

            if (!ctrl_IsPressed && !shift_IsPressed)
                smeltingRepeats = 1;

            else
                smeltingRepeats = ManyAtOnceCalculate.ActionSmeltingCount(item.NumOfItems, shift_IsPressed);

            var craftingBehavior = Campaign.Current.GetCampaignBehavior<ICraftingCampaignBehavior>();
            while (smeltingRepeats != 0)
            {
                craftingBehavior.DoSmelting(currentCraftingHero, item.EquipmentElement);

                __instance.RefreshList();
                __instance.SortController.SortByCurrentState();
                if (__instance.CurrentSelectedItem != null)
                {
                    int num = __instance.SmeltableItemList.FindIndex((SmeltingItemVM i) => i.EquipmentElement.Item == __instance.CurrentSelectedItem.EquipmentElement.Item);
                    SmeltingItemVM newItem = ((num != -1) ? __instance.SmeltableItemList[num] : __instance.SmeltableItemList.FirstOrDefault());

                    if (newItem != __instance.CurrentSelectedItem)
                    {
                        if (__instance.CurrentSelectedItem != null)
                        {
                            __instance.CurrentSelectedItem.IsSelected = false;
                        }

                        __instance.CurrentSelectedItem = newItem;
                        __instance.CurrentSelectedItem.IsSelected = true;

                        updateValuesOnSelectItemAction?.Invoke();

                        __instance.WeaponTypeName = __instance.CurrentSelectedItem.EquipmentElement.Item.WeaponDesign?.Template.TemplateName.ToString() ?? string.Empty;
                        __instance.WeaponTypeCode = __instance.CurrentSelectedItem.EquipmentElement.Item.WeaponDesign?.Template.StringId ?? string.Empty;
                    }
                }
                updateValuesOnSmeltItemAction?.Invoke();

                smeltingRepeats--;
            }

            return false;
        }
    }
}
