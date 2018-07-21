using UnityEngine;

public class DechetsScore : MonoBehaviour
{
    [Range(0, 5)]
    public float PointScore = 1;

    public void AddScore()
    {
        Display.Score = PointScore;
    }
}
