using UnityEngine;

class  : MonoRole
{
    public int winPoints = 5;
    public string roleName = "�I�Z��";

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
        //��
        //��
        if (x < 6 &&
            BoardInfo.GetCell(x + 1, y) == opo &&
            BoardInfo.GetCell(x + 2, y) == opo &&
            BoardInfo.GetCell(x + 3, y) == opo &&
            BoardInfo.GetCell(x + 4, y) == my)
            return true;
        //�E
        if (x > 3 &&
            BoardInfo.GetCell(x - 1, y) == opo &&
            BoardInfo.GetCell(x - 2, y) == opo &&
            BoardInfo.GetCell(x - 3, y) == opo &&
            BoardInfo.GetCell(x - 4, y) == my)
            return true;
        //�c
        //��
        if (y < 6 &&
            BoardInfo.GetCell(x, y + 1) == opo &&
            BoardInfo.GetCell(x, y + 2) == opo &&
            BoardInfo.GetCell(x, y + 3) == opo &&
            BoardInfo.GetCell(x, y + 4) == my)
            return true;
        //��
        if (y > 3 &&
            BoardInfo.GetCell(x, y - 1) == opo &&
            BoardInfo.GetCell(x, y - 2) == opo &&
            BoardInfo.GetCell(x, y -3) == opo &&
            BoardInfo.GetCell(x, y - 4) == my)
            return true;
        //�X���b�V��
        //�E��
        if (x < 6 && y < 6 &&
            BoardInfo.GetCell(x - 1, y - 1) == opo &&
            BoardInfo.GetCell(x - 2, y - 2) == opo &&
            BoardInfo.GetCell(x - 3, y - 3) == opo &&
            BoardInfo.GetCell(x - 4, y - 4) == my)
            return true;
        //����
        if (x > 3 && y > 3 &&
            BoardInfo.GetCell(x + 1, y + 1) == opo &&
            BoardInfo.GetCell(x + 2, y + 2) == opo &&
            BoardInfo.GetCell(x + 3, y + 3) == opo &&
            BoardInfo.GetCell(x + 4, y + 4) == my)
            return true;
        //�o�b�N�X���b�V��

        //�E��
        if (x > 3 && y < 6 &&
            BoardInfo.GetCell(x - 1, y + 1) == opo &&
            BoardInfo.GetCell(x - 2, y + 2) == opo &&
            BoardInfo.GetCell(x - 3, y + 3) == opo &&
            BoardInfo.GetCell(x - 4, y + 4) == my)
            return true;
        //����
        if (x < 6 && y > 3 &&
            BoardInfo.GetCell(x + 1, y - 1) == opo &&
            BoardInfo.GetCell(x + 2, y - 2) == opo &&
            BoardInfo.GetCell(x + 3, y - 3) == opo &&
            BoardInfo.GetCell(x + 4, y - 4) == my)
            return true;
        return false;
    }

    public override bool WinningConditionOpoTurn()
    {
        return base.WinningConditionOpuTurn();
    }
}