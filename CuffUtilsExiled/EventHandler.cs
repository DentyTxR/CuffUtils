using CuffUtilsExiled.Features.Components;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace CuffUtilsExiled
{
    public class EventHandler
    {
        public void HandcuffingEvent(HandcuffingEventArgs ev)
        {
            if (CuffUtilsExiled.Singleton.Config.EnableCuffRemoveOnDistance)
            {
                DistanceComponent distanceComponent = ev.Target.GameObject.AddComponent<DistanceComponent>();
                distanceComponent.Target = ev.Target;
            }
        }

        public void HurtingEvent(HurtingEventArgs ev)
        {
            if (ev.Player.IsCuffed)
            {
                if (CuffUtilsExiled.Singleton.Config.WhitelistCuffDamageRole.Contains(ev.Player.Role))
                {
                    Log.Debug($"Attacker role is whitelisted {ev.Player.Role}");
                }
                else if (CuffUtilsExiled.Singleton.Config.BlacklistDetainDamageRole.Contains(ev.Player.Role))
                {
                    Log.Debug($"Attacker role is blacklisted {ev.Player.Role}");
                }

                if (ev.Attacker.Role.Side == Exiled.API.Enums.Side.Scp && !CuffUtilsExiled.Singleton.Config.DetainPlayerTakeScpDmg)
                    ev.Amount = 0;

                if (!CuffUtilsExiled.Singleton.Config.DetainPlayerTakeDmg)
                    ev.Amount = 0;
            }
        }
    }
}