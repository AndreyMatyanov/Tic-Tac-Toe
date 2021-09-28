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
            int x = 0;
            int y = 0;
            int countOfZero = 0;
            int countOfCross = 0;

            char[,] board = new char[options.N, options.N];

            FillBoard(ref board);

            StepsFirstOrSecondPlayer(
                options, 
                ref x, 
                ref y, 
                ref board, 
                ref countOfCross, 
                ref countOfZero);

            ShowBoard(board);

            WriteWhoIsAWinner(
                countOfCross, 
                countOfZero, 
                options);

            NewGame();
        }

        static void StepsFirstOrSecondPlayer(
            Options options, 
            ref int x,
            ref int y, 
            ref char[,] board, 
            ref int countOfCross,
            ref int countOfZero )
        {
            for (int steps = 0; steps < (options.N * options.N) - 1; steps++)
            {
                if ((countOfCross == countOfZero * board.GetLength(0) - 1 && countOfZero != 0) 
                    || (countOfZero == countOfCross * board.GetLength(0) - 1 && countOfCross != 0))
                {
                    break;
                }

                switch (options.FirstPlayersIsStart)
                {
                    case true when steps % 2 == 0:
                        Step(
                            ref board,
                            options.PaintOfTheFirstPlayer,
                            ref x,
                            ref y,
                            "Ход Игрока 1");
                        break;

                    case true when steps % 2 != 0 && options.TwoPlayers is false:
                        BotSteps(
                            ref board,
                            options.PaintOfTheSecondPlayer);
                        break;

                    case true when steps % 2 != 0 && options.TwoPlayers is true:
                        Step(
                            ref board,
                            options.PaintOfTheSecondPlayer,
                            ref x,
                            ref y,
                            "Ход Игрока 2");
                        break;

                    case false when steps % 2 == 0 && options.TwoPlayers is false:
                        BotSteps(
                            ref board,
                            options.PaintOfTheSecondPlayer);
                        break;

                    case false when steps % 2 == 0 && options.TwoPlayers is true:
                        Step(
                            ref board,
                            options.PaintOfTheSecondPlayer,
                            ref x,
                            ref y,
                            "Ход Игрока 2");
                        break;

                    default:
                        Step(
                            ref board,
                            options.PaintOfTheFirstPlayer,
                            ref x,
                            ref y,
                            "Ход Игрока 1");
                        break;
                }

                Score(
                    board, 
                    ref countOfCross, 
                    ref countOfZero);
                Console.Clear();
            }
        }

        static void Step(
            ref char[,] board, 
            char paint, 
            ref int x, 
            ref int y, 
            string message)
        {
            try
            {
                ConsoleKeyInfo key;

                do
                {
                    ShowBoard(
                        board, 
                        x, 
                        y);

                    Console.WriteLine(message);

                    key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (y < board.GetLength(0) - 1)
                            {
                                y++;
                            }

                            break;
                        case ConsoleKey.UpArrow:
                            if (y > 0)
                            {
                                y--;
                            }

                            break;
                        case ConsoleKey.LeftArrow:
                            if (x > 0)
                            { 
                                x--;
                            }
                            break;

                        case ConsoleKey.RightArrow:
                            if (x < board.GetLength(0) - 1)
                            {
                                x++;
                            }
                            break;

                        case ConsoleKey.Enter:
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

                    Console.Clear();
                }
                while (true);
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Step(
                    ref board, 
                    paint, 
                    ref x, 
                    ref y, 
                    message);
            }
        }

        static void BotSteps(
            ref char[,] board, 
            char paint)
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

        private static void ShowBoard(
            char[,] board, 
            int x, 
            int y)
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

        private static void NewGame()
        {
            string[] choice = { "Да.", "Нет." };
            int position = 0;

            ConsoleKeyInfo key;

            do
            {
                Console.WriteLine("Начать новую игру?");

                ShowStringsChoice(
                    choice, 
                    position);

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (position < choice.Length - 1)
                        {
                            position++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (position > 0)
                        {
                            position--;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if(position == 0)
                        {
                            GameStart(SettingUpTheGame.SetOptions());
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
                Console.Clear();
            }
            while (true);
        }

        private static void ShowStringsChoice(
            string[] choice, 
            int position)
        {
            for (int i = 0; i < choice.Length; i++)
            {
                if (i == position)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{choice[i]}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.WriteLine(choice[i]);
                }
            }
        }
    }
}
