using Cysharp.Threading.Tasks;
using FQAutoSell.Components;
using RocketExtensions.Models;
using RocketExtensions.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                await context.ReplyAsync("Otomatik satış kapatıldı!", Color.red, true);
            }
            else
            {
                context.UnturnedPlayer.GetComponent<PlayerComponent>().autoenable = true;
                await context.ReplyAsync("Otomatik satış açıldı!", Color.green, true);
            }
        }
    }
}
