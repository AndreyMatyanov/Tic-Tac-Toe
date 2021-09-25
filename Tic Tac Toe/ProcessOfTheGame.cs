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
            int y = 0;
            int x = 0;
            int countOfZero = 0;
            int countOfCross = 0;

            char[,] board = new char[options.N, options.N];
            FillBoard(ref board);
            StepsFirstOrSecondPlayer(options, ref x, ref y, ref board, ref countOfCross, ref countOfZero);
            ShowBoard(board);
            WriteWhoIsAWinner(countOfCross, countOfZero, options);
        }

        static void StepsFirstOrSecondPlayer(Options options, ref int x,ref int y, ref char[,] board, ref int countOfCross,ref int countOfZero )
        {
            for (int steps = 0; steps < (options.N * options.N) - 1; steps++)
            {
                if ((countOfCross == countOfZero * board.GetLength(0) - 1 && countOfZero != 0) || (countOfZero == countOfCross * board.GetLength(0) - 1 && countOfCross != 0))
                {
                    break;
                }

                if (options.FirstPlayersIsStart is true && steps % 2 == 0)
                {
                    Step(ref board, options.PaintOfTheFirstPlayer, ref x, ref y, "Ход Игрока 1");
                }
                else if (options.FirstPlayersIsStart is true && steps % 2 != 0)
                {
                    if (options.TwoPlayers is false)
                    {
                        BotSteps(ref board, options.PaintOfTheSecondPlayer);
                    }
                    else
                    {
                        Step(ref board, options.PaintOfTheSecondPlayer, ref x, ref y, "Ход Игрока 2");
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
                        Step(ref board, options.PaintOfTheSecondPlayer, ref x, ref y, "Ход Игрока 2");
                    }
                }
                else
                {
                    Step(ref board, options.PaintOfTheFirstPlayer, ref x, ref y, "Ход Игрока 1");
                }
                Score(board, ref countOfCross, ref countOfZero);
                Console.Clear();
            }
        }

        static void Step(ref char[,] board, char paint, ref int x, ref int y, string message)
        {
            try
            {
                ConsoleKeyInfo key;
                do
                {
                    ShowBoard(board, x, y);
                    Console.WriteLine(message);
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            {
                                if (y < board.GetLength(0) - 1)
                                {
                                    y++;
                                }
                                ShowBoard(board, x, y);
                                break;
                            }
                        case ConsoleKey.UpArrow:
                            if (y > 0)
                            {
                                y--;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            {
                                if (x > 0)
                                {
                                    x--;
                                }
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            {
                                if (x < board.GetLength(0) - 1)
                                {
                                    x++;
                                }
                                break;
                            }
                        case ConsoleKey.Enter:
                            {
                                if (board[y, x] != 'X' && board[y, x] != 'O')
                                {
                                    board[y, x] = paint;
                                    return;
                                }
                                else
                                {
                                    throw new ArgumentException("На этой позиции уже поставлен значок.");
                                }
                            }
                        default:
                            break;
                    }
                    Console.Clear();
                }
                while (true);
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Step(ref board, paint, ref x, ref y, message);
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
                    Console.Write($"{board[i, j]}\t");
                }
                Console.WriteLine("\n\n");
            }
        }

        private static void ShowBoard(char[,] board, int x, int y)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    if (x == j && y == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{board[i, j]}\t");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write($"{board[i, j]}\t");
                    }
                }
                Console.Write("\n\n");
            }
        }

        private static void FillBoard(ref char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[j, i] = '_';
                }
            }
        }
    }
}
