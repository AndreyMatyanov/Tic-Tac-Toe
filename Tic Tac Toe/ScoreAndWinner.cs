using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    static class ScoreAndWinner
    {

        public static void Score(
            char[,] board, 
            ref int countOfCross, 
            ref int countOfZero)
        {
            countOfCross = 0;
            countOfZero = 0;

            PointHorizontal(
                ref countOfZero, 
                ref countOfCross, 
                board);

            PointVertical(
                ref countOfZero,
                ref countOfCross, 
                board);

            PointDiagonalRightLeft(
                ref countOfZero, 
                ref countOfCross, 
                board);

            PointDiagonalLeftRight(
                ref countOfZero, 
                ref countOfCross, 
                board);
        }
        public static void WriteWhoIsAWinner(
            int countOfCross, 
            int countOfZero, 
            Options options)
        {
            string botWinMessage = "Бот победил.";
            string firstPlayerWin = "Первый игрок - победитель.";
            string secondPlayerWin = "Второй игрок - победитель.";
            string nobody = "Ничья.";

            if ((options.PaintOfTheFirstPlayer == 'O' && countOfZero > countOfCross)
                || (options.PaintOfTheFirstPlayer == 'X' && countOfCross > countOfZero))
            {
                Console.WriteLine(firstPlayerWin);
            }
            else if ((options.PaintOfTheSecondPlayer == 'O' && countOfZero > countOfCross && options.TwoPlayers is true)
                || (options.PaintOfTheSecondPlayer == 'X' && countOfCross > countOfZero && options.TwoPlayers is true))
            {
                Console.WriteLine(secondPlayerWin);
            }
            else if ((options.PaintOfTheSecondPlayer == 'O' && countOfZero > countOfCross && options.TwoPlayers is false)
                || (options.PaintOfTheSecondPlayer == 'X' && countOfCross > countOfZero && options.TwoPlayers is false))
            {
                Console.WriteLine(botWinMessage);
            }
            else
            {
                Console.WriteLine(nobody);
            }
        }
        public static void PointHorizontal(
            ref int countOfZero, 
            ref int countOfCross, 
            char[,] board)
        {
            int tempCountZero;
            int tempCountCross;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                tempCountZero = 0;
                tempCountCross = 0;
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    switch (board[i, j])
                    {
                        case 'O' when tempCountCross > 0:
                            tempCountCross = 0;
                            tempCountZero++;
                            break;

                        case 'O' when tempCountZero == 2:
                            tempCountZero = 0;
                            countOfZero++;
                            break;

                        case 'O':
                            tempCountZero++;
                            break;

                        case 'X' when tempCountZero > 0:
                            tempCountZero = 0;
                            tempCountCross++;
                            break;

                        case 'X' when tempCountCross == 2:
                            tempCountCross = 0;
                            countOfCross++;
                            break;

                        case 'X':
                            tempCountCross++;
                            break;
                    }
                }
            }
        }

        public static void PointVertical(
            ref int countOfZero, 
            ref int countOfCross, 
            char[,] board)
        {
            int tempCountZero;
            int tempCountCross;
            for (int j = 0; j < board.GetLength(0); j++)
            {
                tempCountZero = 0;
                tempCountCross = 0;
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    switch (board[i, j])
                    {
                        case 'O' when tempCountCross > 0:
                            tempCountCross = 0;
                            tempCountZero++;
                            break;

                        case 'O' when tempCountZero == 2:
                            tempCountZero = 0;
                            countOfZero++;
                            break;

                        case 'O':
                            tempCountZero++;
                            break;

                        case 'X' when tempCountZero > 0:
                            tempCountZero = 0;
                            tempCountCross++;
                            break;

                        case 'X' when tempCountCross == 2:
                            tempCountCross = 0;
                            countOfCross++;
                            break;

                        case 'X':
                            tempCountCross++;
                            break;
                    }
                }
            }
        }

        public static void PointDiagonalRightLeft(
            ref int countOfZero, 
            ref int countOfCross, 
            char[,] board)
        {
            int tempCountZero;
            int tempCountCross;
            for (int k = 0; k < board.GetLength(0) * 2; k++)
            {
                tempCountCross = 0;
                tempCountZero = 0;
                for (int j = 0; j <= k; j++)
                {
                    int i = k - j;
                    if (i < board.GetLength(0) && j < board.GetLength(0))
                    {
                        switch (board[i, j])
                        {
                            case 'O' when tempCountCross > 0:
                                tempCountCross = 0;
                                tempCountZero++;
                                break;

                            case 'O' when tempCountZero == 2:
                                tempCountZero = 0;
                                countOfZero++;
                                break;

                            case 'O':
                                tempCountZero++;
                                break;

                            case 'X' when tempCountZero > 0:
                                tempCountZero = 0;
                                tempCountCross++;
                                break;

                            case 'X' when tempCountCross == 2:
                                tempCountCross = 0;
                                countOfCross++;
                                break;

                            case 'X':
                                tempCountCross++;
                                break;
                        }
                    }
                }

            }
        }
        public static void PointDiagonalLeftRight(
            ref int countOfZero, 
            ref int countOfCross, 
            char[,] board)
        {
            int tempCountZero;
            int tempCountCross;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                tempCountCross = 0;
                tempCountZero = 0;
                int x = board.GetLength(0) - 1 - i;
                for (int y = 0; y <= i; y++)
                {
                    switch (board[y, x])
                    {
                        case 'O' when tempCountCross > 0:
                            tempCountCross = 0;
                            tempCountZero++;
                            break;

                        case 'O' when tempCountZero == 2:
                            tempCountZero = 0;
                            countOfZero++;
                            break;

                        case 'O':
                            tempCountZero++;
                            break;

                        case 'X' when tempCountZero > 0:
                            tempCountZero = 0;
                            tempCountCross++;
                            break;

                        case 'X' when tempCountCross == 2:
                            tempCountCross = 0;
                            countOfCross++;
                            break;

                        case 'X':
                            tempCountCross++;
                            break;
                    }
                    x++;
                }
            }

            for (int i = board.GetLength(0) - 2; i >= 0; i--)
            {
                tempCountCross = 0;
                tempCountZero = 0;
                int x = board.GetLength(0) - 1 - i;
                for (int y = 0; y <= i; y++)
                {
                    switch (board[x, y])
                    {
                        case 'O' when tempCountCross > 0:
                            tempCountCross = 0;
                            tempCountZero++;
                            break;

                        case 'O' when tempCountZero == 2:
                            tempCountZero = 0;
                            countOfZero++;
                            break;

                        case 'O':
                            tempCountZero++;
                            break;

                        case 'X' when tempCountZero > 0:
                            tempCountZero = 0;
                            tempCountCross++;
                            break;

                        case 'X' when tempCountCross == 2:
                            tempCountCross = 0;
                            countOfCross++;
                            break;

                        case 'X':
                            tempCountCross++;
                            break;
                    }
                    x++;
                }
            }
        }
    }
}
