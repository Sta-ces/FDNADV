using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectBottom : MonoBehaviour
{
    [System.Serializable]
    public struct Detectors
    {
        public Transform[] RaysBottom;
        public Transform[] RaysRight;
        public Transform[] RaysLeft;
    }
    [Header("Detectors")]
    [SerializeField]
    private Detectors Rays;
    [Tooltip("Only Layers to detect")]
    [SerializeField]
    private LayerMask LayerToDetect;

    [Header("Events")]
    [SerializeField]
    private UnityEvent OnCollide;
    [SerializeField]
    private UnityEvent OnNearest;

    [HideInInspector]
    public bool CollideBottom = false;
    [HideInInspector]
    public bool CollideRight = false;
    [HideInInspector]
    public bool CollideLeft = false;


    void Update () {
        if (!CollideBottom)
        {
            if(Rays.RaysBottom.Length > 0)
            {
                foreach (Transform ray in Rays.RaysBottom)
                {
                    RaycastHit2D hit = Physics2D.Raycast(ray.position, Vector3.down, Mathf.Infinity, LayerToDetect);
                    if (hit.collider != null && hit.distance < 1f)
                    {
                        CollideBottom = true;
                        print("Collide");
                        OnCollide.Invoke();
                    }
                    if(hit.distance >= 1f && hit.distance <= 2f)
                    {
                        OnNearest.Invoke();
                    }
                }
            }
            CollideRight = RaysSides(Rays.RaysRight, Vector3.right);
            CollideLeft = RaysSides(Rays.RaysLeft, Vector3.left);
        }
	}

    bool RaysSides(Transform[] _rays, Vector3 _side)
    {
        List<bool> allDetector = new List<bool>();

        if (_rays.Length > 0)
        {
            foreach (Transform ray in _rays)
            {
                RaycastHit2D hit = Physics2D.Raycast(ray.position, _side, 1, LayerToDetect);
                allDetector.Add(hit.collider != null);
            }
        }

        return allDetector.Contains(true);
    }
}
