using UnityEngine;

class Christians : MonoRole
{
    public int winPoints =5;
    public string roleName = "�L���V�^��";

    protected override void Start()
    {
        // ��E�̏�����
        Debug.Log("Role initialized: " + roleName);
    }

    public override bool WinningConditionMyTurn()
    {
        int x = BoardInfo.GetLastX();
        int y = BoardInfo.GetLastY();
        int val = BoardInfo.GetCell(x, y);
        // 1. �E���画��
        if (x > 1 && y > 0 && y < 9)
        {
            if (val == BoardInfo.GetCell(x - 1, y) &&
                val == BoardInfo.GetCell(x - 1, y - 1) &&
                val == BoardInfo.GetCell(x - 1, y + 1) &&
                val == BoardInfo.GetCell(x - 2, y))
            {
                return true;
            }
        }
        // 2. �ォ�画��
        if (y > 1 && x > 0 && x < 9)
        {
            if (val == BoardInfo.GetCell(x, y - 1) &&
                val == BoardInfo.GetCell(x - 1, y - 1) &&
                val == BoardInfo.GetCell(x + 1, y - 1) &&
                val == BoardInfo.GetCell(x, y - 2))
            {
                return true;
            }
        }
        // 3. �����画��
        if (x < 8 && y > 0 && y < 9)
        {
            if (val == BoardInfo.GetCell(x + 1, y) &&
                val == BoardInfo.GetCell(x + 1, y - 1) &&
                val == BoardInfo.GetCell(x + 1, y + 1) &&
                val == BoardInfo.GetCell(x + 2, y))
            {
                return true;
            }
        }
        // �Y�����Ȃ��ꍇ
        return false;
    }

    public override bool WinningConditionOpoTurn()
    {
        return base.WinningConditionOpoTurn();
    }
}