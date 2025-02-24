using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;
using ExampleMod.Behavior;
using TaleWorlds.Core;
using HarmonyLib;
using TaleWorlds.Library;

namespace ExampleMod
{
    internal class MySubModule : MBSubModuleBase
    {
        public string ModName { get; private set; } = "BetterSmithing";
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            Harmony harmony = new Harmony($"bannerlord.{ModName}.thiagomsr20");
            harmony.PatchAll();
        }
        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);

            if (game.GameType is Campaign)
                AddBehaviors(gameStarterObject as CampaignGameStarter);
        }
        private void AddBehaviors(CampaignGameStarter gameStarterObject)
        {
            if (gameStarterObject != null)
            {
                gameStarterObject.AddModel(new NoEnergyCostToSmithing());
                InformationManager.DisplayMessage(new InformationMessage("BetterSmithing is loaded!"));
            }
                
        }
    }
}
