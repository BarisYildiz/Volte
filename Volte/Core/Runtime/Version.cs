﻿using Discord;
using Discord.Commands;

namespace Volte.Core.Runtime
{
    public static class Version
    {
        private static readonly int Major = 2;
        private static readonly int Minor = 1;
        private static readonly int Patch = 0;
        private static readonly int Hotfix = 1;
        private static readonly ReleaseType ReleaseType = ReleaseType.Release;

        public static string GetFullVersion()
        {
            return $"{Major}.{Minor}.{Patch}.{Hotfix}-{ReleaseType}";
        }

        public static int GetMajorVersion()
        {
            return Major;
        }

        public static int GetMinorVersion()
        {
            return Minor;
        }

        public static int GetPatchVersion()
        {
            return Patch;
        }

        public static int GetHotfixVersion()
        {
            return Hotfix;
        }

        public static ReleaseType GetReleaseType()
        {
            return ReleaseType;
        }
    }

    public enum ReleaseType
    {
        Development,
        Alpha,
        Beta,
        Prerelease,
        Release
    }
}