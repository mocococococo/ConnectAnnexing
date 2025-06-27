using UnityEngine;

class Thunder : MonoRole
{
    public int winPoints = 6;
    public string roleName = "—‹—l";

    protected override void Start()
    {
        // –ğE‚Ì‰Šú‰»
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
        //ÅŒã‚É’u‚¢‚½—ñ‚ÅlŒÂ•À‚Ñ¬—§
        if (prelast_x == x)
        {
            return true;
        }
        return false;
    }
}