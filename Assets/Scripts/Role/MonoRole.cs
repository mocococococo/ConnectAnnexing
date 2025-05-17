using UnityEngine;

public abstract class MonoRole : MonoBehaviour
{
    [Header("役割名")]
    public string roleName;
    [Header("勝利ポイント")]
    [SerializeField] private int winPoints;
    
    protected virtual void Start()
    {
        // 役職の初期化
        Debug.Log("Role initialized: " + name);
    }

    public int WinPoints
    {
        get { return winPoints; }
        set { winPoints = value; }
    }

    public abstract void WinningCondition();
}