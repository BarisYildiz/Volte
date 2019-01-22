﻿using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using SIVA.Core.Files.Readers;
using SIVA.Helpers;

namespace SIVA.Core.Modules.Owner {
    public class SetStatusCommand : SIVACommand {
        [Command("SetStatus")]
        public async Task SetStatus([Remainder] string status) {
            if (!UserUtils.IsBotOwner(Context.User)) {
                await React(Context.SMessage, RawEmoji.X);
                return;
            }

            var embed = new EmbedBuilder();
            var config = ServerConfig.Get(Context.Guild);
            embed.WithAuthor(Context.User);
            embed.WithColor(config.EmbedColourR, config.EmbedColourG, config.EmbedColourB);
            switch (status.ToLower()) {
                case "dnd":
                    await Discord.SIVA.Client.SetStatusAsync(UserStatus.DoNotDisturb);
                    embed.WithDescription("Set the status to Do Not Disturb.");
                    break;
                case "idle":
                    await Discord.SIVA.Client.SetStatusAsync(UserStatus.Idle);
                    embed.WithDescription("Set the status to Idle.");
                    break;
                case "invisible":
                    await Discord.SIVA.Client.SetStatusAsync(UserStatus.Invisible);
                    embed.WithDescription("Set the status to Invisible.");
                    break;
                case "online":
                    await Discord.SIVA.Client.SetStatusAsync(UserStatus.Online);
                    embed.WithDescription("Set the status to Online.");
                    break;
                default:
                    await Discord.SIVA.Client.SetStatusAsync(UserStatus.Online);
                    embed.WithDescription(
                        "Your option wasn't known, so I set the status to Online.\nAvailable options for this command are `dnd`, `idle`, `invisible`, or `online`.");
                    break;
            }

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
    }
}