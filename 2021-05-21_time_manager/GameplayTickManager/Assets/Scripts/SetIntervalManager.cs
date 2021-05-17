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
    public class SetIntervalManager : IntervalManager
    {
        // Events & Delegates  ----------------------------------------------------------------------------------------
        // public delegate void ZanzoObjectNotify(ZanzoObject res);
        // public event ZanzoObjectNotify Activated;
        public delegate void UpdateNotify(float intervalTime, float totalElapsedTime);
        public event UpdateNotify UpdateProducer;

        // Static / Constants  ----------------------------------------------------------------------------------------
        // public static readonly int SomeConstant = 0;
        public static readonly float SecondThreshold = 1;
        // public static readonly float MinuteThreshold = 60;
        // public static readonly float HourThreshold = 3600;


        // Private Members  -------------------------------------------------------------------------------------------
        // private bool _somePrivateMember;
        // private float 
        private float _totalElapsedTime = 0;
        private float _secondTimerElapsedTime = 0;
        private float _minuteTimerElapsedTime = 0;
        private float _hourTimerElapsedTime = 0;

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
        public ResourceProducer Producer { get; } = null;
        // public float TimeScale { get; set; } = 1;

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        // public override void Initialize() {}
        // public override void Reinitialize() {}

        // Component Functionality  -----------------------------------------------------------------------------------
        public void Update(float dt)
        {
            _totalElapsedTime += dt;
            _secondTimerElapsedTime += dt;

            while(_secondTimerElapsedTime >= 1)
            {
                UpdateProducer?.Invoke(_secondTimerElapsedTime - 1, _totalElapsedTime);
                _secondTimerElapsedTime -= 1;

                if (_secondTimerElapsedTime < 1)
                {
                    _secondTimerElapsedTime = 0;
                }
            }

        }
    }
}
