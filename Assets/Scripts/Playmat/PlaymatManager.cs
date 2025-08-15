using UnityEngine;

public class PlaymatManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int rows = 3;
    public int cols = 4;
    [SerializeField] private GameObject[] areaList;
    private GameObject[,] areas;

    void Start()
    {
        InitAreas();
    }

    private void InitAreas()
    {
        areas = new GameObject[rows, cols];
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                areas[y, x] = areaList[y * cols + x];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
