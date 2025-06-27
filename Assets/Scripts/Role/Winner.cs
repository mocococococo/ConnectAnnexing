using UnityEngine;

// 勝ち屋の役職情報クラス
class Winner : MonoRole
{
    public int winPoints = 2;
    public string roleName = "勝ち屋";

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
            return true;
        }
        return false;
    }

    public override bool WinningConditionOpoTurn()
    {
        return base.WinningConditionOpoTurn();
    }
}