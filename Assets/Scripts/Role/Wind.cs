using UnityEngine;

public class Wind : MonoRole
{
    public int winPoints = 7;
    public string roleName = "���_";

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
            return CheckCondition(y);
        }
        return false;
    }

    public bool CheckCondition(int y)
    {
        int prelast_y = BoardInfo.GetPreLastY();
        //�Ō�ɒu�����s�Ŏl���ѐ���
        if (prelast_y == y)
        {
            return true;
        }
        return false;
    }
}