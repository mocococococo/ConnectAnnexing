using UnityEngine;

public class BoardButton : MonoBehaviour
{
    public int row, col;
    public Animator anim;

    static readonly int layerDefault  = 0;   // 必要に応じて変更
    static readonly int layerDecided  = 7;   // 「Decided」物理レイヤー ID
    static readonly int layerOutline  = 8;   // 「Outline」物理レイヤー ID

    bool decided = false; // 決定済みかどうか
    public void Highlight(bool on)
    {
        int target = on ? layerOutline
                        : decided ? layerDecided
                                : layerDefault;               // 決定済みなら戻す先を layerDecided に
        SetLayerRecursively(transform, target);
    }

    // 子孫を含めてレイヤーを全部変える
    void SetLayerRecursively(Transform t, int layer)
    {
        t.gameObject.layer = layer;
        foreach (Transform c in t)
            SetLayerRecursively(c, layer);
    }

    public void Decide()
    {
        decided = true;                                          // 決定状態にする
        SetLayerRecursively(transform, layerDecided);
    }

    public void Press() => anim.SetTrigger("Press");
}

