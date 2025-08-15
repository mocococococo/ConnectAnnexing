using UnityEngine;

public class PlaymatManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int rows = 3;
    public int cols = 4;
    [SerializeField] private GameObject[] areaList;
    private GameObject[,] areas;
 // ★今どこを選択しているか（初期値を0,0にしている例）
    private int currentY = 0;
    private int currentX = 0;

    void Start()
    {
        InitAreas();
    }
    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HighlightCurrentArea();
    }
    //プレイマットの各種場所を配列で管理
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
   private void HandleInput()
    {
        int nextY = currentY;
        int nextX = currentX;

        // WASD/矢印キーで移動
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            nextY--;
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            nextY++;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            nextX--;
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            nextX++;

        // 範囲内かつnullでない場所まで移動
        if (IsValidArea(nextY, nextX))
        {
            currentY = nextY;
            currentX = nextX;
        }
    }

    private bool IsValidArea(int y, int x)
    {
        return y >= 0 && y < rows && x >= 0 && x < cols && areas[y, x] != null;
    }

    private void HighlightCurrentArea()
    {
        // 全エリアの色をリセット（例）
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                if (areas[y, x] != null)
                    areas[y, x].GetComponent<Renderer>().material.color = Color.white;
            }
        }
        // 選択中をハイライト
        if (areas[currentY, currentX] != null)
            areas[currentY, currentX].GetComponent<Renderer>().material.color = Color.yellow;
    }
}
