using System;
using System.Text;

namespace _8Queens
{
    class Program
    {
        static char[,] board = new char[,]
        {
            {'*', '*','*', '*', '*','*','*','*' },
            {'*', '*','*', '*', '*','*','*','*' },
            {'*', '*','*', '*', '*','*','*','*' },
            {'*', '*','*', '*', '*','*','*','*' },
            {'*', '*','*', '*', '*','*','*','*' },
            {'*', '*','*', '*', '*','*','*','*' },
            {'*', '*','*', '*', '*','*','*','*' },
            {'*', '*','*', '*', '*','*','*','*' }
        };
        static int count = 0;

        static void Main(string[] args)
        {
            PutQueens();
        }

        static void PutQueens(int row = 0)
        {
            if(row == 8)
            {
                PrintSolution();
            }
            else
            {
                for(int col = 0; col < 8; col++)
                {
                    if(CanPlaceQueen(row, col))
                    {
                        MarkQueen(row, col);
                        PutQueens(row + 1);
                        UnmarkQueen(row, col);
                    }
                }
            }
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            for(int i = 0; i < 8; i++)
            {
                if(board[row, i] == 'Q' || board[i, col] == 'Q')
                {
                    return false;
                }
            }

            for(int i = row, j = col; i < 8 && j < 8; i++, j++)
            {
                if(board[i, j] == 'Q')
                {
                    return false;
                }
            }

            for(int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if(board[i, j] == 'Q')
                {
                    return false;
                }
            }

            for(int i = row, j = col; i >= 0 && j < 8; i--, j++)
            {
                if(board[i, j] == 'Q')
                {
                    return false;
                }
            }

            for(int i = row, j = col; i < 8 && j >= 0; i++, j--)
            {
                if(board[i, j] == 'Q')
                {
                    return false;
                }
            }

            return true;
        }

        private static void UnmarkQueen(int row, int col)
        {
            board[row, col] = '*';
        }

        private static void MarkQueen(int row, int col)
        {
            board[row, col] = 'Q';
        }

        private static void PrintSolution()
        {
            StringBuilder sb = new StringBuilder(64);
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++)
                {
                    sb.Append(board[i, j] + " ");
                }

                sb.AppendLine();
            }
            
            count++;
            sb.AppendLine(count.ToString());

            Console.WriteLine(sb.ToString());
        }
    }
}
