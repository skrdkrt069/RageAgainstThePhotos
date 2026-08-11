using System;
using System.Collections.Generic;
using System.Text;

namespace Rage_Against_The_Photos
{
    public class AppSettings
    {
        public bool DarkTheme { get; set; } = true;

        public Dictionary<string, string> DefaultConversions { get; set; } = new();
    }
}