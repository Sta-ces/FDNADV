using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class DetectBottom : MonoBehaviour
{
    [System.Serializable]
    public struct Detectors
    {
        public Transform Left;
        public Transform Right;
    }
    [Header("Detectors")]
    [SerializeField]
    private Detectors Rays;

    [Header("When Collide")]
    [SerializeField]
    private UnityEvent OnCollide;

    private bool collideBottom = false;

	
	void Update () {
        if (!collideBottom)
        {
            if(Rays.Left != null && Rays.Right != null)
            {
                RaycastHit left;
                RaycastHit right;
                bool rayLeft = Physics.Raycast(Rays.Left.position, Vector3.down, out left, Mathf.Infinity);
                bool rayRight = Physics.Raycast(Rays.Right.position, Vector3.down, out right, Mathf.Infinity);
                if (rayLeft || rayRight)
                {
                    if (left.distance < 1f || right.distance < 1f)
                    {
                        collideBottom = true;
                        print("Collide: "+collideBottom);
                        OnCollide.Invoke();
                    }
                }
            }
        }
	}
}
