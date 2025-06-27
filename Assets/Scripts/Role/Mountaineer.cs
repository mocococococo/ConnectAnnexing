using UnityEngine;

class Mountaineer : MonoRole
{
    public int winPoints = 3;
    public string roleName = "登山家";

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

    public bool CheckCondition(x,y)
    {
        int mycount = 0;
        int opocount = 0;
        int highest = 0;
        int my = BoardInfo.GetCell(x, y);
        //最も高い列にある記号をカウント
        for (int x = 0; x < 10; x++)
        {
            if (BoardInfo.GetCell(x, 10) > highest)
            {
                highest = BoardInfo.GetCell(x, 10);
                mycount = 0;
                opocount = 0;
            }
            if (BoardInfo.GetCell(x,10) == highest)
            {
                for (int y = 0; y <= highest; y++)
                {
                    if (Boardinfo.GetCell(x,y) == my)
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