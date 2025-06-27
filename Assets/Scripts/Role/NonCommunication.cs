using UnityEngine;

class NonCommunication : MonoRole
{
    public int winPoints = 3;
    public string roleName = "コミュ障";

    protected override void Start()
    {
        // 役職の初期化
        Debug.Log("Role initialized: " + roleName);
    }

    public override bool WinningConditionMyTurn()
    {
        int x = BoardInfo.GetLastX();
        int y = BoardInfo.GetLastY();
        if (base.CountNewConnect4(x, y) > 0)
        {
            return CheckCondition(x, y);
        }
        return false;
    }

    public override bool WinningConditionOpoTurn()
    {
        return base.WinningConditionOpuTurn();
    }

    public bool CheckCondition(int x, int y)
    {
        int prelast_x = BoardInfo.GetPreLastX();
        int prelast_y = BoardInfo.GetPreLastY();
        int my = BoardInfo.GetCell(lastx, lasty);
        int opo = BoardInfo.GetCell(prelast_x, prelast_y);
        //自分の全ての記号が囲まれていない
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                if (BoardInfo.GetCell(x, y) == my)
                {
                    //四方を確認
                    if (x > 0 && opo == BoardInfo.GetCell(x - 1, y) &&
                        x < 9 && opo == BoardInfo.GetCell(x + 1, y &&
                        y > 0 && opo == BoardInfo.GetCell(x, y - 1) &&
                        x < 9 && opo == BoardInfo.GetCell(x, y + 1))
                        return false;
                }
            }
        }
        return true;
    }
}