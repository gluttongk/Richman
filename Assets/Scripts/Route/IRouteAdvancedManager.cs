using System.Collections.Generic;
using UnityEngine;

namespace Route
{
    public interface IRouteAdvancedManager
    {
        /// <summary>
        /// 所有的路砖
        /// </summary>
        IReadOnlyList<RoutePadAdvanced> PadAdvanceds { get; }
        
        /// <summary>
        /// 尝试获取第几个路砖的位置
        /// </summary>
        /// <param name="index">第几个</param>
        /// <param name="position">位置变量</param>
        /// <returns>成功与否</returns>
        bool TryGetPadPosition( int index, out Vector3 position );
    }
}