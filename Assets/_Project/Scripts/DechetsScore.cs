using UnityEngine;

public class DechetsScore : MonoBehaviour
{
    [Range(0, 50)]
    public float PointScore = 1;

    public void AddScore(bool _addLingot = false)
    {
        Display.Score += PointScore;
        if (_addLingot)
        {
            print("Lingot");
            Display.Lingot += PointScore;
        }
    }
}
