using FQAutoSell.Models;
using Rocket.API;
using System.Collections.Generic;

namespace FQAutoSell
{
    public class Config : IRocketPluginConfiguration
    {
        public List<FQAutoSell.Models.SellItem> items;
        public void LoadDefaults()
        {
            items = new List<SellItem> { new SellItem { itemId = 41, price = 100 } };
        }
    }
}
