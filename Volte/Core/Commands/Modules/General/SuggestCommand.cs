﻿using System.Threading.Tasks;
using Discord;
using Qmmands;
using Volte.Core.Extensions;

namespace Volte.Core.Commands.Modules.General
{
    public partial class GeneralModule : VolteModule
    {
        [Command("Suggest")]
        [Description("Suggest features for Volte.")]
        [Remarks("Usage: |prefix|suggest")]
        public async Task Suggest()
        {
            await Context.CreateEmbed("You can suggest bot features [here](https://goo.gl/forms/i6pgYTSnDdMMNLZU2).")
                .SendTo(Context.Channel);
        }
    }
}