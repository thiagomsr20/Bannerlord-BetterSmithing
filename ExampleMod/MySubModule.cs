using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace ExampleMod
{
    class MySubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            Module.CurrentModule.AddInitialStateOption(new InitialStateOption("Message",
             new TextObject("Message", null),
             9990,
             () => { InformationManager.DisplayMessage(new InformationMessage("Hello World!")); },
             () => { return (false, null); }));
        }
    }
}
