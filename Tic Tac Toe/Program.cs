using System;
#pragma warning disable S1118

namespace Tic_Tac_Toe
{
    class Program
    {
        
        static protected void Main(string[] args)
        {
            GameStart(SetOptions());
        }

        static protected Options SetOptions()
        {
            return new Options(CountOfSide(), IsVersusPlayes(), PaintOfTheFirstPlayes(), IsFirstPlayerStart());
        }

        static protected int CountOfSide()
        {
            Console.WriteLine("Введите количество сторон:");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n < 3 || (n % 2) == 0)
            {
                throw new ArgumentException("Сторона не может быть меньше 3.");
            }

            Console.Clear();
            return n;
        }

        static protected bool IsVersusPlayes()
        {
            Console.WriteLine("Выбор: \n1. Против игрока.\n2.Против бота.");
            int i = Convert.ToInt32(Console.ReadLine());
            bool twoPlayers = i switch
            {
                1 => true,
                2 => false,
                _ => throw new ArgumentException("Выбор между 1 и 2!"),
            };
            Console.Clear();
            return twoPlayers;
        }

        static protected char PaintOfTheFirstPlayes()
        {
            Console.WriteLine("Выберите чем ходит Игрок 1 - крестик или нолик:\n1. Крестик.\n2. Нолик.");
            int i = Convert.ToInt32(Console.ReadLine());
            char paint = i switch
            {
                1 => 'X',
                2 => 'O',
                _ => throw new ArgumentException("Выбор между 1 и 2!"),
            };
            Console.Clear();
            return paint;
        }

        static protected bool IsFirstPlayerStart()
        {
            Console.WriteLine("Кто ходит первым:\n1. Игрок 1.\n2. Игрок 2/бот.");
            int i = Convert.ToInt32(Console.ReadLine());
            bool firstPlayerIsStart = i switch
            {
                1 => true,
                2 => false,
                _ => throw new ArgumentException("Выбор между 1 и 2!"),
            };
            Console.Clear();
            return firstPlayerIsStart;
        }

        static protected void GameStart(Options options)
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
                    SecondPlayerSteps(ref board, options.PaintOfTheSecondPlayer);
                }
                else if (options.FirstPlayersIsStart is false && steps % 2 == 0)
                {
                    SecondPlayerSteps(ref board, options.PaintOfTheSecondPlayer);
                }
                else
                {
                    FirstPlayerSteps(ref board, options.PaintOfTheFirstPlayer);
                }
                Console.Clear();
            }
        }

        static void FirstPlayerSteps(ref char[,] board, char paint)
        {
            Console.WriteLine("Ход игрока 1.\nВведите позицию по длине:");
            int y = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("Введите позицию по высоте");
            int x = Convert.ToInt32(Console.ReadLine()) - 1;
            if (board[x,y] != 'X' && board[x,y] != 'O')
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

        static protected void ShowBoard(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    Console.Write($"{board[i,j]}");
                }
                Console.WriteLine();
            }
        }

        static protected void FillBoard(ref char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[j, i] = 'k';
                }
            }
        }

        static public (int,int) Score(char[,] board)
        {
            int countOfCross = 0;
            int countOfZero = 0;

            int tempCountZero;
            int tempCountCross;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                tempCountZero = 0;
                tempCountCross = 0;
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    if (board[i,j] == 'O' && tempCountCross > 0)
                    {
                        tempCountCross = 0;
                        tempCountZero++;
                    }
                    else if (board[i,j] == 'O' && tempCountZero == 2)
                    {
                        tempCountZero = 0;
                        countOfZero++;
                    }
                    else if (board[i,j] == 'O')
                    {
                        tempCountZero++;
                    }
                    else if (board[i,j] == 'X' && tempCountZero > 0)
                    {
                        tempCountZero = 0;
                        tempCountCross++;
                    }
                    else if (board[i,j] == 'X' && tempCountCross == 2)
                    {
                        tempCountCross = 0;
                        countOfCross++;
                    }
                    else if (board[i,j] == 'X')
                    {
                        tempCountCross++;
                    }
                }
            }

            return (countOfCross, countOfZero);
        }
    }
}
