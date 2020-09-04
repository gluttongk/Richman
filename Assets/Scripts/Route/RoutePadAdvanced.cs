using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Route
{
    public class RoutePadAdvanced : MonoBehaviour
    {
        // 是否是转角
        [SerializeField]
        private bool isCornerPad;

        // 是否具有事件
        // [SerializeField]
        // private bool isEventPad;

        // private List<Event> _events;

        // 是否具有地产的Pad
        [SerializeField]
        private bool isEstatePad;

        // 相连的块
        [SerializeField]
        private List<RoutePadAdvanced> _connectedPads;

        private void Reset()
        {
            
        }

        public void AddToConnectedPads( RoutePadAdvanced routePadAdvanced )
        {
            _connectedPads?.Add( routePadAdvanced );
        }
    }
}