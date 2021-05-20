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
    // // +---------------------------------------------------------------------------------------------------------------
    // // + Class: TickProducer
    // // + Description:
    // // +    Insert Description Here
    // // +---------------------------------------------------------------------------------------------------------------
    // public class TickProducer : ResourceProducer
    // {
    //     // Private Members  -------------------------------------------------------------------------------------------
    //     // private int ticksPerItem = 0;
    //     // private int tickCooldown = 0;

    //     // C'tor & Init Methods  --------------------------------------------------------------------------------------
    //     public TickProducer() : base(UpdateIntervalType.Tick)
    //     {
    //         // ticksPerItem = (int)Math.Round(1 / ItemsPerTick);
    //         // tickCooldown = ticksPerItem;
    //     }

    //     public override void Update(float deltaTime)
    //     {
    //         base.Update(deltaTime);

    //         TotalItems += deltaTime * GameplayController.DefaultItemsPerTick;

    //         PrintUpdateStats();
    //     }
    // }

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
        public static readonly int TicksPerItem = 9;
        public static readonly float ItemsPerTick = 1F / TicksPerItem;

        // Private Members  -------------------------------------------------------------------------------------------
        [SerializeField] private float secondsPerTick = 1;
        // [SerializeField] [Range(0.1F, 20F)] private float timeScale = 1;
        [SerializeField] [Range(0.1F, 20F)] private float timeScale = 0.5F;

        private SetIntervalManager setIntervalManager = new SetIntervalManager();
        private RequestedIntervalManager requestedIntervalManager = new RequestedIntervalManager();
        private TickIntervalManager tickIntervalManager = new TickIntervalManager();
        private float currentTickElapsedTime = 0;
        private int totalTicks = 0;
        private float totalScaledTicks = 0;

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
        // public void UpdateSetInterval(float deltaTime, float scaledDeltaTime)
        // public void UpdateSetInterval(int ticksElapsed)
        // {
        //     setIntervalManager.Update(ticksElapsed);
        // }

        // // public void UpdateRequestedInterval(float deltaTime, float scaledDeltaTime)
        // public void UpdateRequestedInterval(int ticksElapsed)
        // {
        //     requestedIntervalManager.Update(ticksElapsed);
        // }

        // // public void UpdateTick(float deltaTime, float scaledDeltaTime)
        // public void UpdateTick(int ticksElapsed)
        // {
        //     // currentTickElapsedTime += scaledDeltaTime;
        //     // if (currentTickElapsedTime >= TotalTickSeconds)
        //     // {
        //     //     tickProducer.Update(currentTickElapsedTime);
        //     //     currentTickElapsedTime = 0;
        //     // }
        // }

        // Unity Life-Cycle Methods  ----------------------------------------------------------------------------------
        void Update()
        {
            // Debug.Log("GameplayController::Update()");

            currentTickElapsedTime += Time.deltaTime;

            // NOTE: This (I think) breaks down if seconds per tick is too small,
            //       but for purposes of this code review, this crude calculation is fine.
            if (currentTickElapsedTime > secondsPerTick)
            {
                // var scaledElapsedTicks = (int)(secondsPerTick * timeScale);
                totalTicks += 1;
                totalScaledTicks += timeScale;

                // Debug.Log("GameplayController::Update() - new tick, scaled ticks: " + scaledElapsedTicks + " total ticks: " + totalTicks);

                setIntervalManager.Update(timeScale);
                requestedIntervalManager.Update(timeScale);
                tickIntervalManager.Update(timeScale);

                currentTickElapsedTime = 0;
            }
            // var deltaTime = Time.deltaTime;
            // var scaledDeltaTime = deltaTime * timeScale;

            // UpdateSetInterval(deltaTime, scaledDeltaTime);
            // UpdateRequestedInterval(deltaTime, scaledDeltaTime);
            // UpdateTick(deltaTime, scaledDeltaTime);
        }
    }
}
