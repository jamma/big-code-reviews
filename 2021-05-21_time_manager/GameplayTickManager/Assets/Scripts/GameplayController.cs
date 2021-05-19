// +-------------------------------------------------------------------------------------------------------------------
// + File: GameplayController.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 14:13 on 2021/05/17
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
        // Private Members  -------------------------------------------------------------------------------------------
        // private int ticksPerItem = 0;
        // private int tickCooldown = 0;

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        public TickProducer() : base(UpdateIntervalType.Tick)
        {
            // ticksPerItem = (int)Math.Round(1 / ItemsPerTick);
            // tickCooldown = ticksPerItem;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            TotalItems += deltaTime * GameplayController.DefaultItemsPerTick;

            PrintUpdateStats();
        }
    }

    // +---------------------------------------------------------------------------------------------------------------
    // + Class: GameplayController
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class GameplayController : MonoBehaviour
    {
        // Events & Delegates  ----------------------------------------------------------------------------------------
        // public delegate void ZanzoObjectNotify(ZanzoObject res);
        // public event ZanzoObjectNotify Activated;

        // Static / Constants  ----------------------------------------------------------------------------------------
        // public static readonly int SomeConstant = 0;
        public static readonly int TotalTickSeconds = 1;
        public static readonly int DefaultTicksPerItem = 9;
        public static readonly float DefaultItemsPerTick = 1F / DefaultTicksPerItem;

        // Private Members  -------------------------------------------------------------------------------------------
        [SerializeField] private float tickSeconds = 1;
        [SerializeField] [Range(0.1F, 20F)] private float timeScale = 1;

        private SetIntervalManager setIntervalManager = new SetIntervalManager();
        private RequestedIntervalManager requestedIntervalManager = new RequestedIntervalManager();
        private TickProducer tickProducer = new TickProducer();
        private float currentTickElapsedTime = 0;

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

        // Class Methods  ---------------------------------------------------------------------------------------------
        public void Initialize()
        {
        }

        public void Clear()
        {
        }

        // Set Interval Timer Methods  --------------------------------------------------------------------------------
        public void UpdateSetInterval(float deltaTime, float scaledDeltaTime)
        {
            setIntervalManager.Update(scaledDeltaTime);
        }

        public void UpdateRequestedInterval(float deltaTime, float scaledDeltaTime)
        {
            requestedIntervalManager.Update(scaledDeltaTime);
        }

        public void UpdateTick(float deltaTime, float scaledDeltaTime)
        {
            currentTickElapsedTime += scaledDeltaTime;
            if (currentTickElapsedTime >= TotalTickSeconds)
            {
                tickProducer.Update(currentTickElapsedTime);
                currentTickElapsedTime = 0;
            }
        }

        // Unity Life-Cycle Methods  ----------------------------------------------------------------------------------
        void Update()
        {
            var deltaTime = Time.deltaTime;
            var scaledDeltaTime = deltaTime * timeScale;

            UpdateSetInterval(deltaTime, scaledDeltaTime);
            UpdateRequestedInterval(deltaTime, scaledDeltaTime);
            UpdateTick(deltaTime, scaledDeltaTime);
        }
    }
}
