using UnityEngine;

// 勝ち屋の役職情報クラス
class Winner : MonoRole
{
    public int winPoints = 2;

    protected override void Start()
    {
        // 役職の初期化
        Debug.Log("Role initialized: " + roleName);
    }

    public override void WinningCondition()
    {
        
    }
}