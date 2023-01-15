using PlayerRoles.FirstPersonControl.NetworkMessages;
using PlayerStatsSystem;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace CuffUtilsNwAPI
{
    public class EventHandler
    {
        private readonly Config _config = CuffUtils.Singleton.Config;

        [PluginEvent(ServerEventType.PlayerHandcuff)]
        public void PlayerCuffingEvent(Player player, Player target)
        {
        }

        [PluginEvent(ServerEventType.PlayerRemoveHandcuffs)]
        public void PlayerUncuffingEvent(Player player, Player target)
        {

        }

        [PluginEvent(ServerEventType.PlayerDamage)]
        public bool PlayerDamagingEvent(Player player, Player attacker, DamageHandlerBase damageHandler)
        {
            if (player == null)
                return false;

            if (attacker == null)
                return true;

            if (player.IsDisarmed)
            {
                if (_config.WhitelistCuffDamageRole.Contains(attacker.Role))
                {
                    Log.Debug($"Attacker role is whitelisted {attacker.Role}");
                    return true;
                } else if (_config.BlacklistDetainDamageRole.Contains(attacker.Role))
                {
                    Log.Debug($"Attacker role is blacklisted {attacker.Role}");
                    return false;
                }

                if (_config.DetainPlayerTakeDmg == false)
                    player.DamageManager.CanReceiveDamageFromPlayers = false;
            }
            return true;
        }
    }
}