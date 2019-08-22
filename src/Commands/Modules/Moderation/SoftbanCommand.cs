using System.Net;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Qmmands;
using Volte.Commands.Checks;
using Volte.Core.Models;
using Volte.Core.Models.EventArgs;
using Volte.Commands.Results;
using Gommon;

namespace Volte.Commands.Modules
{
    public sealed partial class ModerationModule : VolteModule
    {
        [Command("Softban")]
        [Description("Softbans the mentioned user, kicking them and deleting the last 7 days of messages.")]
        [Remarks("Usage: |prefix|softban {@user} {daysToDelete} [reason]")]
        [RequireBotGuildPermission(GuildPermission.KickMembers | GuildPermission.BanMembers)]
        [RequireGuildModerator]
        public async Task<ActionResult> SoftBanAsync([CheckHierarchy] SocketGuildUser user, int daysToDelete,
            [Remainder] string reason = "Softbanned by a Moderator.")
        {
            if (!await user.TrySendMessageAsync(
                embed: Context.CreateEmbed($"You've been softbanned from **{Context.Guild.Name}** for **{reason}**.")))
            {
                Logger.Warn(LogSource.Volte,
                    $"encountered a 403 when trying to message {user}!");
            }

            await user.BanAsync(daysToDelete, reason);
            await Context.Guild.RemoveBanAsync(user);

            return Ok($"Successfully softbanned **{user.Username}#{user.Discriminator}**.", _ =>
                ModLogService.DoAsync(ModActionEventArgs.New
                    .WithDefaultsFromContext(Context)
                    .WithTarget(user)
                    .WithReason(reason))
                );
        }
    }
}