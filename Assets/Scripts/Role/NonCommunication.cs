using UnityEngine;

class NonCommunication : MonoRole
{
    public int winPoints = 3;
    public string roleName = "�R�~����";

    protected override void Start()
    {
        // ��E�̏�����
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
        //�����̑S�Ă̋L�����͂܂�Ă��Ȃ�
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                if (BoardInfo.GetCell(x, y) == my)
                {
                    //�l�����m�F
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