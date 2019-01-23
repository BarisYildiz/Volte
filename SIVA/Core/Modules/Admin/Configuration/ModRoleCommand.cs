﻿using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using SIVA.Core.Files.Readers;
using SIVA.Helpers;

namespace SIVA.Core.Modules.Admin.Configuration {
    public class ModRoleCommand : SIVACommand {
        [Command("ModRole")]
        public async Task ModRole([Remainder] string roleName) {
            var config = ServerConfig.Get(Context.Guild);
            var embed = CreateEmbed(Context, "").ToEmbedBuilder();
            if (!UserUtils.IsAdmin(Context)) {
                await React(Context.SMessage, RawEmoji.X);
                return;
            }

            if (Context.Guild.Roles.Any(r => r.Name.ToLower() == roleName.ToLower())) {
                var role = Context.Guild.Roles.First(r => r.Name.ToLower() == roleName.ToLower());
                config.ModRole = role.Id;
                ServerConfig.Save();
                embed.WithDescription($"Set **{role.Name}** as the Moderator role for this server.");
            }
            else {
                embed.WithDescription($"{roleName} doesn't exist in this server.");
            }

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
    }
}