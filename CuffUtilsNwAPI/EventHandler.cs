using PlayerStatsSystem;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace CuffUtilsNwAPI
{
    public class EventHandler
    {
        private readonly Config _config = CuffUtils.Singleton.Config;

        [PluginEvent]
        public void PlayerCuffingEvent(PlayerHandcuffEvent ev)
        {
            if (_config.EnableCuffRemoveOnDistance)
            {
                DistanceComponent distanceComponent = ev.Target.GameObject.AddComponent<DistanceComponent>();
                distanceComponent.Target = ev.Target;
            }
        }

        [PluginEvent]
        public void PlayerUncuffingEvent(PlayerRemoveHandcuffsEvent ev)
        {
        }

        [PluginEvent]
        public bool PlayerDamagingEvent(PlayerDamageEvent ev)
        {

            if (ev.Target.IsDisarmed)
            {
                if (_config.WhitelistCuffDamageRole.Contains(ev.Player.Role))
                {
                    Log.Debug($"Attacker role is whitelisted {ev.Player.Role}");
                    return true;
                } else if (_config.BlacklistDetainDamageRole.Contains(ev.Player.Role))
                {
                    Log.Debug($"Attacker role is blacklisted {ev.Player.Role}");
                    return false;
                }

                if (_config.DetainPlayerTakeDmg == false)
                    ev.Target.DamageManager.CanReceiveDamageFromPlayers = false;
            }
            return true;
        }
    }
}