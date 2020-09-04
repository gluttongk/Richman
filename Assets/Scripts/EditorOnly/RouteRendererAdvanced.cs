using System.Collections.Generic;
using Route;
using UnityEngine;

namespace EditorOnly
{
    public class RouteRendererAdvanced : MonoBehaviour
    {
        [SerializeField]
        private List<RoutePadAdvanced> _routePadAdvanced;
        
        private void OnDrawGizmos()
        {
            _routePadAdvanced.Clear();
            _routePadAdvanced.AddRange( GetComponentsInChildren<RoutePadAdvanced>() );

            Gizmos.color = new Color( 0.51f, 0.69f, 1f );
            for ( var i = 0; i < _routePadAdvanced.Count - 1; ++i )
            {
                var pad = _routePadAdvanced[i];
                var startPosition = pad.transform.position;
                var nextPosition = _routePadAdvanced[i + 1].transform.position;
            
                Gizmos.DrawLine( startPosition, nextPosition );
            }
        }
    }
}