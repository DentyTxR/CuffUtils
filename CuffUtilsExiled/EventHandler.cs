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

                if (CuffUtilsExiled.Singleton.Config.DetainPlayerTakeDmg == false)
                    ev.Amount = 0;
            }
        }
    }
}