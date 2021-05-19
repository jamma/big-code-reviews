// +-------------------------------------------------------------------------------------------------------------------
// + File: UpdateIntervalManager.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 22:05 on 2021/05/17
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
    // + Class: ResourceProducer
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class ResourceProducer
    {
        // Properties  ------------------------------------------------------------------------------------------------
        public UpdateIntervalType UpdateType { get; private set; }
        public float TotalItems { get; set; } = 0;
        public int TotalUpdateCalls { get; set; } = 0;

        // Class Methods  ---------------------------------------------------------------------------------------------
        public ResourceProducer(UpdateIntervalType updateType)
        {
            UpdateType = updateType;
        }

        public virtual void Update(float intervalTime)
        {
            TotalUpdateCalls += 1;
        }

        public void PrintUpdateStats()
        {
            Debug.Log("ResourceProducer::Update() - type: " + UpdateType + " total items: " + TotalItems + " total update calls: " + TotalUpdateCalls);
        }
    }


    // +---------------------------------------------------------------------------------------------------------------
    // + Class: UpdateIntervalManager
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class UpdateIntervalManager
    {
        public float UpdateInterval { get; set; } = 1;
        public float TotalElapsedTime { get; protected set; } = 0;
        // public ResourceProducer Producer { get; set; } = null;
        // public IReadOnlyList<ResourceProducer> Producers { get; protected set; }

        public virtual void Update(float dt)
        {
            TotalElapsedTime += dt;
        }
    }
}
