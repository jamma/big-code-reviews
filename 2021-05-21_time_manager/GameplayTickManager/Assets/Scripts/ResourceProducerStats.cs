// +-------------------------------------------------------------------------------------------------------------------
// + File: ResourceProducerStats
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 13:17 on 2021/05/21
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
    // + Class: ResourceProducerStats
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class ResourceProducerStats : MonoBehaviour
    {
        // Private Members  -------------------------------------------------------------------------------------------
        private ResourceProducer resourceProducer;

        // Inspector / Editor Properties  -----------------------------------------------------------------------------
        [SerializeField] private Text title;
        [SerializeField] private Text itemCountHeader;
        [SerializeField] private Text itemCountValue;
        [SerializeField] private Text updateCallCountHeader;
        [SerializeField] private Text updateCallCountValue;

        // Class Methods  ---------------------------------------------------------------------------------------------
        public void Initialize(ResourceProducer producer)
        {
            resourceProducer = producer;
            var titleString = "";

            if (resourceProducer.UpdateType.IsSet())
            {
                titleString = "Set Interval";
            }
            else if (resourceProducer.UpdateType.IsRequested())
            {
                titleString = "Requested Interval";
            }
            else if (resourceProducer.UpdateType.IsTick())
            {
                titleString = "Every Tick";
            }

            title.text = titleString;
            itemCountValue.text = "0";
            updateCallCountValue.text = "0";
        }

        public void UpdateStats()
        {
            itemCountValue.text = resourceProducer.TotalItems.ToString();
            updateCallCountValue.text = resourceProducer.TotalUpdateCalls.ToString();
        }
    }
}
