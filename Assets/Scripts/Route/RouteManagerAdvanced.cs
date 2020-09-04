using System;
using System.Collections.Generic;
using UnityEngine;

namespace Route
{
    public class RouteManagerAdvanced : MonoBehaviour, IRouteAdvancedManager
    {
        public IReadOnlyList<RoutePadAdvanced> PadAdvanceds => _routePadAdvances;
        
        [SerializeField]
        private List<RoutePadAdvanced> _routePadAdvances;
        
        
        public bool TryGetPadPosition( int index, out Vector3 position )
        {
            if ( index < 0 || index >= _routePadAdvances.Count )
            {
                position = Vector3.zero;
                return false;
            }

            position = _routePadAdvances[index].transform.position;
            return true;
        }

#if UNITY_EDITOR
        private void Reset()
        {
            AssignPads();
        }

        private void AssignPads()
        {
            _routePadAdvances = new List<RoutePadAdvanced>( GetComponentsInChildren<RoutePadAdvanced>() );

            // Debug.Log( $"_routePads.Count: {_routePads.Count}" );
            
            // add 相连的块
            for ( int pad = 0; pad < _routePadAdvances.Count; pad++ )
            {
                // Debug.LogWarning( $"{_routePadAdvances[pad].name} will add:" );
                foreach ( var anotherPad in _routePadAdvances )
                {
                    if ( anotherPad == _routePadAdvances[pad] )
                    {
                        continue;
                    }
                    
                    //获取没一个块 和 当前的块 坐标属性的 差值
                    var delta = anotherPad.transform.position - _routePadAdvances[pad].transform.position;
                    
                    // 每个相连的pad的position属性 只允许xyz中的一个值不为0，否则就是不相连的。
                    if ( IsConnected(delta)  )
                    {
                        _routePadAdvances[pad].AddToConnectedPads( anotherPad );
                        // Debug.Log( $"       {anotherPad.name} was added" );
                    }
                }
            }
        }
#endif
        private bool IsConnected(Vector3 delta)
        {
            var d = new Vector3( Mathf.Abs( delta.x ), Mathf.Abs( delta.y ), Mathf.Abs( delta.z ) );
            return ( ( Mathf.Approximately( d.x, 4 ) && Mathf.Approximately( d.y, 0 ) &&
                       Mathf.Approximately( d.z, 0 ) )
                     || ( Mathf.Approximately( d.x, 0 ) && Mathf.Approximately( d.y, 4 ) &&
                          Mathf.Approximately( d.z, 0 ) )
                     || ( Mathf.Approximately( d.x, 0 ) && Mathf.Approximately( d.y, 0 ) &&
                          Mathf.Approximately( d.z, 4 ) ) );
        }
    }
}