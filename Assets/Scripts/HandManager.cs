using UnityEngine;
using System.Collections.Generic;

public class HandManager : MonoBehaviour
{
    [Header("手札を並べる基準オブジェクト (HandArea)")]
    public Transform handArea;

    [Header("手札にあるカード一覧")]
    public List<GameObject> handCards = new List<GameObject>();

    [Header("扇形の並び調整")]
    public float spacing = 2f;      // カードの横間隔
    public float curve = 10f;       // 扇形の傾き（Z回転）
    public float height = -3f;      // 手札の高さ

    [Header("手札を向けるカメラ")]
    public Transform targetCamera;   // タグなしカメラ用

    void Start()
    {
        if (handArea == null)
        {
            Debug.LogError(" handArea が設定されていません！");
            return;
        }

        if (targetCamera == null)
        {
            Debug.LogWarning(" targetCamera が設定されていません。カードは回転しません。");
        }

        UpdateHandLayout();
    }

    // 手札を扇形に並べる
    public void UpdateHandLayout()
    {
        int count = handCards.Count;
        if (count == 0)
        {
            Debug.Log(" 手札が空です");
            return;
        }

        float centerIndex = (count - 1) / 2f;
        Debug.Log($"手札の並び替え開始: カード数 {count}, centerIndex {centerIndex}");

        for (int i = 0; i < count; i++)
        {
            if (handCards[i] == null)
            {
                Debug.Log($" handCards[{i}] が null です");
                continue;
            }

            float offset = (i - centerIndex) * spacing;
            Vector3 pos = new Vector3(0, height, offset);

            handCards[i].transform.SetParent(handArea, false);
            handCards[i].transform.localPosition = pos;

            // カメラを参照して向ける
            if (targetCamera != null)
            {
                handCards[i].transform.LookAt(targetCamera);
                handCards[i].transform.Rotate(0, 90, 90); // イラスト面が前になるように調整

            }

            // 扇形っぽく Z 回転
            handCards[i].transform.Rotate(0, 0, /*(i - centerIndex) * curve*/0);

            Debug.Log($" handCards[{i}] {handCards[i].name} を配置: pos={pos}");
        }

        Debug.Log("手札の並び替え完了");
    }

    // 手札にカードを追加
    public void AddCard(GameObject card)
    {
        if (card == null) return;

        card.transform.SetParent(handArea, false);
        handCards.Add(card);
        UpdateHandLayout();
    }

    // 手札からカードを削除
    public void RemoveCard(GameObject card)
    {
        if (card == null) return;

        handCards.Remove(card);
        Destroy(card);
        UpdateHandLayout();
    }
}
