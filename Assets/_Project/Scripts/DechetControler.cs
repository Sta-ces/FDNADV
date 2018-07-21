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
    
    private bool downInput = true;
    public void DownInput(bool _input) { downInput = _input; }

    [Header("Events")]
    [SerializeField]
    private UnityEvent OnAppear;
    [SerializeField]
    private UnityEvent OnStopped;



    private Vector3 pos = Vector3.zero;
    private GridCreation grid;
    private DetectBottom detect;


    void Awake()
    {
        grid = FindObjectOfType<GridCreation>();
        detect = FindObjectOfType<DetectBottom>();
    }

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
        MoveDechet();

        if(stopChute)
        {
            FindObjectOfType<SpawnBox>().SpawnNewBox();
            FindObjectOfType<CheckVoisins>().CheckVoisin();
            OnStopped.Invoke();
        }

        if (!stopChute && transform.position.y == -grid.gridHeight - 0.5f) stopChute = true;
        if (!detect.CollideBottom && transform.position.y <= -grid.gridHeight + 2) downInput = false;
	}

    void MoveDechet()
    {
        pos = transform.position;
        
        if (!detect.CollideRight) pos.x += Controls.RightInput;
        if (!detect.CollideLeft) pos.x += Controls.LeftInput;
        if (downInput) pos.y += Controls.DownInput;
        
        pos.x = Mathf.Clamp( pos.x, -grid.gridWidth + 1.5f, grid.gridWidth + 0.5f );

        transform.position = pos;
    }
}
