using UnityEngine;

public abstract class MonoRole : MonoBehaviour
{
    [Header("役割名")]
    public string roleName;
    [Header("勝利ポイント")]
    [SerializeField] private int winPoints;
    
    protected virtual void Start()
    {
        // 役職の初期化
        Debug.Log("Role initialized: " + name);
    }

    public int WinPoints
    {
        get { return winPoints; }
        set { winPoints = value; }
    }

    public abstract bool WinningConditionMyTurn()
    {
        return false;
    }

    public abstract bool WinningConditionOpoTurn()
    {
        return false;
    }

    public abstract int CountNewConnect4(int x, int y)
    {
        int num = 0;
        int val = BoardInfo.GetCell(x, y); // 現在のマスの値（プレイヤー番号など）

        // ▼ 縦方向
        if (y >= 3)
        {
            if (val == BoardInfo.GetCell(x, y - 1) &&
                val == BoardInfo.GetCell(x, y - 2) &&
                val == BoardInfo.GetCell(x, y - 3))
                num++;
        }

        // ▼ 横方向
        if (x >= 3)
        {
            if (val == BoardInfo.GetCell(x - 1, y) &&
                val == BoardInfo.GetCell(x - 2, y) &&
                val == BoardInfo.GetCell(x - 3, y))
                num++;
        }
        if (x >= 2 && x <= 8)
        {
            if (val == BoardInfo.GetCell(x + 1, y) &&
                val == BoardInfo.GetCell(x - 1, y) &&
                val == BoardInfo.GetCell(x - 2, y))
                num++;
        }
        if (x >= 1 && x <= 7)
        {
            if (val == BoardInfo.GetCell(x + 2, y) &&
                val == BoardInfo.GetCell(x + 1, y) &&
                val == BoardInfo.GetCell(x - 1, y))
                num++;
        }
        if (x <= 6)
        {
            if (val == BoardInfo.GetCell(x + 3, y) &&
                val == BoardInfo.GetCell(x + 2, y) &&
                val == BoardInfo.GetCell(x + 1, y))
                num++;
        }

        // ▼ スラッシュ方向（左上 → 右下）
        if (x >= 3 && y >= 3)
        {
            if (val == BoardInfo.GetCell(x - 1, y - 1) &&
                val == BoardInfo.GetCell(x - 2, y - 2) &&
                val == BoardInfo.GetCell(x - 3, y - 3))
                num++;
        }
        if (x >= 2 && x <= 8 && y >= 2 && y <= 8)
        {
            if (val == BoardInfo.GetCell(x + 1, y + 1) &&
                val == BoardInfo.GetCell(x - 1, y - 1) &&
                val == BoardInfo.GetCell(x - 2, y - 2))
                num++;
        }
        if (x >= 1 && x <= 7 && y >= 1 && y <= 7)
        {
            if (val == BoardInfo.GetCell(x + 2, y + 2) &&
                val == BoardInfo.GetCell(x + 1, y + 1) &&
                val == BoardInfo.GetCell(x - 1, y - 1))
                num++;
        }
        if (x <= 6 && y <= 6)
        {
            if (val == BoardInfo.GetCell(x + 3, y + 3) &&
                val == BoardInfo.GetCell(x + 2, y + 2) &&
                val == BoardInfo.GetCell(x + 1, y + 1))
                num++;
        }

        // ▼ バックスラッシュ方向（右上 → 左下）
        if (x >= 3 && y <= 6)
        {
            if (val == BoardInfo.GetCell(x - 1, y + 1) &&
                val == BoardInfo.GetCell(x - 2, y + 2) &&
                val == BoardInfo.GetCell(x - 3, y + 3))
                num++;
        }
        if (x >= 2 && x <= 8 && y >= 1 && y <= 7)
        {
            if (val == BoardInfo.GetCell(x + 1, y - 1) &&
                val == BoardInfo.GetCell(x - 1, y + 1) &&
                val == BoardInfo.GetCell(x - 2, y + 2))
                num++;
        }
        if (x >= 1 && x <= 7 && y >= 2 && y <= 8)
        {
            if (val == BoardInfo.GetCell(x + 2, y - 2) &&
                val == BoardInfo.GetCell(x + 1, y - 1) &&
                val == BoardInfo.GetCell(x - 1, y + 1))
                num++;
        }
        if (x <= 6 && y >= 3)
        {
            if (val == BoardInfo.GetCell(x + 3, y - 3) &&
                val == BoardInfo.GetCell(x + 2, y - 2) &&
                val == BoardInfo.GetCell(x + 1, y - 1))
                num++;
        }

        return num;
    }

    public abstract int CountNewConnect3(int x, int y)
    {
        int num = 0;
        int val = BoardInfo.GetCell(x, y);

        // 縦
        if (y >= 2)
            if (val == BoardInfo.GetCell(x, y - 1) &&
                val == BoardInfo.GetCell(x, y - 2))
                num++;

        // 横
        if (x >= 2)
            if (val == BoardInfo.GetCell(x - 1, y) &&
                val == BoardInfo.GetCell(x - 2, y))
                num++;
        if (x >= 1 && x <= 8)
            if (val == BoardInfo.GetCell(x + 1, y) &&
                val == BoardInfo.GetCell(x - 1, y))
                num++;
        if (x <= 7)
            if (val == BoardInfo.GetCell(x + 2, y) &&
                val == BoardInfo.GetCell(x + 1, y))
                num++;

        // スラッシュ
        if (x >= 2 && y >= 2)
            if (val == BoardInfo.GetCell(x - 1, y - 1) &&
                val == BoardInfo.GetCell(x - 2, y - 2))
                num++;
        if (x >= 1 && x <= 8 && y >= 1 && y <= 8)
            if (val == BoardInfo.GetCell(x + 1, y + 1) &&
                val == BoardInfo.GetCell(x - 1, y - 1))
                num++;
        if (x <= 7 && y <= 7)
            if (val == BoardInfo.GetCell(x + 2, y + 2) &&
                val == BoardInfo.GetCell(x + 1, y + 1))
                num++;

        // バックスラッシュ
        if (x >= 2 && y <= 7)
            if (val == BoardInfo.GetCell(x - 1, y + 1) &&
                val == BoardInfo.GetCell(x - 2, y + 2))
                num++;
        if (x >= 1 && x <= 8 && y >= 1 && y <= 8)
            if (val == BoardInfo.GetCell(x + 1, y - 1) &&
                val == BoardInfo.GetCell(x - 1, y + 1))
                num++;
        if (x <= 7 && y >= 2)
            if (val == BoardInfo.GetCell(x + 2, y - 2) &&
                val == BoardInfo.GetCell(x + 1, y - 1))
                num++;

        return num;
    }

    public abstract int CountNewConnect5(int x, int y)
    {
        int num = 0;
        int val = BoardInfo.GetCell(x, y);

        // 縦
        if (y >= 4)
            if (val == BoardInfo.GetCell(x, y - 1) &&
                val == BoardInfo.GetCell(x, y - 2) &&
                val == BoardInfo.GetCell(x, y - 3) &&
                val == BoardInfo.GetCell(x, y - 4))
                num++;

        // 横
        if (x >= 4)
            if (val == BoardInfo.GetCell(x - 1, y) &&
                val == BoardInfo.GetCell(x - 2, y) &&
                val == BoardInfo.GetCell(x - 3, y) &&
                val == BoardInfo.GetCell(x - 4, y))
                num++;
        if (x >= 3 && x <= 8)
            if (val == BoardInfo.GetCell(x + 1, y) &&
                val == BoardInfo.GetCell(x - 1, y) &&
                val == BoardInfo.GetCell(x - 2, y) &&
                val == BoardInfo.GetCell(x - 3, y))
                num++;
        if (x >= 2 && x <= 7)
            if (val == BoardInfo.GetCell(x + 2, y) &&
                val == BoardInfo.GetCell(x + 1, y) &&
                val == BoardInfo.GetCell(x - 1, y) &&
                val == BoardInfo.GetCell(x - 2, y))
                num++;
        if (x >= 1 && x <= 6)
            if (val == BoardInfo.GetCell(x + 3, y) &&
                val == BoardInfo.GetCell(x + 2, y) &&
                val == BoardInfo.GetCell(x + 1, y) &&
                val == BoardInfo.GetCell(x - 1, y))
                num++;
        if (x <= 5)
            if (val == BoardInfo.GetCell(x + 4, y) &&
                val == BoardInfo.GetCell(x + 3, y) &&
                val == BoardInfo.GetCell(x + 2, y) &&
                val == BoardInfo.GetCell(x + 1, y))
                num++;

        // スラッシュ
        if (x >= 4 && y >= 4)
            if (val == BoardInfo.GetCell(x - 1, y - 1) &&
                val == BoardInfo.GetCell(x - 2, y - 2) &&
                val == BoardInfo.GetCell(x - 3, y - 3) &&
                val == BoardInfo.GetCell(x - 4, y - 4))
                num++;
        if (x >= 3 && x <= 8 && y >= 3 && y <= 8)
            if (val == BoardInfo.GetCell(x + 1, y + 1) &&
                val == BoardInfo.GetCell(x - 1, y - 1) &&
                val == BoardInfo.GetCell(x - 2, y - 2) &&
                val == BoardInfo.GetCell(x - 3, y - 3))
                num++;
        if (x >= 2 && x <= 7 && y >= 2 && y <= 7)
            if (val == BoardInfo.GetCell(x + 2, y + 2) &&
                val == BoardInfo.GetCell(x + 1, y + 1) &&
                val == BoardInfo.GetCell(x - 1, y - 1) &&
                val == BoardInfo.GetCell(x - 2, y - 2))
                num++;
        if (x >= 1 && x <= 6 && y >= 1 && y <= 6)
            if (val == BoardInfo.GetCell(x + 3, y + 3) &&
                val == BoardInfo.GetCell(x + 2, y + 2) &&
                val == BoardInfo.GetCell(x + 1, y + 1) &&
                val == BoardInfo.GetCell(x - 1, y - 1))
                num++;
        if (x <= 5 && y <= 5)
            if (val == BoardInfo.GetCell(x + 4, y + 4) &&
                val == BoardInfo.GetCell(x + 3, y + 3) &&
                val == BoardInfo.GetCell(x + 2, y + 2) &&
                val == BoardInfo.GetCell(x + 1, y + 1))
                num++;

        // バックスラッシュ
        if (x >= 4 && y <= 5)
            if (val == BoardInfo.GetCell(x - 1, y + 1) &&
                val == BoardInfo.GetCell(x - 2, y + 2) &&
                val == BoardInfo.GetCell(x - 3, y + 3) &&
                val == BoardInfo.GetCell(x - 4, y + 4))
                num++;
        if (x >= 3 && x <= 8 && y >= 1 && y <= 6)
            if (val == BoardInfo.GetCell(x + 1, y - 1) &&
                val == BoardInfo.GetCell(x - 1, y + 1) &&
                val == BoardInfo.GetCell(x - 2, y + 2) &&
                val == BoardInfo.GetCell(x - 3, y + 3))
                num++;
        if (x >= 2 && x <= 7 && y >= 2 && y <= 7)
            if (val == BoardInfo.GetCell(x + 2, y - 2) &&
                val == BoardInfo.GetCell(x + 1, y - 1) &&
                val == BoardInfo.GetCell(x - 1, y + 1) &&
                val == BoardInfo.GetCell(x - 2, y + 2))
                num++;
        if (x >= 1 && x <= 6 && y >= 3 && y <= 8)
            if (val == BoardInfo.GetCell(x + 3, y - 3) &&
                val == BoardInfo.GetCell(x + 2, y - 2) &&
                val == BoardInfo.GetCell(x + 1, y - 1) &&
                val == BoardInfo.GetCell(x - 1, y + 1))
                num++;
        if (x <= 5 && y <= 5)
            if (val == BoardInfo.GetCell(x + 4, y - 4) &&
                val == BoardInfo.GetCell(x + 3, y - 3) &&
                val == BoardInfo.GetCell(x + 2, y - 2) &&
                val == BoardInfo.GetCell(x + 1, y - 1))
                num++;

        return num;
    }
}