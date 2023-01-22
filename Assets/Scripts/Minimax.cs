using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimax : MonoBehaviour
{
    // Start is called before the first frame update
    public (int, int) MinimaxAlg(int mainScore, int secondScore, int randomValue, bool maximizingPlayer, int depth)
    {
        if (depth == 0) return (0, mainScore);
        var bestDecision = 0;
        var bestScore = int.MinValue;
        if (maximizingPlayer)
        {
            var newSecondScore = secondScore + randomValue;
            int newBestScore = Math.Max(bestScore, MinimaxAlg(
                mainScore + (newSecondScore % 13 == 0 ? newSecondScore / 13 : 0),
                newSecondScore, randomValue, false, depth -1).Item2);
            if (newBestScore > bestScore)
            {
                bestScore = newBestScore;
                bestDecision = 1;
            }
            
            newSecondScore = secondScore - randomValue;
            newBestScore = Math.Max(bestScore, MinimaxAlg(
                mainScore + (newSecondScore % 13 == 0 ? newSecondScore / 13 : 0),
                newSecondScore, randomValue, false, depth - 1).Item2);
            if (newBestScore > bestScore)
            {
                bestScore = newBestScore;
                bestDecision = 2;
            }

            for (int i = 2; i < 5; i++)
            {
                newSecondScore = secondScore + randomValue * i;
                newBestScore = Math.Max(bestScore, MinimaxAlg(
                    mainScore + (newSecondScore % 13 == 0 ? newSecondScore / 13 : 0),
                    newSecondScore, randomValue, false, depth - 1).Item2);
                if (newBestScore > bestScore)
                {
                    bestScore = newBestScore;
                    bestDecision = i + 1;
                }
            }
            
            for (int i = 2; i < 5; i++)
            {
                newSecondScore = secondScore + randomValue / i;
                newBestScore = Math.Max(bestScore, MinimaxAlg(
                    mainScore + (newSecondScore % 13 == 0 ? newSecondScore / 13 : 0),
                    newSecondScore, randomValue, false, depth - 1 ).Item2);
                if (newBestScore > bestScore)
                {
                    bestScore = newBestScore;
                    bestDecision = i + 4;
                }
            }


        }else
        {
            for (int i = 3; i < 14; i++)
            {
                bestScore = MinimaxAlg(mainScore, secondScore, i, true, depth).Item2;
            }
        }
        return (bestDecision, bestScore);
    }
}
