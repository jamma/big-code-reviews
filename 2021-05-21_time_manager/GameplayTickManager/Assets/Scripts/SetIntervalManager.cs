// +-------------------------------------------------------------------------------------------------------------------
// + File: SetIntervalManager.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 14:30 on 2021/05/17
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using UnityEngine;

namespace IdleStuff
{
    // +---------------------------------------------------------------------------------------------------------------
    // + Class: SetIntervalProducer
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class SetIntervalProducer : ResourceProducer
    {
        // Private Members  -------------------------------------------------------------------------------------------
        private int ticksPerItem = GameplayController.TicksPerItem;
        private float currentElapsedTicks = 0;

        // Class Methods  ---------------------------------------------------------------------------------------------
        public SetIntervalProducer() : base(UpdateIntervalType.Set) {}

        public override void Update(float ticksElapsed)
        {
            base.Update(ticksElapsed);

            currentElapsedTicks += ticksElapsed;

            if (currentElapsedTicks >= ticksPerItem)
            {
                TotalItems += 1;
                currentElapsedTicks -= ticksPerItem;
            }

            // PrintUpdateStats();
        }
    }

    // +---------------------------------------------------------------------------------------------------------------
    // + Class: SetIntervalManager
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class SetIntervalManager : UpdateIntervalManager
    {
        // Events & Delegates  ----------------------------------------------------------------------------------------
        public delegate void UpdateNotify(float ticksElapsed);
        public event UpdateNotify UpdateProducer;

        // Private Members  -------------------------------------------------------------------------------------------
        private float tickUpdateInterval = 1;   // Update on every tick
        private float ticksSinceLastUpdate = 0;
        public SetIntervalProducer Producer { get; private set; }

        // Class Methods  ---------------------------------------------------------------------------------------------
        public SetIntervalManager()
        {
            Producer = new SetIntervalProducer();
            UpdateProducer += Producer.Update;
        }

        public override void Update(float ticksElapsed)
        {
            // Debug.Log("SetIntervalManager::Update(" + ticksElapsed + ")");
            ticksSinceLastUpdate += ticksElapsed;

            // Accumulate ticks until we pass the update threshold,
            // then keep invoking event as long as we're above update threshold
            while(ticksSinceLastUpdate >= tickUpdateInterval)
            {
                UpdateProducer?.Invoke(tickUpdateInterval);
                ticksSinceLastUpdate -= tickUpdateInterval;
            }
        }
    }
}
