using UnityEngine;
using UnityEngine.Events;

public class DetectBottom : MonoBehaviour
{    
    [Header("When Collide")]
    [SerializeField]
    private UnityEvent OnCollide;


    private static bool collideBottom = false;
    public static bool CollideBottom
    {
        get { return collideBottom; }
    }
	
	void Update () {
        Debug.DrawRay(transform.position, Vector3.down * 5, Color.green);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            if(hit.distance < 1)
            {
                print("Collide");
                OnCollide.Invoke();
            }
        }
	}
}
