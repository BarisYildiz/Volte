﻿using System;

namespace Volte.Core.Files.Objects {
    public class DiscordUser : Object {
        public string Tag { get; internal set; }
        public ulong Id { get; internal set; }
        public ulong Xp { get; internal set; }
        public uint Level => (uint)Math.Sqrt(Xp / 50);
        public int Money { get; set; }
    }
}