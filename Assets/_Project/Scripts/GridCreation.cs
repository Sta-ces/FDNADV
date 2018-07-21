using UnityEngine;

public class GridCreation : MonoBehaviour {

    [Header("Prefabs")]
    [SerializeField]
    private GameObject Wall;
    [SerializeField]
    private GameObject SpawnBlocks;

    [Header("Grids")]
    [Range(1, 50)]
    public int gridWidth = 10;
    [Range(1, 50)]
    public int gridHeight = 10;

    private void OnEnable()
    {
        if (Wall != null)
        {
            for (int w = -gridWidth; w <= gridWidth; w++)
            {
                for (int h = -gridHeight; h <= gridHeight; h++)
                {
                    GameObject _wall = Instantiate(Wall, new Vector3(w, h, 0), Quaternion.identity);
                    _wall.transform.parent = transform;
                }
            }
        }

        if (SpawnBlocks != null)
        {
            float x = transform.position.x + 0.5f;
            float y = transform.position.y + gridHeight + 0.5f;
            float z = 0;
            Instantiate(SpawnBlocks, new Vector3(x, y, z), Quaternion.identity);
        }

        Camera.main.orthographicSize = gridHeight + 0.5f;
    }
}
