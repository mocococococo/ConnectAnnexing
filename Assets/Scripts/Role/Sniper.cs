using UnityEngine;

class Sniper : MonoRole
{
    public int winPoints = 4;
    public string roleName = "�X�i�C�p�[";
    public int count = 0;

    protected override void Start()
    {
        // ��E�̏�����
        Debug.Log("Role initialized: " + roleName);
    }

    public override bool WinningConditionMyTurn()
    {
        int x = BoardInfo.GetLastX();
        int y = BoardInfo.GetLastY();
        int my = BoardInfo.GetCell(x, y);
        int opo = BoardInfo.GetCell(BoardInfo.GetPreLastX(), BoardInfo.GetPreLastY());
        // 1. �E���画��
        if (x > 1 && y > 0 && y < 9)
        {
            if (opo == BoardInfo.GetCell(x - 1, y) &&
                my == BoardInfo.GetCell(x - 1, y - 1) &&
                my == BoardInfo.GetCell(x - 1, y + 1) &&
                my == BoardInfo.GetCell(x - 2, y))
            {
                count++;
            }
        }
        // 2. �ォ�画��
        if (y > 1 && x > 0 && x < 9)
        {
            if (opo == BoardInfo.GetCell(x, y - 1) &&
                my == BoardInfo.GetCell(x - 1, y - 1) &&
                my == BoardInfo.GetCell(x + 1, y - 1) &&
                my == BoardInfo.GetCell(x, y - 2))
            {
                count++;
            }
        }
        // 3. �����画��
        if (x < 8 && y > 0 && y < 9)
        {
            if (opo == BoardInfo.GetCell(x + 1, y) &&
                my == BoardInfo.GetCell(x + 1, y - 1) &&
                my == BoardInfo.GetCell(x + 1, y + 1) &&
                my == BoardInfo.GetCell(x + 2, y))
            {
                count++;
            }
        }
        // 
        if (count >= 3) return true;
        return false;
    }

    public override bool WinningConditionOpoTurn()
    {
        return base.WinningConditionOpoTurn();
    }
}