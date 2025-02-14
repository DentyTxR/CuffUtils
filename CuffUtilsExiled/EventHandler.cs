using CuffUtilsExiled.Features.Components;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace CuffUtilsExiled
{
    public class EventHandler
    {
        public void HandcuffingEvent(HandcuffingEventArgs ev)
        {
            if (CuffUtilsExiled.Configs.EnableCuffRemoveOnDistance)
            {
                DistanceComponent distanceComponent = ev.Target.GameObject.AddComponent<DistanceComponent>();
                distanceComponent.Target = ev.Target;
            }
        }

        public void RemovingHandcuffsEvent(RemovingHandcuffsEventArgs ev)
        {
            if (CuffUtilsExiled.Configs.OnlyDetainerCanUncuff && ev.Player != ev.Target.Cuffer)
            {
                ev.IsAllowed = false;
                return;
            }
        }

        public void HurtingEvent(HurtingEventArgs ev)
        {
            if (ev.Player.IsCuffed && ev.Attacker != null)
            {
                if (CuffUtilsExiled.Configs.CanCufferDamageCuffed && ev.Attacker == ev.Player.Cuffer) 
                {
                    Log.Debug($"Attacker is cuffer, allowing damage");
                    ev.IsAllowed = true;
                    return;
                }

                var attackerRole = ev.Attacker.Role;
                if (CuffUtilsExiled.Configs.WhitelistCuffDamageRole.Contains(attackerRole))
                {
                    Log.Debug($"Attacker role is whitelisted {attackerRole}");
                    ev.IsAllowed = true;
                }
                else if (CuffUtilsExiled.Configs.BlacklistDetainDamageRole.Contains(attackerRole))
                {
                    Log.Debug($"Attacker role is blacklisted {attackerRole}");
                    ev.IsAllowed = false;
                }

                if (ev.Attacker.Role.Side == Exiled.API.Enums.Side.Scp && !CuffUtilsExiled.Configs.DetainPlayerTakeScpDmg || CuffUtilsExiled.Configs.DetainPlayerTakeDmg)
                    ev.Amount = 0;
            }
        }
    }
}