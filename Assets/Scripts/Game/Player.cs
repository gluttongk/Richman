using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using Route;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Player : MonoBehaviour
{
    [Inject]
    private DiceRoller _diceRoller;

    [Inject]
    private IRouteManager _routeManager;

    [SerializeField]
    private float speed = 1.0f;

    private int currenetIndex = 0; // 当前所在的块
    
    private void Update()
    {
        // throw new NotImplementedException();
        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            // roll dies
            _diceRoller.RollDie( out var steps,1);
            Debug.Log( $"Steps: {steps}" );
            // move
            StartCoroutine( Move(steps) );
        }
    }

    private IEnumerator Move(int steps)
    {
        // Vector3 nextPadPosition = Vector3.zero;
        Debug.Log( "计算位置" );
        _routeManager.TryGetPadPosition( currenetIndex, out Vector3 currentPosition );

        // var targetIndex = currenetIndex + steps;
        
        while ( steps > 0 )
        {
            //获取下一个pad的位置
            Vector3 nextPadPosition = Vector3.zero;
            Debug.Log( "开始移动" );
            if ( currenetIndex == _routeManager.Pads.Count - 1 )
            {
                //将下一个pad 设置成原点
                _routeManager.TryGetPadPosition( 0, out nextPadPosition );
                currenetIndex = 0;
            }
            else
            {
                _routeManager.TryGetPadPosition( currenetIndex + 1, out nextPadPosition );
                currenetIndex++;
            }
            
            //移动到下一个Pad的位置
            while ( transform.position != nextPadPosition )
            {
                transform.position = Vector3.MoveTowards( transform.position, nextPadPosition,
                    Time.deltaTime * speed );
                yield return null;
            }
            
            steps--;
        }
    } 
    
    
} 