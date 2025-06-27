using UnityEngine;

public class Idol : MonoRole
{
    public int winPoints = 3;
    public string roleName = "アイドル";

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
        int mycount = 0;
        int opocount = 0;
        int highest = 0;
        int my = BoardInfo.GetCell(x, y);
        //各列の頂点にある記号をカウント
        for (int x = 0; x < 10; x++)
        {
            if (Boardinfo.GetCell(x, BoardInfo.GetCell(x, 10) == my){
                mycount++;
            }
            else
            {
                opocount++;
            }
        }
        if (mycount > opocount)
        {
            return true;
        }
        return false;
    }
}