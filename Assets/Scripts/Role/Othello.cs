using UnityEngine;

class  : MonoRole
{
    public int winPoints = 5;
    public string roleName = "オセロ";

    protected override void Start()
    {
        // 役職の初期化
        Debug.Log("Role initialized: " + roleName);
    }

    public override bool WinningConditionMyTurn()
    {
        int x = BoardInfo.GetLastX();
        int y = BoardInfo.GetLastY();
        int my = BoardInfo.GetCell(x, y);
        int opo = BoardInfo.GetCell(BoardInfo.GetPreLastX(), BoardInfo.GetPreLastY());
        //横
        //左
        if (x < 6 &&
            BoardInfo.GetCell(x + 1, y) == opo &&
            BoardInfo.GetCell(x + 2, y) == opo &&
            BoardInfo.GetCell(x + 3, y) == opo &&
            BoardInfo.GetCell(x + 4, y) == my)
            return true;
        //右
        if (x > 3 &&
            BoardInfo.GetCell(x - 1, y) == opo &&
            BoardInfo.GetCell(x - 2, y) == opo &&
            BoardInfo.GetCell(x - 3, y) == opo &&
            BoardInfo.GetCell(x - 4, y) == my)
            return true;
        //縦
        if (y > 3 &&
            BoardInfo.GetCell(x, y - 1) == opo &&
            BoardInfo.GetCell(x, y - 2) == opo &&
            BoardInfo.GetCell(x, y -3) == opo &&
            BoardInfo.GetCell(x, y - 4) == my)
            return true;
        //スラッシュ
        //右上
        if (x < 6 && y < 6 &&
            BoardInfo.GetCell(x - 1, y - 1) == opo &&
            BoardInfo.GetCell(x - 2, y - 2) == opo &&
            BoardInfo.GetCell(x - 3, y - 3) == opo &&
            BoardInfo.GetCell(x - 4, y - 4) == my)
            return true;
        //左下
        if (x > 3 && y > 3 &&
            BoardInfo.GetCell(x + 1, y + 1) == opo &&
            BoardInfo.GetCell(x + 2, y + 2) == opo &&
            BoardInfo.GetCell(x + 3, y + 3) == opo &&
            BoardInfo.GetCell(x + 4, y + 4) == my)
            return true;
        //バックスラッシュ
        //右下
        if (x > 3 && y < 6 &&
            BoardInfo.GetCell(x - 1, y + 1) == opo &&
            BoardInfo.GetCell(x - 2, y + 2) == opo &&
            BoardInfo.GetCell(x - 3, y + 3) == opo &&
            BoardInfo.GetCell(x - 4, y + 4) == my)
            return true;
        //左上
        if (x < 6 && y > 3 &&
            BoardInfo.GetCell(x + 1, y - 1) == opo &&
            BoardInfo.GetCell(x + 2, y - 2) == opo &&
            BoardInfo.GetCell(x + 3, y - 3) == opo &&
            BoardInfo.GetCell(x + 4, y - 4) == my)
            return true;
        return false;
    }

    public override bool WinningConditionOpoTurn()
    {
        int x = BoardInfo.GetLastX();
        int y = BoardInfo.GetLastY();
        int opo = BoardInfo.GetCell(x, y);
        int my = BoardInfo.GetCell(BoardInfo.GetPreLastX(), BoardInfo.GetPreLastY());
        // 横
        if (x >= 3 && x <= 8)
            if (my == BoardInfo.GetCell(x + 1, y) &&
                opo == BoardInfo.GetCell(x - 1, y) &&
                opo == BoardInfo.GetCell(x - 2, y) &&
                my == BoardInfo.GetCell(x - 3, y))
                return true;
        if (x >= 2 && x <= 7)
            if (my == BoardInfo.GetCell(x + 2, y) &&
                opo == BoardInfo.GetCell(x + 1, y) &&
                opo == BoardInfo.GetCell(x - 1, y) &&
                my == BoardInfo.GetCell(x - 2, y))
                return true;
        if (x >= 1 && x <= 6)
            if (my == BoardInfo.GetCell(x + 3, y) &&
                opo == BoardInfo.GetCell(x + 2, y) &&
                opo == BoardInfo.GetCell(x + 1, y) &&
                my == BoardInfo.GetCell(x - 1, y))
                return true;
        // スラッシュ
        if (x >= 3 && x <= 8 && y >= 3 && y <= 8)
            if (my == BoardInfo.GetCell(x + 1, y + 1) &&
                opo == BoardInfo.GetCell(x - 1, y - 1) &&
                opo == BoardInfo.GetCell(x - 2, y - 2) &&
                my == BoardInfo.GetCell(x - 3, y - 3))
                return true;
        if (x >= 2 && x <= 7 && y >= 2 && y <= 7)
            if (my == BoardInfo.GetCell(x + 2, y + 2) &&
                opo == BoardInfo.GetCell(x + 1, y + 1) &&
                opo == BoardInfo.GetCell(x - 1, y - 1) &&
                my == BoardInfo.GetCell(x - 2, y - 2))
                return true;
        if (x >= 1 && x <= 6 && y >= 1 && y <= 6)
            if (my == BoardInfo.GetCell(x + 3, y + 3) &&
                opo == BoardInfo.GetCell(x + 2, y + 2) &&
                opo == BoardInfo.GetCell(x + 1, y + 1) &&
                my == BoardInfo.GetCell(x - 1, y - 1))
                return true;
        // バックスラッシュ
        if (x >= 3 && x <= 8 && y >= 1 && y <= 6)
            if (my == BoardInfo.GetCell(x + 1, y - 1) &&
                opo == BoardInfo.GetCell(x - 1, y + 1) &&
                opo == BoardInfo.GetCell(x - 2, y + 2) &&
                my == BoardInfo.GetCell(x - 3, y + 3))
                return true;
        if (x >= 2 && x <= 7 && y >= 2 && y <= 7)
            if (my == BoardInfo.GetCell(x + 2, y - 2) &&
                opo == BoardInfo.GetCell(x + 1, y - 1) &&
                opo == BoardInfo.GetCell(x - 1, y + 1) &&
                my == BoardInfo.GetCell(x - 2, y + 2))
                return true;
        if (x >= 1 && x <= 6 && y >= 3 && y <= 8)
            if (my == BoardInfo.GetCell(x + 3, y - 3) &&
                opo == BoardInfo.GetCell(x + 2, y - 2) &&
                opo == BoardInfo.GetCell(x + 1, y - 1) &&
                my == BoardInfo.GetCell(x - 1, y + 1))
                return true;
        return false;
    }
}