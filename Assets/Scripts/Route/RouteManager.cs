using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Route
{
    public class RouteManager : MonoBehaviour, IRouteManager
    {
        public IReadOnlyList<RoutePad> Pads => _routePads;

        public bool TryGetPadPosition( int index, out Vector3 position )
        {
            if ( index < 0 || index >= _routePads.Count )
            {
                position = Vector3.zero;
                return false;
            }

            position = _routePads[index].transform.position;
            return true;
        }

        [SerializeField]
        private List<RoutePad> _routePads;

        private void Awake()
        {
            AssignPads();
        }

        private void Reset()
        {
            AssignPads();
        }

        private void AssignPads()
        {
            _routePads = new List<RoutePad>( GetComponentsInChildren<RoutePad>() );
        }
    }
}