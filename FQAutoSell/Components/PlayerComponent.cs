using fr34kyn01535.Uconomy;
using Rocket.API;
using Rocket.Core;
using Rocket.Unturned.Player;
using RocketExtensions.Utilities.ShimmyMySherbet.Extensions;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FQAutoSell.Components
{
    public class PlayerComponent : UnturnedPlayerComponent
    {
        public bool autoenable = false;
        protected override void Load()
        {
            Player.Inventory.onInventoryAdded += (byte page, byte index, ItemJar jar) => InventoryAdded(Player, page, index, jar);
        }
        protected override void Unload()
        {
            Player.Inventory.onInventoryAdded += (byte page, byte index, ItemJar jar) => InventoryAdded(Player, page, index, jar);
        }
        private async void InventoryAdded(UnturnedPlayer player, byte page, byte index, ItemJar jar)
        {
            
            await ThreadTool.RunOnGameThreadAsync(() => {
   
                if (!Main.Instance.Configuration.Instance.items.Exists(x => x.itemId == jar.item.id)) return;

                if (!autoenable) return;

                player.Inventory.removeItem(page, index);

                Uconomy.Instance.Database.IncreaseBalance(player.CSteamID.m_SteamID.ToString(), Main.Instance.Configuration.Instance.items.FirstOrDefault(x => x.itemId == jar.item.id).price);
            });

        }
    }
}
