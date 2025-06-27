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
        //上
        if (y < 6 &&
            BoardInfo.GetCell(x, y + 1) == opo &&
            BoardInfo.GetCell(x, y + 2) == opo &&
            BoardInfo.GetCell(x, y + 3) == opo &&
            BoardInfo.GetCell(x, y + 4) == my)
            return true;
        //下
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
        return base.WinningConditionOpuTurn();
    }
}