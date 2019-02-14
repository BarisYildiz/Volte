using Discord;
using Discord.Commands;

namespace Volte.Core.Data.Objects
{
    public class JoinLeaveLog
    {
        public JoinLeaveLog()
        {
            Enabled = false;
            GuildId = ulong.MinValue;
            ChannelId = ulong.MinValue;
        }

        public bool Enabled { get; set; }
        public ulong GuildId { get; set; }
        public ulong ChannelId { get; set; }
    }
}