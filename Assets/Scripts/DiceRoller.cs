using System.Collections.Generic;
using UnityEngine;

public readonly struct DiceResult
{
    public readonly int Amount;
    public readonly int[] Results;

    public DiceResult( int amount, int[] results )
    {
        Amount = amount;
        Results = results;
    }
}

public class DiceRoller
{
    public void Roll( out DiceResult result, int amount = 1, int max = 6 )
    {
        var results = new List<int>();
        for ( var i = 0; i < amount; ++i )
        {
            results.Add( RollADie( max ) );
        }
        
        result = new DiceResult( amount, results.ToArray() );
    }

    private int RollADie(int max) => Random.Range( 1, max + 1 );
}
