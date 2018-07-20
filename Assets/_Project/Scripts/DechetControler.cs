using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DechetControler : MonoBehaviour {

    [Header("Chute")]
    [Range(0.1f, 5f)]
    public float SecondChute = 1;
    public static bool StopChute = false;
    public void Stopped(bool _stop) { StopChute = _stop; }

    [System.Serializable]
    public struct Limit
    {
        public float Left;
        public float Right;
    }
    [Header("Limit")]
    [SerializeField]
    private Limit TrashLimit;

    [Header("Events")]
    [SerializeField]
    private UnityEvent OnAppear;
    [SerializeField]
    private UnityEvent OnBlocked;


    IEnumerator Start()
    {
        while (!StopChute)
        {
            Vector3 pos = transform.position;
            yield return new WaitForSeconds(SecondChute);
            if (!StopChute)
            {
                pos.y -= 1;
                transform.position = pos;
            }
        }
    }

    void FixedUpdate () {
        MoveDechet();
	}

    void MoveDechet()
    {
        Vector3 pos = transform.position;

        pos.x += Controls.GetHorizontal;

        pos.x = Mathf.Clamp( pos.x, TrashLimit.Left, TrashLimit.Right );

        transform.position = pos;
    }
}
