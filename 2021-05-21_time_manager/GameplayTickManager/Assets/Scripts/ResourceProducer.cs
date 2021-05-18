// +-------------------------------------------------------------------------------------------------------------------
// + File: ResourceProducer.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 21:57 on 2021/05/17
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System;

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
        // Events & Delegates  ----------------------------------------------------------------------------------------
        // public delegate void ZanzoObjectNotify(ZanzoObject res);
        // public event ZanzoObjectNotify Activated;

        // Static / Constants  ----------------------------------------------------------------------------------------
        // public static readonly int SomeConstant = 0;
        // public static readonly int SecondsBetweenUpdates = 9;

        // Private Members  -------------------------------------------------------------------------------------------
        private float _totalItems = 0;

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
        public float TotalItems { get; set; } = 0;
        public float ItemsPerTick { get; set; } = GameplayController.DefaultItemsPerTick;
        public int TotalUpdateCalls { get; set; } = 0;

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        // public override void Initialize() {}
        // public override void Reinitialize() {}

        // Component Functionality  -----------------------------------------------------------------------------------
        // public void SomeFunc()
        // {
        // }
        public void Update(float intervalTime, float totalElapsedTime)
        {
            TotalUpdateCalls += 1;
            TotalItems += ItemsPerTick;
            // _secondsSinceLastUpdate += 1;
            // if (_secondsSinceLastUpdate >= _ticksPerItem)
            // {
            //     // Do update
            //     _secondsSinceLastUpdate = 0;
            // }
        }

        // private void SetItemsPerTick(float value)
        // {
        //     _itemsPerTick = value;
        //     _ticksPerItem = 1 / _itemsPerTick;
        // }
        // Unity Life-Cycle Methods  ----------------------------------------------------------------------------------
        // Order: https://docs.unity3d.com/Manual/ExecutionOrder.html
        // void Awake()
        // {
        // }

        // void OnEnable()
        // {
        // }

        // void OnDisable()
        // {
        // }

        // void Start()
        // {
        // }

        // void Update()
        // {
        // }

        // void FixedUpdate()
        // {
        // }

        // void LateUpdate()
        // {
        // }

        // void OnApplicationQuit()
        // {
        // }

        // void OnDisable()
        // {
        // }
    }
}
