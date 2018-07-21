using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Display : MonoBehaviour {

    private static float score = 0;
    public static float Score
    {
        get { return score; }
        set { score = value; }
    }

    [SerializeField]
    private Text ScoreText;

    [Header("Events")]
    [SerializeField]
    private UnityEvent OnScore;

    public void DisplayScore()
    {
        ScoreText.text = Score.ToString();
        OnScore.Invoke();
    }
}
