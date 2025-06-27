using UnityEngine;

public class Wind : MonoRole
{
    public int winPoints = 7;
    public string roleName = "風神";

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
            return CheckCondition(y);
        }
        return false;
    }

    public bool CheckCondition(int y)
    {
        int prelast_y = BoardInfo.GetPreLastY();
        //最後に置いた行で四個並び成立
        if (prelast_y == y)
        {
            return true;
        }
        return false;
    }
}