using fr34kyn01535.Uconomy;
using Rocket.Unturned.Player;
using RocketExtensions.Utilities.ShimmyMySherbet.Extensions;
using SDG.Unturned;
using System.Linq;
using Rocket.Core.Logging;

namespace FQAutoSell.Components
{
    public class PlayerComponent : UnturnedPlayerComponent
    {
        public bool autoenable = false;
        protected override void Load()
        {
            Player.Inventory.onInventoryAdded += (page, index, jar) => InventoryAdded(Player, page, index, jar);

        }
        protected override void Unload()
        {
            Player.Inventory.onInventoryAdded += (page, index, jar) => InventoryAdded(Player, page, index, jar);

        }
        private async void InventoryAdded(UnturnedPlayer player, byte page, byte index, ItemJar jar)
        {
            
            await ThreadTool.RunOnGameThreadAsync(() => {
   
                if (!Main.Instance.Configuration.Instance.items.Exists(x => x.itemId == jar.item.id)) return;

                if (!autoenable) return;

                player.Inventory.removeItem(page, index);

                if (Uconomy.Instance != null && Uconomy.Instance.Database != null)
                {
                    var item = Main.Instance.Configuration.Instance.items.FirstOrDefault(x => x.itemId == jar.item.id);

                    if (item != null)
                    {
                        Uconomy.Instance.Database.IncreaseBalance(player.CSteamID.m_SteamID.ToString(), item.price);
                    }
                    else
                    {
                        Logger.Log("Belirtilen itemId ile eşleşen öğe bulunamadı.");
                    }
                }
                else
                {
                    Logger.Log("Uconomy.Instance veya Uconomy.Instance.Database verisi alınamadı.");
                }

            });

        }
    }
}
