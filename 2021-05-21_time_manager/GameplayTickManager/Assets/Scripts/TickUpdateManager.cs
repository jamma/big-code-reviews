// +-------------------------------------------------------------------------------------------------------------------
// + File: TickManager.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 20:50 on 2021/05/19
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System;

using UnityEngine;

namespace IdleStuff
{
    // +---------------------------------------------------------------------------------------------------------------
    // + Class: TickProducer
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class TickProducer : ResourceProducer
    {
        public TickProducer() : base(UpdateIntervalType.Tick) {}

        public override void Update(float ticksElapsed)
        {
            base.Update(ticksElapsed);

            TotalItems += ticksElapsed * GameplayController.ItemsPerTick;

            // PrintUpdateStats();
        }
    }

    // +---------------------------------------------------------------------------------------------------------------
    // + Class: TickIntervalManager
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class TickIntervalManager : UpdateIntervalManager
    {
        public TickProducer Producer { get; private set; }

        public TickIntervalManager()
        {
            Producer = new TickProducer();
        }

        public override void Update(float ticksElapsed)
        {
            Producer.Update(ticksElapsed);
        }
    }
}
