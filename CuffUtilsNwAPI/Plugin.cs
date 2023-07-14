using CuffUtilsNwAPI;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;
using System;

namespace CuffUtilsNwAPI
{
    public class CuffUtils
    {
        public const string PluginName = "CuffUtils";
        public const string PluginVersion = "1.2.1"; //Maj/Min/Build
        public const string PluginDesc = "Multi-purpose plugin that creates many features around cuffing events to help moderation/gameplay changes";

        public static CuffUtils Singleton;
        public EventHandler EventHandler;

        [PluginConfig] public Config Config;

        [PluginEntryPoint(PluginName, PluginVersion, PluginDesc, "DentyTxR#0524")]
        public void LoadPlugin()
        {
            Log.Debug("CuffUtils by Denty has been loaded.");
            Singleton = this;
            PluginAPI.Events.EventManager.RegisterEvents<EventHandler>(this);
        }


        [PluginUnload()]
        public void UnloadPlugin()
        {
            Log.Debug("unload");
            Config = null;
            EventHandler = null;
        }
    }
}