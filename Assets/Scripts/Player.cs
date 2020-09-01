using System;
using System.Collections;
using Route;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 5f;

    [Inject]
    private IRouteManager _routeManager;

    [Inject]
    private DiceRoller _diceRoller;

    private int _startingIndex;
    private int _currentIndex;

    private void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            var steps = RollADie();
            Debug.Log( "Rolled " + steps + " step(s)" );

            var nextIndex = _currentIndex + steps;
            nextIndex %= _routeManager.Pads.Count;

            StartCoroutine( Move( steps, nextIndex ) );
        }
    }

    private IEnumerator Move( int steps, int endIndex )
    {
        while ( _currentIndex != endIndex )
        {
            var nextIndex = _currentIndex + 1;
            if ( _routeManager.TryGetPadPosition( _currentIndex, out var currentPosition ) )
            {
                var nextPosition = Vector3.zero;
                if ( nextIndex >= _routeManager.Pads.Count &&
                     _routeManager.TryGetPadPosition( 0, out var position ) )
                {
                    nextIndex = 0;
                    nextPosition = position;
                }
                else if ( _routeManager.TryGetPadPosition( _currentIndex + 1, out var pos ) )
                {
                    nextPosition = pos;
                }

                while ( transform.position != nextPosition )
                {
                    transform.position = Vector3.MoveTowards( transform.position, nextPosition,
                        Time.deltaTime * _movementSpeed );
                    yield return null;
                }
            }

            _currentIndex = nextIndex;
        }
    }

    private int RollADie()
    {
        _diceRoller.Roll( out var result );

        return result.Results[0];
    }
}