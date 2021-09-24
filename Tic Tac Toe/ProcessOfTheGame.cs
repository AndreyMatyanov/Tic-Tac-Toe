using System;
using static Tic_Tac_Toe.ScoreAndWinner;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    public static class ProcessOfTheGame
    {
        public static void GameStart(Options options)
        {
            char[,] board = new char[options.N, options.N];
            FillBoard(ref board);
            for (int steps = 0; steps < (options.N * options.N); steps++)
            {
                ShowBoard(board);
                if (options.FirstPlayersIsStart is true && steps % 2 == 0)
                {
                    FirstPlayerSteps(ref board, options.PaintOfTheFirstPlayer);
                }
                else if (options.FirstPlayersIsStart is true && steps % 2 != 0)
                {
                    if (options.TwoPlayers is false)
                    {
                        BotSteps(ref board, options.PaintOfTheSecondPlayer);
                    }
                    else
                    {
                        SecondPlayerSteps(ref board, options.PaintOfTheSecondPlayer);
                    }
                }
                else if (options.FirstPlayersIsStart is false && steps % 2 == 0)
                {
                    if (options.TwoPlayers is false)
                    {
                        BotSteps(ref board, options.PaintOfTheSecondPlayer);
                    }
                    else
                    {
                        SecondPlayerSteps(ref board, options.PaintOfTheSecondPlayer);
                    }
                }
                else
                {
                    FirstPlayerSteps(ref board, options.PaintOfTheFirstPlayer);
                }
                Console.Clear();
            }
            Score(board, options);
        }

        private static void FirstPlayerSteps(ref char[,] board, char paint)
        {
            Console.WriteLine("Ход игрока 1.\nВведите позицию по длине:");
            int y = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("Введите позицию по высоте");
            int x = Convert.ToInt32(Console.ReadLine()) - 1;
            if (board[x, y] != 'X' && board[x, y] != 'O')
            {
                board[x, y] = paint;
            }
            else
            {
                throw new ArgumentException("На этой позиции уже поставлен значок.");
            }

        }

        static void SecondPlayerSteps(ref char[,] board, char paint)
        {
            Console.WriteLine("Ход игрока 2.\nВведите позицию по длине:");
            int y = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("Введите позицию по высоте");
            int x = Convert.ToInt32(Console.ReadLine()) - 1;
            if (board[x, y] != 'X' && board[x, y] != 'O')
            {
                board[x, y] = paint;
            }
            else
            {
                throw new ArgumentException("На этой позиции уже поставлен значок.");
            }
        }

        static void BotSteps(ref char[,] board, char paint)
        {
            int x, y;
            Random rnd = new Random();
            do
            {
                x = rnd.Next(board.GetLength(0));
                y = rnd.Next(board.GetLength(0));
            }
            while (board[x, y] == 'O' || board[x, y] == 'X');
            board[x, y] = paint;
        }

        private static void ShowBoard(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    Console.Write($"{board[i, j]}");
                }
                Console.WriteLine();
            }
        }

        private static void FillBoard(ref char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[j, i] = 'k';
                }
            }
        }
    }
}
