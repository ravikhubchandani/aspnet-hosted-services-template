using System;

namespace BackgroundServices.Core
{
    public static class FriendlyTimeGenerator
    {
        public static string GetCurrentTime() => $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
    }
}
