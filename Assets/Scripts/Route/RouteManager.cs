using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Route
{
    public class RouteManager : MonoBehaviour, IRouteManager
    {
        [SerializeField]
        private List<RoutePad> _routePads;
        public IReadOnlyList<RoutePad> Pads => _routePads;
        public bool TryGetPadPosition( int index, out Vector3 position )
        {
            // throw new NotImplementedException();
            if ( index < 0 || index >= _routePads.Count )
            {
                position = Vector3.zero;
                return false;
            }

            position = _routePads[index].transform.position;
            return true;
        }

        public void Reset()
        {
            GetAllPads();
        }

        private void GetAllPads()
        {
            _routePads = new List<RoutePad>(GetComponentsInChildren<RoutePad>());
        }
    }
}