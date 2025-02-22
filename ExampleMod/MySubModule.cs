using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;
using ExampleMod.Behavior;
using TaleWorlds.Core;
using HarmonyLib;

namespace ExampleMod
{
    class MySubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            Harmony harmony = new Harmony("bannerlord.better.smithing.thiagomsr20");
            harmony.PatchAll();
        }
        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);
            if (game.GameType is Campaign)
            {
                AddBehaviors(gameStarterObject as CampaignGameStarter);
            }
        }
        private void AddBehaviors(CampaignGameStarter gameStarterObject)
        {
            if (gameStarterObject != null)
            {
                gameStarterObject.AddModel(new NoEnergyCostToSmithing());
            }
        }
    }
}
