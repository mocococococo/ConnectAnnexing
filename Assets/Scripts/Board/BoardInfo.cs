using UnityEngine;

class BoardInfo : MonoBehaviour
{
    //ボードの大きさの定数
    public const int X = 10;
    public const int Y = 11;

    //マスを表す定数
    public const int OUT_BOARD = 104;    //ボードの範囲外
    public const int EMPTY = 100;         //空のマス
    public const int PLAYER_1 = 101;      //プレイヤ１のコマ
    public const int PLAYER_2 = 102;      //プレイヤ２のコマ
    public const int NEXT = 103;          //置くことのできるマス

    //ボードの2次元配列
    private int[,] board = new int[X, Y];

    //直前に置いたマスの座標
    private int lastX = OUT_BOARD;
    private int lastY = OUT_BOARD;

    //２個前に置いたマスの座標
    private int prelastX = OUT_BOARD;
    private int prelastY = OUT_BOARD;

    //コマを置くことのできる列の数を管理
    private int x_num = X;


    //ボードの初期化
    public void init_board()
    {
        board = new int[X, Y];
        for (int x = 0; x < X; x++)
        {
            //次に置ける場所の設定
            board[x, 0] = NEXT;
            //最後に置いた高さの設定
            board[x, Y - 1] = -1; 
        }
        //他のマスを空のマスにする
        for (int x = 0; x < X; x++)
        {
            for (int y = 1; y < Y - 1; y++)
            {
                board[x, y] = EMPTY;
            }
        }
        //直前に置いたマスの座標
        lastX = OUT_BOARD;
        lastY = OUT_BOARD;
        //２個前に置いたマスの座標
        prelastX = OUT_BOARD;
        prelastY = OUT_BOARD;
        //コマを置くことのできる列の数
        x_num = X;
    }

    //ボード情報を取得
    public int[,] Get_board() => board.Clone() as int[,];

    //特定のマスの状態を取得
    public int GetCell(int x, int y)
    {
        if (x < 0 || x >= X || y < 0 || y >= Y)
            return OUT_BOARD;
        return board[x, y];
    }

    //直前に置いたマスの座標を取得
    public int GetLastX() => lastX.Clone() as int;
    public int GetLastY() => lastY.Clone() as int;

    //２個前に置いたマスの座標を取得
    public int GetPreLastX() => prelastX.Clone() as int;
    public int GetPreLastY() => prelastY.Clone() as int;

    //コマを置くことのできる列の数を取得
    public int Get_x_num() => x_num.Clone() as int;

    //指定列にコマをを挿入*
    public bool Insert_disc(int row, int col, int player)
    {
        //err処理
        if (row < 0 || row >= ROWS || col < 0 || col >= COLS || player < 1 || player > 2 || board[row, col] != 3)
            return false;
        //コマを置く
        board[row, col] = player;
        //次に置ける場所を更新
        if (row != ROWS - 1)
            board[row + 1, col] = NEXT;
        //コマを置くことのできる列の数を減らす。
        else
            col_num -= 1;
        return true;
    }

    

    
}
