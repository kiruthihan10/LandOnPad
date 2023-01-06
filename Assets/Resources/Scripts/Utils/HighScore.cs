using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class HighScore {

    private const string key = "hiScores";
    private int[] scores;

    public HighScore() {
        scores = getHighScores();
    }

    public void updateHighScore(int[] highScores = null) {
        if (highScores == null) {
            highScores = scores;
        }
        highScores = sortHighScores(highScores);
        PlayerPrefs.SetString(key, string.Join(",",highScores));
        scores = highScores;
    }

    private int[] sortHighScores(int[] highScores) {
        Array.Sort(highScores);
        Array.Reverse(highScores);
        return highScores;
    }


    public static int[] getHighScores() {
        if(PlayerPrefs.HasKey(key)) {
            string[] higscoresStr = PlayerPrefs.GetString(key).Split(',');
            return Array.ConvertAll(higscoresStr, s => int.Parse(s));
        }
        else {
            return new int[5];
        }
    }

    public void addScore(int score) {
        if (scores.Length == 0) {
            scores[0] = score;
        } else if (scores.Length < 5) {
            scores[scores.Length] = score;
        } else {
            if (scores[4] < score) {
                scores[4] = score;
            }
        }
        updateHighScore();
    }
}