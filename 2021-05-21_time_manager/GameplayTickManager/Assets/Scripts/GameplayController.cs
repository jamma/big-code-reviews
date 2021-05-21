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
using UnityEngine.UI;

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
        public const float MinTickScale = 0.1F;
        public const float MaxTickScale = 20;

        // Private Members  -------------------------------------------------------------------------------------------
        [SerializeField] private float secondsPerTick = 1;
        [SerializeField] [Range(MinTickScale, MaxTickScale)] private float tickScale = 1; // The scaled number of ticks sent to resource mgrs

        [SerializeField] private Text tickScaleValue;
        [SerializeField] private Slider tickScaleSlider;
        [SerializeField] private ResourceProducerStats setIntervalStats;
        [SerializeField] private ResourceProducerStats requestedIntervalStats;
        [SerializeField] private ResourceProducerStats tickStats;

        private SetIntervalManager setIntervalManager = new SetIntervalManager();
        private RequestedIntervalManager requestedIntervalManager = new RequestedIntervalManager();
        private TickIntervalManager tickIntervalManager = new TickIntervalManager();
        private float currentTickElapsedTime = 0;
        private int totalTicks = 0;
        private float totalScaledTicks = 0;

        // Class Methods  ---------------------------------------------------------------------------------------------
        public void Initialize()
        {
            setIntervalStats.Initialize(setIntervalManager.Producer);

            // Yup this is hack-ish, but I know there's only one in here
            foreach (var reqProd in requestedIntervalManager.Producers.Values)
            {
                requestedIntervalStats.Initialize(reqProd);
                break;
            }

            tickStats.Initialize(tickIntervalManager.Producer);
            SetTickScale(tickScale);
        }

        public void Clear()
        {
        }

        public void UpdateResourceProducerStats()
        {
            setIntervalStats.UpdateStats();
            requestedIntervalStats.UpdateStats();
            tickStats.UpdateStats();
        }

        public void OnTickScaleSliderChanged()
        {
            SetTickScaleFromSlider();
        }

        private void SetTickScale(float value)
        {
            // Debug.Log("GameplayController::SetTickScale()");

            value = Math.Min(MaxTickScale, value);
            value = Math.Max(MinTickScale, value);

            tickScale = value;
            tickScaleValue.text = tickScale.ToString();

            var tickScaleRangeDelta = MaxTickScale - MinTickScale;
            var sliderValue = tickScale - MinTickScale;
            sliderValue = sliderValue / tickScaleRangeDelta;
            tickScaleSlider.value = sliderValue;
        }

        private void SetTickScaleFromSlider()
        {
            // Debug.Log("GameplayController::SetTickScaleFromSlider()");
            var tickScaleRangeDelta = MaxTickScale - MinTickScale;
            tickScale = (tickScaleSlider.value * tickScaleRangeDelta) + MinTickScale;

            tickScaleValue.text = tickScale.ToString();
        }

        // Unity Life-Cycle Methods  ----------------------------------------------------------------------------------
        void Awake()
        {
            Initialize();
        }

        void Update()
        {
            // Debug.Log("GameplayController::Update()");

            currentTickElapsedTime += Time.deltaTime;

            // NOTE: This (I think) breaks down if seconds per tick is too small,
            //       but for purposes of this code review, this crude calculation is fine.
            if (currentTickElapsedTime > secondsPerTick)
            {
                totalTicks += 1;
                totalScaledTicks += tickScale;

                // Debug.Log("GameplayController::Update() - new tick, scaled ticks: " + scaledElapsedTicks + " total ticks: " + totalTicks);

                setIntervalManager.Update(tickScale);
                requestedIntervalManager.Update(tickScale);
                tickIntervalManager.Update(tickScale);

                currentTickElapsedTime = 0;

                UpdateResourceProducerStats();
            }
        }
    }
}
