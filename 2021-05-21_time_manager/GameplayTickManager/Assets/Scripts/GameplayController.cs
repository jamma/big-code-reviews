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
    // + Class: GameplayController
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class GameplayController : MonoBehaviour
    {
        // Static / Constants  ----------------------------------------------------------------------------------------
        public static readonly int TicksPerItem = 9;
        public static readonly float ItemsPerTick = 1F / TicksPerItem;

        // Private Members  -------------------------------------------------------------------------------------------
        [SerializeField] private float secondsPerTick = 1;
        [SerializeField] [Range(0.1F, 20F)] private float timeScale = 1; // The scaled number of ticks sent to resource mgrs
        // [SerializeField] [Range(0.1F, 20F)] private float timeScale = 0.5F;

        private SetIntervalManager setIntervalManager = new SetIntervalManager();
        private RequestedIntervalManager requestedIntervalManager = new RequestedIntervalManager();
        private TickIntervalManager tickIntervalManager = new TickIntervalManager();
        private float currentTickElapsedTime = 0;
        private int totalTicks = 0;
        private float totalScaledTicks = 0;

        // Class Methods  ---------------------------------------------------------------------------------------------
        public void Initialize()
        {
        }

        public void Clear()
        {
        }

        // Unity Life-Cycle Methods  ----------------------------------------------------------------------------------
        void Update()
        {
            // Debug.Log("GameplayController::Update()");

            currentTickElapsedTime += Time.deltaTime;

            // NOTE: This (I think) breaks down if seconds per tick is too small,
            //       but for purposes of this code review, this crude calculation is fine.
            if (currentTickElapsedTime > secondsPerTick)
            {
                totalTicks += 1;
                totalScaledTicks += timeScale;

                // Debug.Log("GameplayController::Update() - new tick, scaled ticks: " + scaledElapsedTicks + " total ticks: " + totalTicks);

                setIntervalManager.Update(timeScale);
                requestedIntervalManager.Update(timeScale);
                tickIntervalManager.Update(timeScale);

                currentTickElapsedTime = 0;
            }
        }
    }
}
