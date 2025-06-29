using UnityEngine;

class SurpriseBox : MonoRole
{
    public int winPoints = 3;
    public string roleName = "�т����蔠";
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
        //�I�̃J�E���g
        //��
        if (x <= 6 &&
            BoardInfo.GetCell(x + 1, y) == opo &&
            BoardInfo.GetCell(x + 2, y) == my &&
            BoardInfo.GetCell(x + 3, y) == my)
            count++;
        if (x <= 6 &&
            BoardInfo.GetCell(x + 1, y) == my &&
            BoardInfo.GetCell(x + 2, y) == opo &&
            BoardInfo.GetCell(x + 3, y) == my)
            count++;
        if (x <= 7 && x >= 1 &&
            BoardInfo.GetCell(x - 1, y) == my &&
            BoardInfo.GetCell(x + 1, y) == opo &&
            BoardInfo.GetCell(x + 2, y) == my)
            count++;
        if (x <= 8 && x >= 2
            BoardInfo.GetCell(x - 2, y) == my &&
            BoardInfo.GetCell(x - 1, y) == opo &&
            BoardInfo.GetCell(x + 1, y) == my)
            count++;
        if (x >= 3 &&
            BoardInfo.GetCell(x - 1, y) == opo &&
            BoardInfo.GetCell(x - 2, y) == my &&
            BoardInfo.GetCell(x - 3, y) == my)
            count++;
        if (x >= 3 &&
            BoardInfo.GetCell(x - 1, y) == my &&
            BoardInfo.GetCell(x - 2, y) == opo &&
            BoardInfo.GetCell(x - 3, y) == my)
            count++;
        //�c
        if (y >= 3 &&
            BoardInfo.GetCell(x, y - 1) == opo &&
            BoardInfo.GetCell(x, y - 2) == my &&
            BoardInfo.GetCell(x, y - 3) == my)
            count++;
        if (y >= 3 &&
            BoardInfo.GetCell(x, y - 1) == my &&
            BoardInfo.GetCell(x, y - 2) == opo &&
            BoardInfo.GetCell(x, y - 3) == my)
            count++;
        //�X���b�V��
        if (x >= 3 && y >= 3 &&
            BoardInfo.GetCell(x - 1, y - 1) == opo &&
            BoardInfo.GetCell(x - 2, y - 2) == my &&
            BoardInfo.GetCell(x - 3, y - 3) == my)
            count++;
        if (x >= 3 && y >= 3 &&
            BoardInfo.GetCell(x - 1, y - 1) == my &&
            BoardInfo.GetCell(x - 2, y - 2) == opo &&
            BoardInfo.GetCell(x - 3, y - 3) == my)
            count++;
        if (x >= 2 && y >= 2 && x <= 8 && y <= 8 &&
            BoardInfo.GetCell(x + 1, y + 1) == my &&
            BoardInfo.GetCell(x - 1, y - 1) == opo &&
            BoardInfo.GetCell(x - 2, y - 2) == my)
            count++;
        if (x >= 2 && y >= 2 && x <= 8 && y <= 8 &&
            BoardInfo.GetCell(x + 2, y + 2) == my &&
            BoardInfo.GetCell(x + 1, y + 1) == opo &&
            BoardInfo.GetCell(x - 1, y - 1) == my)
            count++;
        if (x <= 6 && y <= 6 &&
            BoardInfo.GetCell(x + 1, y + 1) == opo &&
            BoardInfo.GetCell(x + 2, y + 2) == my &&
            BoardInfo.GetCell(x + 3, y + 3) == my)
            count++;
        if (x <= 6 && y <= 6 &&
            BoardInfo.GetCell(x + 1, y + 1) == my &&
            BoardInfo.GetCell(x + 2, y + 2) == opo &&
            BoardInfo.GetCell(x + 3, y + 3) == my)
            count++;
        //�o�b�N�X���b�V��
        if (x >= 3 && y <= 6 &&
            BoardInfo.GetCell(x - 1, y + 1) == opo &&
            BoardInfo.GetCell(x - 2, y + 2) == my &&
            BoardInfo.GetCell(x - 3, y + 3) == my)
            count++;
        if (x >= 3 && y <= 6 &&
            BoardInfo.GetCell(x - 1, y + 1) == my &&
            BoardInfo.GetCell(x - 2, y + 2) == opo &&
            BoardInfo.GetCell(x - 3, y + 3) == my)
            count++;
        if (x >= 2 && y <= 7 && x <= 8 && y >= 1 &&
            BoardInfo.GetCell(x + 1, y - 1) == my &&
            BoardInfo.GetCell(x - 1, y + 1) == opo &&
            BoardInfo.GetCell(x - 2, y + 2) == my)
            count++;
        if (x >= 1 && y <= 8 && x <= 7 && y >= 2 &&
            BoardInfo.GetCell(x + 2, y - 2) == my &&
            BoardInfo.GetCell(x + 1, y - 1) == opo &&
            BoardInfo.GetCell(x - 1, y + 1) == my)
            count++;
        if (x <= 6 && y => 3 &&
            BoardInfo.GetCell(x + 1, y - 1) == opo &&
            BoardInfo.GetCell(x + 2, y - 2) == my &&
            BoardInfo.GetCell(x + 3, y - 3) == my)
            count++;
        if (x <= 6 && y => 3 &&
            BoardInfo.GetCell(x + 1, y - 1) == my &&
            BoardInfo.GetCell(x + 2, y - 2) == opo &&
            BoardInfo.GetCell(x + 3, y - 3) == my)
            count++;
        if (count >= 3) return true;
        return false;
    }

    public override bool WinningConditionOpoTurn()
    {
        int x = BoardInfo.GetLastX();
        int y = BoardInfo.GetLastY();
        int opo = BoardInfo.GetCell(x, y);
        int my = BoardInfo.GetCell(BoardInfo.GetPreLastX(), BoardInfo.GetPreLastY());
        // ��
        if (x >= 1 && x <= 7 &&
            my == BoardInfo.GetCell(x + 2, y) &&
            my == BoardInfo.GetCell(x + 1, y) &&
            my == BoardInfo.GetCell(x - 1, y))
            count++;
        if (x >= 2 && x <= 8 &&
            my == BoardInfo.GetCell(x + 1, y) &&
            my == BoardInfo.GetCell(x - 1, y) &&
            my == BoardInfo.GetCell(x - 2, y))
            count++;
        // �X���b�V��
        if (x >= 2 && x <= 8 && y >= 2 && y <= 8 &&
            my == BoardInfo.GetCell(x + 1, y + 1) &&
            my == BoardInfo.GetCell(x - 1, y - 1) &&
            my == BoardInfo.GetCell(x - 2, y - 2))
            count++;
        if (x >= 1 && x <= 7 && y >= 1 && y <= 7 &&
            my == BoardInfo.GetCell(x + 2, y + 2) &&
            my == BoardInfo.GetCell(x + 1, y + 1) &&
            my == BoardInfo.GetCell(x - 1, y - 1))
            count++;
        // �o�b�N�X���b�V��
        if (x >= 2 && x <= 8 && y >= 1 && y <= 7 &&
            my == BoardInfo.GetCell(x + 1, y - 1) &&
            my == BoardInfo.GetCell(x - 1, y + 1) &&
            my == BoardInfo.GetCell(x - 2, y + 2))
            count++;
        if (x >= 1 && x <= 7 && y >= 2 && y <= 8 &&
            my == BoardInfo.GetCell(x + 2, y - 2) &&
            my == BoardInfo.GetCell(x + 1, y - 1) &&
            my == BoardInfo.GetCell(x - 1, y + 1))
            count++;
        if (count >= 3) return true;
        return false;
    }
}