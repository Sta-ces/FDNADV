using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DechetControler : MonoBehaviour {

    [System.Serializable]
    public struct Limit
    {
        public float Left;
        public float Right;
    }
    [SerializeField]
    private Limit TrashLimit;
	
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
