using Exiled.API.Features;
using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace CuffUtilsExiled.Features.Components
{
    public class DistanceComponent : MonoBehaviour
    {
        public Player Target { get; set; }
        public CoroutineHandle checkDistanceCoroutine;

        public float maxDistance = CuffUtilsExiled.Singleton.Config.CuffRemoveDistance;

        public void Start()
        {
            Target = Player.Get(gameObject);
            checkDistanceCoroutine = Timing.RunCoroutine(CheckDistance());
            Log.Debug($"Added comp to {Target.Nickname}");
        }

        public void Update()
        {
            if (Target == null || Target.Cuffer == null)
            {
                Log.Debug("Target or Disarmeder is null, Killing");
                Destroy();
            }

            if (!Target.IsCuffed)
            {
                Log.Debug("Target is not cuffed, Killing");
                Destroy();
            }
        }

        public IEnumerator<float> CheckDistance()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(0.1f);

                if (!Target.IsCuffed)
                {
                    Log.Debug("Target is not detained, Killing");
                    Destroy();
                }

                var distance = Vector3.Distance(Target.Cuffer.Position, Target.Position);

                if (distance >= maxDistance)
                {
                    Target.RemoveHandcuffs();

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
