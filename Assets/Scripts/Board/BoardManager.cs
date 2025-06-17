using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ・Start 時に子階層から ButtonController を自動収集  
/// ・Enter キー (Return) でランダムに 1 つ押す
/// </summary>
public class BoardManager : MonoBehaviour
{
    [Tooltip("自動収集させたくない場合はここで手動登録しても OK")]
    [SerializeField] private List<ButtonController> buttons = new();

    private void Start()
    {
        // まだリストが空なら子階層から自動取得
        if (buttons.Count == 0)
        {
            buttons.AddRange(GetComponentsInChildren<ButtonController>());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))        // ← Enter キー
        {
            if (buttons.Count == 0) return;

            int index = Random.Range(0, buttons.Count);
            buttons[index].Toggle();
        }
    }
}
