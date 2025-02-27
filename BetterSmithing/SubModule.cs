using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;
using BetterSmithing.Behavior;
using TaleWorlds.Core;
using HarmonyLib;
using TaleWorlds.Library;

namespace BetterSmithing
{
    internal class SubModule : MBSubModuleBase
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
