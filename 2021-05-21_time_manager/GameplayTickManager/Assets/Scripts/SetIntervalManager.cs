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
        private int ticksPerItem = GameplayController.DefaultTicksPerItem;
        private int tickCooldown = GameplayController.DefaultTicksPerItem;

        // Class Methods  ---------------------------------------------------------------------------------------------
        public SetIntervalProducer() : base(UpdateIntervalType.Set)
        {
            // ticksPerItem = (int)Math.Round(1 / ItemsPerTick);
            // tickCooldown = GameplayController.DefaultTicksPerItem;
        }

        public override void Update(float intervalTime)
        {
            base.Update(intervalTime);

            tickCooldown -= 1;

            if (tickCooldown <= 0)
            {
                TotalItems += 1;
                tickCooldown = GameplayController.DefaultTicksPerItem;
            }

            PrintUpdateStats();
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
        public delegate void UpdateNotify(float intervalTime);
        public event UpdateNotify UpdateProducer;

        // Private Members  -------------------------------------------------------------------------------------------
        private float updateIntervalElapsedTime = 0;
        public SetIntervalProducer Producer { get; private set; }

        // Class Methods  ---------------------------------------------------------------------------------------------
        public SetIntervalManager()
        {
            Producer = new SetIntervalProducer();
            UpdateProducer += Producer.Update;
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            updateIntervalElapsedTime += dt;

            while(updateIntervalElapsedTime >= UpdateInterval)
            {
                UpdateProducer?.Invoke(updateIntervalElapsedTime - 1);
                updateIntervalElapsedTime -= 1;

                if (updateIntervalElapsedTime < 1)
                {
                    updateIntervalElapsedTime = 0;
                }
            }

        }
    }
}
