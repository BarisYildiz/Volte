﻿using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Qmmands;
using SixLabors.ImageSharp.PixelFormats;
using Volte.Commands.Results;
using Volte.Helpers;

namespace Volte.Commands.Modules
{
    public sealed partial class UtilityModule : VolteModule
    {
        [Command("Color", "Colour")]
        [Description("Shows the Hex and RGB representation for a given role in the current server.")]
        [Remarks("Usage: |prefix|color {role}")]
        public async Task<ActionResult> RoleColorAsync([Remainder] SocketRole role)
        {
            if (role.Color.RawValue is 0) return BadRequest("Role does not have a color.");

            using (var outStream = ImageHelper.CreateColorImage(new Rgba32(role.Color.R, role.Color.G, role.Color.B)))
            {
                await Context.Channel.SendFileAsync(outStream, "role.png", null, embed: Context.CreateEmbedBuilder()
                    .WithColor(role.Color)
                    .WithTitle($"Color of Role {role.Name}")
                    .WithDescription(new StringBuilder()
                        .AppendLine($"**Hex:** {role.Color.ToString().ToUpper()}")
                        .AppendLine($"**RGB:** {role.Color.R}, {role.Color.G}, {role.Color.B}")
                        .ToString())
                    .WithImageUrl("attachment://role.png")
                    .Build());
            }
            return None();

        }
    }
}