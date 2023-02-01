using MEC;
using PluginAPI.Core;
using System.Collections.Generic;
using UnityEngine;

namespace CuffUtilsNwAPI
{
    public class DistanceComponent : MonoBehaviour
    {
        public Player Target { get; set; }
        public CoroutineHandle checkDistanceCoroutine;

        public float maxDistance = CuffUtils.Singleton.Config.CuffRemoveDistance;


        public void Start()
        {
            Target = Player.Get(gameObject);
            checkDistanceCoroutine = Timing.RunCoroutine(CheckDistance());
            Log.Debug($"Added comp to {Target.Nickname}");
        }

        public void Update()
        {
            if (Target == null || Target.DisarmedBy == null)
            {
                Log.Debug("Target or Disarmeder is null, Killing");
                Destroy();
            }

            if (!Target.IsDisarmed)
            {
                Log.Debug("Target is not null, Killing");
                Destroy();
            }
        }

        public IEnumerator<float> CheckDistance()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(0.1f);

                if (!Target.IsDisarmed)
                {
                    Log.Debug("Target is not detained, Killing");
                    Destroy();
                }

                var distance = Vector3.Distance(Target.DisarmedBy.Position, Target.Position);

                if (distance >= maxDistance)
                {
                    Target.IsDisarmed = false;
                    Log.Debug("FAR, killing");
                    Destroy();
                }
            }
        }

        public void Destroy()
        {
            Timing.KillCoroutines(checkDistanceCoroutine);
            Destroy(this);
        }
    }
}
