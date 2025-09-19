using System.Collections.Generic;
using UnityEngine;

public class PlaymatManager : MonoBehaviour
{
    // 方向定義
    enum Direction { Up, Left, Down, Right }

    // エリア数
    private const int AreaCount = 12;

    // 遷移表（エリアごとにUp/Left/Down/Rightの移動先インデックス）
    private readonly int?[,] moveTable = new int?[,]
    {
        //    ↑      ←      ↓      →
        {   9,     2,     7,     1  }, // 0: OpponentBonusArrayDisplay
        {  10,     0,     4,     2  }, // 1: OpponentCardSetArea
        {   8,     1,     5,     0  }, // 2: OpponentTrashArea
        { null,  null,  null,  null }, // 3: Null
        {   1,     7,    10,     5  }, // 4: ConnectFourBoard
        {   2,     4,     6,     0  }, // 5: OpponentScoreDisplay
        {   5,     4,     8,     7  }, // 6: DeckDisplay
        {   0,     6,     9,     4  }, // 7: PlayerScoreDisplay
        {   6,     4,    2,     9  }, // 8: PlayerBonusArrayDisplay
        {   7,     8,     0,    10 }, // 9: PlayerTrashArea
        {   4,     9,     1,     8 }, //10: PlayerCardSetArea
        { null,  null,  null,  null }  //11: Null
    };

    [SerializeField] private GameObject[] areaList;
    private int currentIndex = 0;

    void Update()
    {
        int? nextIndex = null;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            nextIndex = moveTable[currentIndex, (int)Direction.Up];
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            nextIndex = moveTable[currentIndex, (int)Direction.Left];
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            nextIndex = moveTable[currentIndex, (int)Direction.Down];
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            nextIndex = moveTable[currentIndex, (int)Direction.Right];

        if (nextIndex.HasValue && areaList[nextIndex.Value] != null)
        {
            currentIndex = nextIndex.Value;
            HighlightCurrentArea();
        }
    }

    private void HighlightCurrentArea()
    {
        for (int i = 0; i < areaList.Length; i++)
        {
            if (areaList[i] == null) continue;
            var renderer = areaList[i].GetComponent<Renderer>();
            if (renderer != null)
                renderer.material.color = (i == currentIndex) ? Color.white : Color.black;
        }
    }
}