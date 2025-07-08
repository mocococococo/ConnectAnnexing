#define DEBUG_INPUT

using UnityEngine;
using UnityEngine.InputSystem;   // 新 Input System 用

/// <summary>
/// 十字キー（Move）で 2D グリッド上を移動し
/// Submit キーで現在ボタンのアニメーションを発火させるマネージャ
/// </summary>
public class BoardSelector : MonoBehaviour
{
    [Header("Board Size")]
    [SerializeField] int width  = 10;   // 列数
    [SerializeField] int height = 10;   // 行数

    [Header("ボタン一覧 (Inspector で 100 個放り込むか、FindObjectsOfType でも可)")]
    [SerializeField] BoardButton[] buttonList;

    [Header("Input (新 Input System)")]
    [SerializeField] InputActionReference moveAction;   // Vector2
    [SerializeField] InputActionReference submitAction; // Button

    [Header("キーリピート設定")]
    [SerializeField] float firstDelay  = 0.15f; // 押し始めの遅延
    [SerializeField] float repeatDelay = 0.02f; // 連打間隔

    /* ─────────────────────────────────────────── */

    BoardButton[,] grid;              // [row,col] でアクセス
    Vector2Int current = Vector2Int.zero;
    float nextMoveTime;                // Move を次に受け付ける時刻
    bool firstHeldFrame;               // 初回かどうか判定

    void Awake()
        {
        /* === ボタンを自動収集しグリッドを構成 ============================ */
        grid = new BoardButton[height, width];
        buttonList = FindObjectsByType<BoardButton>(FindObjectsSortMode.None);

        foreach (var b in buttonList)
        {
            var nameParts = b.name.Split('_');
            if (nameParts.Length == 2 && int.TryParse(nameParts[1], out int n))
            {
                n -= 1;                    // 001→0, 002→1 …
                b.row = n / width;         // 0–9 が row, 10–19 が row=1 …（行優先）
                b.col = n % width;         // 0–9 が col
            }
            
            if (b.row < 0 || b.row >= height || b.col < 0 || b.col >= width)
            {
                Debug.LogError($"{b.name} の row/col が範囲外 ({b.row},{b.col})");
                continue;
            }
            // 同じマスに二重登録していないかチェック
            if (grid[b.row, b.col] != null)
            {
                Debug.LogError($"({b.row},{b.col}) が重複しています → {b.name}");
                continue;
            }
            grid[b.row, b.col] = b;
        }

        /* === 入力バインド & 最初のハイライト ============================== */
        moveAction.action.performed   += OnMove;
        moveAction.action.canceled    += _ => firstHeldFrame = true;
        submitAction.action.performed += OnSubmit;

        moveAction.action.Enable();
        submitAction.action.Enable();

        HighlightCurrent(true);
        firstHeldFrame = true;
    }

    void OnDestroy()
    {
        moveAction.action.performed   -= OnMove;
        moveAction.action.canceled    -= _ => firstHeldFrame = true;
        submitAction.action.performed -= OnSubmit;
    }

    /* ──────────── 入力処理 ──────────── */

    void OnMove(InputAction.CallbackContext ctx)
    {
        #if DEBUG_INPUT
            Debug.Log($"Move={ctx.ReadValue<Vector2>()}  phase={ctx.phase}");
        #endif
        // キーリピート制御
        if (Time.time < nextMoveTime) return;

        Vector2 v = ctx.ReadValue<Vector2>();
        int dc = Mathf.RoundToInt(v.y);  // +1=右, -1=左
        int dr = Mathf.RoundToInt(v.x);  // +1=上, -1=下

        if (dr == 0 && dc == 0) return;

        /* ハイライト切替 */
        HighlightCurrent(false);

        // Up を行マイナス方向に合わせるため dc と dr の符号に注意
        current.x = (current.x + dr + height) % height; // 行 (row)
        current.y = (current.y - dc + width)  % width;  // 列 (col)

        HighlightCurrent(true);

        /* 次に Move を許可する時刻を更新 */
        nextMoveTime = Time.time + (firstHeldFrame ? firstDelay : repeatDelay);
        firstHeldFrame = false;
    }

    void OnSubmit(InputAction.CallbackContext ctx)
    {
#if DEBUG_INPUT
        Debug.Log("Submit performed");
#endif
        if (!ctx.performed) return;
        grid[current.x, current.y].Press();
        grid[current.x, current.y].Decide();
    }

    /* ──────────── 補助メソッド ──────────── */

    void HighlightCurrent(bool on)
    {
        BoardButton btn = grid[current.x, current.y];
        if (btn != null) btn.Highlight(on);

        if (on)
            Debug.Log($"現在選択中：縦から {current.x + 1} 番目、横から {current.y + 1} 番目");
    }
}
