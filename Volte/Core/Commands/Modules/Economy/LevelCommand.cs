﻿using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Qmmands;
using Volte.Core.Extensions;

namespace Volte.Core.Commands.Modules.Economy
{
    public partial class EconomyModule : VolteModule
    {
        [Command("Level")]
        [Description("Shows the level for the given user, or for yourself if no user is given.")]
        [Remarks("Usage: |prefix|level [@user]")]
        public async Task Level(SocketGuildUser user = null)
        {
            if (user is null) user = Context.User;
            await Context.CreateEmbed($"User {user.Mention} is level **{Db.GetUser(Context.User).Level}**.")
                .SendTo(Context.Channel);
        }
    }
}