using PlayerStatsSystem;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace CuffUtilsNwAPI
{
    public class EventHandler
    {
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
            if (attacker == null || player == null)
                return false;

            if (player.IsDisarmed && CuffUtils.Singleton.Config.BlacklistDetainDamageRole.Contains(attacker.Role))
            {
                Log.Debug($"Attacker role is blacklisted {attacker.Role}");
                return false;
            }

            if (CuffUtils.Singleton.Config.DetainPlayerTakeDmg == false && player.IsDisarmed)
                player.DamageManager.CanReceiveDamageFromPlayers = false;

            return true;
        }
    }
}