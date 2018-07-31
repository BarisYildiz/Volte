﻿using System.Threading.Tasks;
using Discord.Commands;
using SIVA.Helpers;

namespace SIVA.Core.Discord.Modules.Information.Utilities {
    public class PingCommand : SIVACommand {
        [Command("Ping")]
        public async Task Ping() {
            await Context.Channel.SendMessageAsync("", false,
                Utils.CreateEmbed(Context, $"{SIVA.GetInstance().Latency}ms"));
        }
    }
}