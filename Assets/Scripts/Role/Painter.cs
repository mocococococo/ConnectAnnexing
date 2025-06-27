using UnityEngine;

class Painter : MonoRole
{
    public int winPoints = 10;
    public string roleName = "�y�C���^�[";

    protected override void Start()
    {
        // ��E�̏�����
        Debug.Log("Role initialized: " + roleName);
    }

    public override bool WinningConditionMyTurn()
    {
        if (BoardInfo.Get_x_num() == 0)
        {
            return true;
        }
        return false;
    }

    public override bool WinningConditionOpoTurn()
    {
        if (BoardInfo.Get_x_num == 0)
        {
            return true;
        }
        return false;
    }
}