using System;
using Exiled.API.Features;
using PlayerEvent = Exiled.Events.Handlers.Player;

namespace CuffUtilsExiled
{
    public class CuffUtilsExiled : Plugin<Config>
    {
        private EventHandler EventHandler;
        public static CuffUtilsExiled Singleton;
        public static Config Configs => Singleton.Config;

        public override string Name { get; } = "CuffUtils";
        public override string Author { get; } = "Denty";
        public override string Prefix { get; } = "CuffUtils";
        public override Version Version { get; } = new Version(1, 3, 0);
        public override Version RequiredExiledVersion { get; } = new Version(8, 4, 1);


        public override void OnEnabled()
        {
            Singleton = this;
            EventHandler = new EventHandler();

            PlayerEvent.Handcuffing += EventHandler.HandcuffingEvent;
            PlayerEvent.Hurting += EventHandler.HurtingEvent;

            base.OnEnabled();
        }


        public override void OnDisabled()
        {
            PlayerEvent.Handcuffing -= EventHandler.HandcuffingEvent;
            PlayerEvent.Hurting -= EventHandler.HurtingEvent;

            EventHandler = null;

            base.OnDisabled();
        }
    }
}