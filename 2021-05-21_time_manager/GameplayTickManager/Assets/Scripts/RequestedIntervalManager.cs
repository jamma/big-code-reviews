// +-------------------------------------------------------------------------------------------------------------------
// + File: RequestedIntervalManager.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 14:30 on 2021/05/17
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using UnityEngine;

namespace IdleStuff
{
    // public class RequestedIntervalKey
    // {
    //     public float duration = 0;
    //     public float elapsed = 0;

    //     public RequestedIntervalKey(float intervalDuration)
    //     {
    //         duration = intervalDuration;
    //     }

    //     public override int GetHashCode()
    //     {
    //         return duration.GetHashCode();
    //     }

    //     public override bool Equals(object obj)
    //     {
    //         return Equals(obj as RequestedIntervalKey);
    //     }

    //     public bool Equals(RequestedIntervalKey key)
    //     {
    //         return duration == key.duration;
    //     }
    // }


    // +---------------------------------------------------------------------------------------------------------------
    // + Class: RequestedIntervalManager
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class RequestedIntervalManager : UpdateIntervalManager
    {
        // Events & Delegates  ----------------------------------------------------------------------------------------
        // public delegate void ZanzoObjectNotify(ZanzoObject res);
        // public event ZanzoObjectNotify Activated;

        // Static / Constants  ----------------------------------------------------------------------------------------
        // public static readonly int SomeConstant = 0;

        // Private Members  -------------------------------------------------------------------------------------------
        // private bool _somePrivateMember;
        // private Dictionary<RequestedIntervalKey, ResourceProducer> producerMap = new Dictionary<RequestedIntervalKey, ResourceProducer>();
        // private float 
        private float updateInterval = 0;
        private float elapsedIntervalDuration = 0;
        // private float
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

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        // public override void Initialize() {}
        // public override void Reinitialize() {}
        public RequestedIntervalManager()
        {
            // var producer = new RequestedIntervalProducer();
            Producer = new ResourceProducer();

            // Not a good way to handle this, just doing it for this code review
            // This will increase the number of updates the more items are created per tick.
            // Ideally this interval should not be based on how many items are created per tick
            // var updateInterval = 1 / Producer.ItemsPerTick;
            updateInterval = 1 / Producer.ItemsPerTick;

            // AddIntervalListener(updateInterval, producer);
        }

        // public void AddIntervalListener(float intervalDuration, ResourceProducer producer)
        // {
        //     var key = new RequestedIntervalKey(intervalDuration);
        //     // producerMap[key] = producer;
        // }

        // Component Functionality  -----------------------------------------------------------------------------------
        // public void SomeFunc()
        // {
        // }
        // public void Update(float dt)
        // {
        //     elapsedIntervalDuration += dt;

        //     while(elapsedIntervalDuration >= 1)
        //     {
        //         // UpdateProducer?.Invoke(elapsedIntervalDuration - 1, 1000);
        //         // elapsedIntervalDuration -= 1;

        //         // if (elapsedIntervalDuration < 1)
        //         // {
        //         //     elapsedIntervalDuration = 0;
        //         // }
        //     }
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
