using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public static class Day4
    {
        public static int Star1(string[] input, string[][] boards)
        {
            var boardList = ExtractBoards(boards);
            for (int i = 0; i < input.Length; i++)
            {
                foreach (var board in boardList)
                {
                    MarkNumber(input, i, board);

                    for (int j = 0; j < 5; j++)
                    {
                        if (IsWin(board, j))
                        {
                            return CalculateScore(input, i, board);
                        }
                    }
                }
            }
            return 0;
        }

        public static int Star2(string[] input, string[][] boards)
        {
            var boardList = ExtractBoards(boards);
            var winCount = 0;
            var winns = new HashSet<int>();
            for (int i = 0; i < input.Length; i++)
            {
                for (var b = 0; b < boardList.Count; b++)
                {
                    var board = boardList[b];
                    MarkNumber(input, i, board);

                    for (int j = 0; j < 5; j++)
                    {
                        if (!winns.Contains(b) && IsWin(board, j))
                        {
                            winns.Add(b);
                            winCount++;
                        }
                        if (winCount == boardList.Count)
                        {
                            return CalculateScore(input, i, board);
                        }
                    }
                }
            }
            return 0;
        }

        private static bool IsWin((string, bool)[,] board, int j)
        {
            return (board[j, 0].Item2 &&
                                        board[j, 1].Item2 &&
                                        board[j, 2].Item2 &&
                                        board[j, 3].Item2 &&
                                        board[j, 4].Item2) ||
                                        (board[0, j].Item2 &&
                                        board[1, j].Item2 &&
                                        board[2, j].Item2 &&
                                        board[3, j].Item2 &&
                                        board[4, j].Item2);
        }
        private static void MarkNumber(string[] input, int i, (string, bool)[,] board)
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (board[x, y].Item1 == input[i])
                    {
                        board[x, y] = (input[i], true);
                    }
                }
            }
        }

        private static int CalculateScore(string[] input, int i, (string, bool)[,] board)
        {
            var sum = 0;
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (!board[x, y].Item2)
                    {
                        sum += int.Parse(board[x, y].Item1);
                    }
                }
            }
            return sum * int.Parse(input[i]);
        }

        private static List<(string, bool)[,]> ExtractBoards(string[][] boards)
        {
            var currentBoard = new (string, bool)[5, 5];
            var boardList = new List<(string, bool)[,]>();
            var y = 0;
            for (int i = 0; i < boards.Length; i++)
            {
                if (boards[i].Length == 0)
                {
                    boardList.Add(currentBoard);
                    currentBoard = new (string, bool)[5, 5];
                    y = 0;
                    continue;
                }
                for (int j = 0; j < 5; j++)
                {
                    currentBoard[y, j] = (boards[i][j], false);
                }
                y++;
            }
            boardList.Add(currentBoard);
            return boardList;
        }
    }
}
