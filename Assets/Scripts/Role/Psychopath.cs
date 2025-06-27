using UnityEngine;

class Psychopath : MonoRole
{
    public int winPoints = 7;
    public string roleName = "サイコパス";

    protected override void Start()
    {
        // 役職の初期化
        Debug.Log("Role initialized: " + roleName);
    }

    public override bool WinningConditionMyTurn()
    {
        return base.WinningConditionMyTurn();
    }

    public override bool WinningConditionOpoTurn()
    {
        int x = BoardInfo.GetLastX();
        int y = BoardInfo.GetLastY();
        if (base.CountNewConnect4(x, y) > 0)
        {
            return CheckCondition(x,y);
        }
        return false;
    }

    public bool CheckCondition(int x, int y)
    {
        int prelast_x = BoardInfo.GetPreLastX();
        int prelast_y = BoardInfo.GetPreLastY();
        //最後に置いた周りで四個並び成立
        if (prelast_y == y)
        {
            if (x == prelast_x - 1 || x == prelast_x + 1)
            {
                return true;
            }
        }
        if (prelast_x == x && prelast_y == y + 1)
        {
            return true;
        }
        return false;
    }
}