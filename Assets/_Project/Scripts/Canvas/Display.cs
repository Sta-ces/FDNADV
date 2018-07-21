using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Display : MonoBehaviour {

    private static int allLingots = 0;
    public static int AllLingots
    {
        get { return allLingots; }
        private set { allLingots = value; }
    }

    private static float score = 0;
    public static float Score
    {
        get { return score; }
        set { score = value; }
    }

    private static float lingot = 0;
    public static float Lingot
    {
        get { return lingot; }
        set {
            lingot = value;
            if (lingot >= 300)
            {
                lingot = 0;
                AllLingots++;
            }
        }
    }

    [Header("UI")]
    [SerializeField]
    private Text ScoreText;
    [SerializeField]
    private Image LingotImage;

    [Header("Events")]
    [SerializeField]
    private UnityEvent OnScore;

    public void DisplayScore()
    {
        OnScore.Invoke();
    }


    private void LateUpdate()
    {
        if (ScoreText != null) ScoreText.text = Score.ToString();
        if (LingotImage != null) LingotImage.fillAmount = Lingot / 100;
    }
}
