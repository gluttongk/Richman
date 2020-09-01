using System.Collections.Generic;
using UnityEngine;

namespace EditorOnly
{
    public class RouteRenderer : MonoBehaviour
    {
        [SerializeField]
        private List<RoutePad> _routePads;

        private void OnDrawGizmos()
        {
            _routePads.Clear();
            _routePads.AddRange( GetComponentsInChildren<RoutePad>() );

            Gizmos.color = new Color( 0.51f, 0.69f, 1f );
            for ( var i = 0; i < _routePads.Count - 1; ++i )
            {
                var pad = _routePads[i];
                var startPosition = pad.transform.position;
                var nextPosition = _routePads[i + 1].transform.position;
            
                Gizmos.DrawLine( startPosition, nextPosition );
            }
        }
    }
}
