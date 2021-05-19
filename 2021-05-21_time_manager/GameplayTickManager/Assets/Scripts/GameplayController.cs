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
    // public interface ResourceProducer
    // {
    //     float ItemsPerTick { get; set; }
    //     float TotalItems { get; }
    //     int TotalUpdateCalls { get; }
    //     void Update(float intervalTime, float totalElapsedTime);
    // }

    public interface IntervalManager
    {
        ResourceProducer Producer { get; }
        void Update(float dt);
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
        public static readonly float DefaultItemsPerTick = 9;

        // Private Members  -------------------------------------------------------------------------------------------
        // private bool _somePrivateMember;
        [SerializeField] private float tickSeconds = 1;
        [SerializeField] [Range(0.1F, 20F)] private float timeScale = 1;

// UpdateIntervalManager
        // private SetIntervalManager setIntervalManager = new SetIntervalManager();
        // private RequestedIntervalManager requestedIntervalManager = new RequestedIntervalManager();
        private SetIntervalManager setIntervalManager = new SetIntervalManager();
        private RequestedIntervalManager requestedIntervalManager = new RequestedIntervalManager();
        private ResourceProducer tickProducer = new ResourceProducer("Tick Producer");
        private float _currentTickElapsedTime = 0;

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

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        // public override void Initialize() {}
        // public override void Reinitialize() {}
        public void Initialize()
        {
        }

        // Component Functionality  -----------------------------------------------------------------------------------
        // public void SomeFunc()
        // {
        // }
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
            _currentTickElapsedTime += deltaTime;
            if (_currentTickElapsedTime >= TotalTickSeconds)
            {
                // tickProducer.Upd
                _currentTickElapsedTime = 0;
            }
        }

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

        void Update()
        {
            var deltaTime = Time.deltaTime;
            var scaledDeltaTime = deltaTime * timeScale;

            UpdateSetInterval(deltaTime, scaledDeltaTime);
            UpdateRequestedInterval(deltaTime, scaledDeltaTime);
            UpdateTick(deltaTime, scaledDeltaTime);
        }

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
