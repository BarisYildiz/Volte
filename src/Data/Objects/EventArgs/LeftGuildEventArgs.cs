using Discord;
using Discord.WebSocket;
using Volte.Discord;
using Volte.Services;

namespace Volte.Data.Objects.EventArgs
{
    public sealed class LeftGuildEventArgs
    {
        private DatabaseService _db = VolteBot.GetRequiredService<DatabaseService>();
        public IGuild Guild { get; }
        public GuildConfiguration Config { get; }
        public DiscordSocketClient Client { get; }

        public LeftGuildEventArgs(SocketGuild guild)
        {
            Guild = guild;
            Config = _db.GetConfig(guild);
            Client = VolteBot.Client;
        }
    }
}