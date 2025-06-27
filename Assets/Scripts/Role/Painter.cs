using UnityEngine;

class Painter : MonoRole
{
    public int winPoints = 10;
    public string roleName = "ペインター";

    protected override void Start()
    {
        // 役職の初期化
        Debug.Log("Role initialized: " + roleName);
    }

    public override bool WinningConditionMyTurn()
    {
        if (BoardInfo.Get_x_num() == 0)
        {
            return true;
        }
        return false;
    }

    public override bool WinningConditionOpoTurn()
    {
        if (BoardInfo.Get_x_num == 0)
        {
            return true;
        }
        return false;
    }
}