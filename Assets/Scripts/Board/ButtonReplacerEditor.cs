#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;
using UnityEngine;

public class ButtonReplacer : MonoBehaviour
{
    [Header("Prefab をアサイン")]
    public GameObject buttonPrefab;

    [Header("ボタンがぶら下がっている親 (Board)")]
    public Transform boardRoot;

#if UNITY_EDITOR
    [ContextMenu("🚀 Replace Buttons with Prefab (Safe)")]
    private void ReplaceSafely()
    {
        if (buttonPrefab == null || boardRoot == null)
        {
            Debug.LogError("buttonPrefab または boardRoot が設定されていません");
            return;
        }

        // 1️⃣ 置き換え対象を先にリスト化
        var targets = new List<Transform>();
        foreach (Transform child in boardRoot)
        {
            if (child.name.StartsWith("button_"))
                targets.Add(child);
        }

        // Undo 用
        Undo.RegisterFullObjectHierarchyUndo(boardRoot.gameObject, "Replace Buttons");

        int count = 0;
        for (int i = 0; i < targets.Count; i++)
        {
            var old = targets[i];

            // 2️⃣ Prefab を元の siblingIndex に挿入
            var inst = (GameObject)PrefabUtility.InstantiatePrefab(buttonPrefab, boardRoot);
            inst.transform.SetPositionAndRotation(old.position, old.rotation);
            inst.transform.localScale = old.localScale;
            inst.name = old.name;                       // 名前維持
            inst.transform.SetSiblingIndex(old.GetSiblingIndex());

            // 3️⃣ 旧オブジェクトを削除
            Undo.DestroyObjectImmediate(old.gameObject);

            count++;
        }

        Debug.Log($"{count} 個のボタンを置き換えました（Safe モード）");
    }
#endif
}
