﻿using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using SIVA.Helpers;

namespace SIVA.Core.Modules.Owner {
    public class ShutdownCommand : SIVACommand {
        // I'm not sure how well this works.

        [Command("Shutdown")]
        public async Task Shutdown() {
            if (!UserUtils.IsBotOwner(Context.User)) {
                await React(Context.SMessage, RawEmoji.X);
                return;
            }

            await Reply(Context.Channel, CreateEmbed(Context, $"Goodbye! {RawEmoji.WAVE}"));
            await Discord.SIVA.Client.LogoutAsync();
            await Discord.SIVA.Client.StopAsync();
            Environment.Exit(0);
        }
    }
}