using ExampleMod.Behavior;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

// TODO: Alterar no XML e o nome da solução e projeto para o nome BetterSmithing quando subir o mod para produção
namespace ExampleMod
{
    class MySubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
        }
        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);

            if (!(game.GameType is Campaign))
                return;

            InformationManager.DisplayMessage(new InformationMessage("NoEnergyCostToSmithing carregado!"));
            AddBehaviors(gameStarterObject as CampaignGameStarter);
        }

        private void AddBehaviors(CampaignGameStarter gameStarterObject)
        {
            if (gameStarterObject != null)
            {
                // Remove qualquer modelo existente de smithing antes de adicionar o nosso
                gameStarterObject.RemoveModel<DefaultSmithingModel>();
                gameStarterObject.AddModel(new NoEnergyCostToSmithing());
                InformationManager.DisplayMessage(new InformationMessage("Modelo de Smithing modificado!"));
            }
        }
    }
}
