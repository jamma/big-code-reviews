// +-------------------------------------------------------------------------------------------------------------------
// + File: UpdateIntervalManager.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 22:05 on 2021/05/17
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System;

using UnityEngine;

namespace IdleStuff
{
    // +---------------------------------------------------------------------------------------------------------------
    // + Class: UpdateIntervalManager
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class UpdateIntervalManager
    {
        // Events & Delegates  ----------------------------------------------------------------------------------------
        // public delegate void ZanzoObjectNotify(ZanzoObject res);
        // public event ZanzoObjectNotify Activated;

        // Static / Constants  ----------------------------------------------------------------------------------------
        // public static readonly int SomeConstant = 0;


        // Private Members  -------------------------------------------------------------------------------------------
        // private float updateIntervalElapsedTime = 0;

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
        public float UpdateInterval { get; set; } = 1;
        public float TotalElapsedTime { get; protected set; } = 0;
        public ResourceProducer Producer { get; set; } = null;
        // public float TimeScale { get; set; } = 1;

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        // public override void Initialize() {}
        // public override void Reinitialize() {}
        // public UpdateIntervalManager()
        // {
        //     // Producer = new SetIntervalProducer();
        //     // Producer = new ResourceProducer();
        //     // Producer.ItemsPerTick = 1 / 9F;
        // }

        // Component Functionality  -----------------------------------------------------------------------------------
        public virtual void Update(float dt)
        {
            TotalElapsedTime += dt;
        }
    }
}
