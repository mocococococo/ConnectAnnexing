using UnityEngine;

class Thunder : MonoRole
{
    public int winPoints = 6;
    public string roleName = "���l";

    protected override void Start()
    {
        // ��E�̏�����
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
        if (base.CountNewConnect4(x, y) > 0)
        {
            return CheckCondition(x);
        }
        return false;
    }

    public bool CheckCondition(int x)
    {
        int prelast_x = BoardInfo.GetPreLastX();
        //�Ō�ɒu������Ŏl���ѐ���
        if (prelast_x == x)
        {
            return true;
        }
        return false;
    }
}