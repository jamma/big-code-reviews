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

        public override void Update(float ticksElapsed)
        {
            base.Update(ticksElapsed);
            TotalItems += 1;

            // PrintUpdateStats();
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

        public RequestedIntervalKey(int requestedTickInterval)
        {
            duration = requestedTickInterval;
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

            AddIntervalListener(GameplayController.TicksPerItem, producer);
        }

        public void AddIntervalListener(int requestedTickInterval, RequestedIntervalProducer producer)
        {
            var key = new RequestedIntervalKey(requestedTickInterval);
            Producers[key] = producer;
        }

        public override void Update(float ticksElapsed)
        {
            // Debug.Log("RequestedIntervalManager::Update(" + ticksElapsed + ")");

            // Loop through each producer (only one in this example)
            foreach (var producerMapEntry in Producers)
            {
                var key = producerMapEntry.Key;
                var producer = producerMapEntry.Value;

                // Update the elapsed ticks for this producer
                key.elapsed += ticksElapsed;

                // Keep looping until we've exhausted all tick interval updates
                while (key.elapsed > key.duration)
                {
                    producer.Update(key.duration);
                    key.elapsed -= key.duration;
                }
            }
        }
    }
}
