using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceRoller
{
    private int steps;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="steps">返回的步数</param>
    /// <param name="amount">几个色子</param>
    /// <param name="dieSize">色子的点输</param>
    public void RollDie(out int steps, int amount = 1, int dieSize = 6)
    {
        steps = 0;

        for ( int i = 0; i < amount; i++ )
        {
            var step = Random.Range( 1, dieSize + 1 );
            steps += step;
            // Debug.Log( $"{i}: steps + {step} = {steps}" );
        }
    }
}
