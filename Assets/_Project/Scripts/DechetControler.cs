using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DechetControler : MonoBehaviour {

    [Header("Chute")]
    [Range(0.1f, 5f)]
    public float SecondChute = 1;
    [Range(0, 2)]
    public float DistanceChute = 1;

    private bool stopChute = false;
    public void StopChute(bool _stop) { stopChute = _stop; }

    [System.Serializable]
    public struct Limit
    {
        public float Left;
        public float Right;
    }
    [Header("Limit")]
    [SerializeField]
    private bool IsLimit = true;
    [SerializeField]
    private Limit TrashLimit;

    [Header("Events")]
    [SerializeField]
    private UnityEvent OnAppear;
    [SerializeField]
    private UnityEvent OnBlocked;



    private Vector3 pos = Vector3.zero;


    IEnumerator Start()
    {
        pos = transform.position;

        while (!stopChute)
        {
            yield return new WaitForSeconds(SecondChute);
            if (!stopChute)
            {
                pos.y -= DistanceChute;
                transform.position = pos;
            }
        }
    }

    void FixedUpdate () {
        if(!stopChute) MoveDechet();
	}

    void MoveDechet()
    {
        pos = transform.position;

        pos.x += Controls.GetHorizontal;

        if (IsLimit)
            pos.x = Mathf.Clamp( pos.x, TrashLimit.Left, TrashLimit.Right );

        transform.position = pos;
    }
}
