﻿using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Qmmands;
using Volte.Commands.Checks;
using Volte.Commands.Results;

namespace Volte.Commands.Modules
{
    public sealed partial class BotOwnerModule : VolteModule
    {
        [Command("DevInfo", "Di")]
        [Description("Shows information about the bot and about the system it's hosted on.")]
        [Remarks("Usage: |prefix|devinfo")]
        [RequireBotOwner]
        public Task<ActionResult> DevInfoAsync() 
            => Ok(Format.Code(new StringBuilder()
                    .AppendLine("== Core ==")
                    .AppendLine($"{Context.Client.Guilds.Count} guilds")
                    .AppendLine($"{Context.Client.Guilds.Sum(x => x.Channels.Count)} channels")
                    .AppendLine("== Commands ==")
                    .AppendLine($"{CommandService.GetAllModules().Count} modules")
                    .AppendLine($"{CommandService.GetAllCommands().Count} commands")
                    .AppendLine("== Environment ==")
                    .AppendLine($"OS: {Environment.OSVersion}")
                    .AppendLine($"Processor Count: {Environment.ProcessorCount}")
                    .AppendLine($"Is 64-bit OS: {Environment.Is64BitOperatingSystem}")
                    .AppendLine($"Is 64-bit Process: {Environment.Is64BitProcess}")
                    .AppendLine($"Current Thread ID: {Environment.CurrentManagedThreadId}")
                    .AppendLine($"System Name: {Environment.MachineName}")
                    .AppendLine($".NET Core Version: {Environment.Version}")
                    .AppendLine($"Culture: {CultureInfo.InstalledUICulture.EnglishName}")
                    .AppendLine($"System Directory: {Environment.SystemDirectory}")
                    .ToString(), "json"));

    }
}
