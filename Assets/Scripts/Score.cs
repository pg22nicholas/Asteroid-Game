using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score 
{
    private static int s_score;

    public static Action<int> OnScoreAdded;

    public static void AddScore(int score)
    {
        s_score += score;
        Debug.Log($"Score is now: {s_score}");
        OnScoreAdded?.Invoke(s_score);
    }

    public static void ResetScore()
    {
        s_score = 0;
    }
}
