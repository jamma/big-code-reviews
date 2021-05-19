// +-------------------------------------------------------------------------------------------------------------------
// + File: SetIntervalManager.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 14:30 on 2021/05/17
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System;

using UnityEngine;

namespace IdleStuff
{
    // +---------------------------------------------------------------------------------------------------------------
    // + Class: SetIntervalManager
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class SetIntervalManager : UpdateIntervalManager
    {
        // Events & Delegates  ----------------------------------------------------------------------------------------
        // public delegate void ZanzoObjectNotify(ZanzoObject res);
        // public event ZanzoObjectNotify Activated;
        // public delegate void UpdateNotify(float intervalTime, float totalElapsedTime);
        // public event UpdateNotify UpdateProducer;
        public delegate void UpdateNotify(float intervalTime, float totalElapsedTime);
        public event UpdateNotify UpdateProducer;

        // Static / Constants  ----------------------------------------------------------------------------------------
        // public static readonly float UpdateIntervalSeconds = 1;

        // Private Members  -------------------------------------------------------------------------------------------
        private float updateIntervalElapsedTime = 0;

        // Public Members  --------------------------------------------------------------------------------------------
        // public float dontDeclarePublicMembers;

        // Inspector / Editor Properties  -----------------------------------------------------------------------------
        // public string unlessTheyreEditorProperties;

        // Properties  ------------------------------------------------------------------------------------------------
        // public bool SomeProperty
        // {
        //     get
        //     {
        //         return _somePrivateMember;
        //     }
        //     set
        //     {
        //         _somePrivateMember = value;
        //     }
        // }
        // public ResourceProducer Producer { get; } = null;
        // public float TimeScale { get; set; } = 1;

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        // public override void Initialize() {}
        // public override void Reinitialize() {}
        public SetIntervalManager() : base()
        {
            // base();
            // Producer = new SetIntervalProducer();
            Producer = new ResourceProducer("Set Interval Producer");
            UpdateProducer += Producer.Update;

            // Producer.ItemsPerTick = 1 / 9F;
        }

        // Component Functionality  -----------------------------------------------------------------------------------
        public override void Update(float dt)
        {
            base.Update(dt);

            updateIntervalElapsedTime += dt;

            while(updateIntervalElapsedTime >= UpdateInterval)
            {
                UpdateProducer?.Invoke(updateIntervalElapsedTime - 1, TotalElapsedTime);
                updateIntervalElapsedTime -= 1;

                if (updateIntervalElapsedTime < 1)
                {
                    updateIntervalElapsedTime = 0;
                }
            }

        }
    }
}
