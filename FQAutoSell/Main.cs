using Rocket.Core.Plugins;

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
