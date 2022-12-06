/************
 * Write a function that returns all distinct solutions to the 8-queens puzzle.
Each solution contains a distinct board configuration of the 8-queens' placement, where 'Q' and '.' both indicate a queen and an empty space respectively.
--------
Example solution for 4-queen puzzle
Output:

// Solution 1
.Q..  
...Q
Q...
..Q.


// Solution 2
..Q.
Q...
...Q
.Q..
************/

var s = new Solution();
var queens = 8; // 皇后數量
var result = s.SolveNQueens(queens);

// 印結果
foreach (var res in result)
{
    for (int y = 0; y < queens; y++)
    {
        for (int x = 0; x < queens; x++)
        {
            Console.Write(res[x][y]);
        }
        Console.WriteLine();
    }
    Console.WriteLine("======");
}

Console.WriteLine($"{queens}皇后，總共有 {result.Count} 組解");

public class Solution
{
    private int N;
    public List<List<string>> SolveNQueens(int queens)
    {
        N = queens;
        var res = new List<List<string>>();
        var board = new char[N][];
        for (int i = 0; i < N; i++)
        {
            board[i] = new char[N];
            Array.Fill(board[i], '.');
        }

        Helper(res, board, 0);
        return res;
    }

    private void Helper(List<List<string>> res, char[][] board, int y)
    {
        if (y == N)
        {
            var list = new List<string>();
            for (int i = 0; i < N; i++)
            {
                var s = new string(board[i]);
                list.Add(s);
            }
            res.Add(list);
            return;
        }

        for (int x = 0; x < N; x++)
        {
            if (!IsValid(board, x, y)) continue;

            board[x][y] = 'Q';
            Helper(res, board, y + 1);
            board[x][y] = '.';
        }
    }

    private bool IsValid(char[][] board, int x, int y)
    {
        // 向上搜 x 軸 
        for (int i = 0; i < y; i++)
            if (board[x][i] == 'Q') return false;

        // 向上搜 反斜率 軸 
        for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--)
            if (board[i][j] == 'Q') return false;

        // 向上搜 正斜率 軸
        for (int i = x + 1, j = y - 1; i < N && j >= 0; i++, j--)
        {
            if (board[i][j] == 'Q') return false;
        }

        return true;
    }
}