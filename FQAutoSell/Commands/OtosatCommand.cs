using Cysharp.Threading.Tasks;
using FQAutoSell.Components;
using RocketExtensions.Models;
using RocketExtensions.Plugins;
using UnityEngine;

namespace FQAutoSell.Commands
{
    public class OtosatCommand : RocketCommand
    {
        public override async UniTask Execute(CommandContext context)
        {
            if (context.UnturnedPlayer.GetComponent<PlayerComponent>().autoenable)
            {
                context.UnturnedPlayer.GetComponent<PlayerComponent>().autoenable = false;
                await context.ReplyAsync("Otomatik satış kapatıldı!", Color.red);
            }
            else
            {
                context.UnturnedPlayer.GetComponent<PlayerComponent>().autoenable = true;
                await context.ReplyAsync("Otomatik satış açıldı!", Color.green);
            }
        }
    }
}
