using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FQAutoSell
{
    public class Main : RocketPlugin<Config>
    {
        public static Main Instance;
        protected override void Load()
        {
            Instance = this;
        }

        protected override void Unload()
        {

        }



    }
}
