using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridCreation))]
public class CheckVoisins : MonoBehaviour {

    [Header("Only Layers to Detect")]
    [SerializeField]
    private LayerMask LayerToDetect;

    public void CheckVoisin()
    {
        GridCreation grid = GetComponent<GridCreation>();
        List<Collider2D> points = new List<Collider2D>();

        int h = -grid.gridHeight;
        while(h <= grid.gridHeight)
        {
            points.Clear();
            for(int w = -grid.gridWidth; w <= grid.gridWidth; w++)
            {
                Collider2D point = Physics2D.OverlapPoint(new Vector2(w, h), LayerToDetect);
                if (point != null) points.Add(point);
            }
            h++;
            if(points.Count > grid.gridWidth * 2)
            {
                print("Remove ligne "+h);
                foreach(Collider2D p in points)
                {
                    if(p.transform.parent.GetComponent<DechetsScore>())
                        p.transform.parent.GetComponent<DechetsScore>().AddScore(true);

                    Destroy(p.gameObject);
                }
                MoveAllPieces(h, grid, LayerToDetect);
                h = -grid.gridHeight;
            }
        }
    }

    public static void MoveAllPieces(int _row, GridCreation _grid, LayerMask _layer)
    {
        for(int h = _row; h <= _grid.gridHeight; h++)
        {
            for(int w = -_grid.gridWidth; w <= _grid.gridWidth; w++)
            {
                Collider2D point = Physics2D.OverlapPoint(new Vector2(w, h), _layer);
                if (point != null)
                    point.transform.position = new Vector2(point.transform.position.x, point.transform.position.y - 1);
            }
        }
    }
}
