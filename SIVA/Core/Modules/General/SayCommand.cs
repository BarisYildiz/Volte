﻿using System.Threading.Tasks;
using Discord.Commands;
using SIVA.Helpers;

namespace SIVA.Core.Modules.General {
    public class SayCommand : SIVACommand {
        [Command("Say")]
        public async Task Say([Remainder] string msg) {
            await Context.Channel.SendMessageAsync("", false, CreateEmbed(Context, msg));
        }
    }
}