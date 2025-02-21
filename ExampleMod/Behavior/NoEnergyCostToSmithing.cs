using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace ExampleMod.Behavior
{
    public class NoEnergyCostToSmithing : DefaultSmithingModel
    {
        public override int GetEnergyCostForRefining(ref Crafting.RefiningFormula refineFormula, Hero hero)
        {
            ExplainedNumber explainedNumber = new ExplainedNumber(6f);

            if (hero.GetPerkValue(DefaultPerks.Crafting.PracticalRefiner))
            {
                explainedNumber.AddFactor(DefaultPerks.Crafting.PracticalRefiner.PrimaryBonus);
            }

            return (int)explainedNumber.ResultNumber;
        }

        public override int GetEnergyCostForSmithing(ItemObject item, Hero hero)
        {
            ExplainedNumber explainedNumber = new ExplainedNumber(10 + 5 * (int)item.Tier);
            if (hero.GetPerkValue(DefaultPerks.Crafting.PracticalSmith))
            {
                explainedNumber.AddFactor(DefaultPerks.Crafting.PracticalSmith.PrimaryBonus);
            }

            return (int)explainedNumber.ResultNumber;
        }

        public override int GetEnergyCostForSmelting(ItemObject item, Hero hero)
        {
            ExplainedNumber explainedNumber = new ExplainedNumber(10f);
            if (hero.GetPerkValue(DefaultPerks.Crafting.PracticalSmelter))
            {
                explainedNumber.AddFactor(DefaultPerks.Crafting.PracticalSmelter.PrimaryBonus);
            }

            return (int)explainedNumber.ResultNumber;
        }

    }
}
