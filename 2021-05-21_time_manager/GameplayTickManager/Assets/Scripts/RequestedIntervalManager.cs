// +-------------------------------------------------------------------------------------------------------------------
// + File: RequestedIntervalManager.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 14:30 on 2021/05/17
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using UnityEngine;

namespace IdleStuff
{
    // +---------------------------------------------------------------------------------------------------------------
    // + Class: RequestedIntervalProducer
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class RequestedIntervalProducer : ResourceProducer
    {
        // Private Members  -------------------------------------------------------------------------------------------
        // private int ticksPerItem = GameplayController.DefaultTicksPerItem;
        // private int tickCooldown = 0;

        // Class Methods  ---------------------------------------------------------------------------------------------
        public RequestedIntervalProducer() : base(UpdateIntervalType.Requested)
        {
            // ticksPerItem = (int)Math.Round(1 / ItemsPerTick);
            // tickCooldown = GameplayController.DefaultTicksPerItem;
        }

        public override void Update(float intervalTime)
        {
            base.Update(intervalTime);
            TotalItems += 1;

            PrintUpdateStats();
        }
    }

    // +---------------------------------------------------------------------------------------------------------------
    // + Class: RequestedIntervalKey
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class RequestedIntervalKey
    {
        public float duration = 0;
        public float elapsed = 0;

        public RequestedIntervalKey(float intervalDuration)
        {
            duration = intervalDuration;
        }

        public override int GetHashCode()
        {
            return duration.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RequestedIntervalKey);
        }

        public bool Equals(RequestedIntervalKey key)
        {
            return duration == key.duration;
        }
    }


    // +---------------------------------------------------------------------------------------------------------------
    // + Class: RequestedIntervalManager
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class RequestedIntervalManager : UpdateIntervalManager
    {
        // Properties  ------------------------------------------------------------------------------------------------
        public Dictionary<RequestedIntervalKey, RequestedIntervalProducer> Producers { get; private set; } = new Dictionary<RequestedIntervalKey, RequestedIntervalProducer>();

        // Class Methods  ---------------------------------------------------------------------------------------------
        public RequestedIntervalManager()
        {
            var producer = new RequestedIntervalProducer();

            AddIntervalListener(GameplayController.DefaultTicksPerItem, producer);
        }

        public void AddIntervalListener(float intervalDuration, RequestedIntervalProducer producer)
        {
            var key = new RequestedIntervalKey(intervalDuration);
            Producers[key] = producer;
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            foreach (var producerMapEntry in Producers)
            {
                var key = producerMapEntry.Key;
                var producer = producerMapEntry.Value;

                key.elapsed += dt;

                while (key.elapsed > key.duration)
                {
                    key.elapsed -= key.duration;
                    producer.Update(key.duration);

                    if (key.elapsed < key.duration)
                    {
                        key.elapsed = 0;
                    }
                }
            }
        }
    }
}
