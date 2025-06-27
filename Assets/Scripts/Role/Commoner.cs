using UnityEngine;

class Commoner : MonoRole
{
    public int winPoints = 4;
    public string roleName = "平民";

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
        int lowest = 10;
        int my = BoardInfo.GetCell(x, y);
        //最も低い列にある記号をカウント
        for (int x = 0; x < 10; x++)
        {
            if (BoardInfo.GetCell(x, 10) < lowest && BoardInfo.GetCell(x, 10) != 0)
            {
                highest = BoardInfo.GetCell(x, 10);
                mycount = 0;
                opocount = 0;
            }
            if (BoardInfo.GetCell(x, 10) == lowest)
            {
                for (int y = 0; y <= highest; y++)
                {
                    if (Boardinfo.GetCell(x, y) == my)
                    {
                        mycount++;
                    }
                    else
                    {
                        opocount++;
                    }
                }
            }
        }
        if (mycount > opocount)
        {
            return true;
        }
        return false;
    }
}