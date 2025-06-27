using UnityEngine;

class Prostalker : MonoRole
{
    public int winPoints = 4;
    public string roleName = "ストーカー常習犯";
    public int count = 0;

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
        count += base.CountNewConnect3(x, y);
        if (count > 2)
        {
            return CheckCondition(x,y);
        }
        return false;
    }

    public bool CheckCondition(int lastx, int lasty)
    {
        int prelast_x = BoardInfo.GetPreLastX();
        int prelast_y = BoardInfo.GetPreLastY();
        int my = BoardInfo.GetCell(lastx, lasty);
        int opo = BoardInfo.GetCell(prelast_x, prelast_y);
        //相手の全ての記号に隣接
        for (int x = 0; x< 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                if (BoardInfo.GetCell(x,y) == opo)
                {
                    bool touch = false;
                    //四方を確認
                    if (x > 0 && my == BoardInfo.GetCell(x - 1, y))
                        {
                            touch = true;
                        }
                    }
                    if (x < 9 && my == BoardInfo.GetCell(x + 1, y))
                        {
                            touch = true;
                        }
                    }
                    if (y > 0 && my == BoardInfo.GetCell(x, y - 1))
                        {
                            touch = true;
                        }
                    }
                    if (x < 9 && my == BoardInfo.GetCell(x, y + 1))
                        {
                            touch = true;
                        }
                    }
                    if (!touch)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
}