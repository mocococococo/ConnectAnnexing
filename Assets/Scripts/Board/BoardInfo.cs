using UnityEngine;

class BoardInfo : MonoBehaviour
{
    //ボードの大きさの定数
    public const int ROWS = 10;
    public const int COLS = 10;

    //マスを表す定数
    public const int OUT_BOARD = -1;
    public const int EMPTY = 0;
    public const int PLAYER_1 = 1;
    public const int PLAYER_2 = 2;
    public const int NEXT = 3;

    //ボードの2次元配列
    private int[,] board = new int[ROWS, COLS];

    //ボード情報を取得
    public int[,] Get_board() => board.Clone() as int[,];

    //指定列にコマをを挿入
    public bool Insert_disc(int col, int player)
    {
        //err処理
        if (col < 0 || col >= COLS || player < PLAYER_1 || player > PLAYER_2)
            return false;
        //列が埋まっているか確認
        if (board[ROWS - 1, col] != EMPTY)
            return false;
        //列にコマを置く
        for (int row = 0; row < ROWS; row++)
        {
            if (board[row, col] == EMPTY)
            {
                board[row, col] = player;
                return true;
            }
        }
        //return false;
    }

    //特定のマスのコマを取得
    public int Get_cell(int row, int col)
    {
        if (row < 0 || row >= ROWS || col < 0 || col >= COLS)
            return OUT_BOARD;
        return board[row, col];
    }

    //ボードの初期化
    public void init_board()
    {
        board = new int[ROWS, COLS];
    }
}
