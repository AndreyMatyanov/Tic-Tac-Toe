﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    static class ScoreAndWinner
    {

        public static void Score(char[,] board, Options options)
        {
            int countOfCross = 0;
            int countOfZero = 0;

            PointHorizontal(ref countOfZero, ref countOfCross, board);
            PointVertical(ref countOfZero, ref countOfCross, board);
            PointDiagonalRightLeft(ref countOfZero, ref countOfCross, board);
            PointDiagonalLeftRight(ref countOfZero, ref countOfCross, board);
            WriteWhoIsAWinner(countOfCross, countOfZero, options);
        }
        static void WriteWhoIsAWinner(int countOfCross, int countOfZero, Options options)
        {
            if(options.PaintOfTheFirstPlayer == 'O')
            {
                Console.WriteLine($"Первый игрок: {countOfZero} очков.\nВторой игры: {countOfCross} очков.");
                if (countOfZero > countOfCross)
                {
                    Console.WriteLine("Первый игрок - победитель.");
                }
                else if (countOfZero < countOfCross)
                {
                    Console.WriteLine("Второй игрок - победитель.");
                }
                else
                {
                    Console.WriteLine("Ничья.");
                }
            }
            else
            {
                Console.WriteLine($"Первый игрок: {countOfCross} очков.\nВторой игры: {countOfZero} очков.");
                if (countOfZero < countOfCross)
                {
                    Console.WriteLine("Первый игрок - победитель.");
                }
                else if (countOfZero > countOfCross)
                {
                    Console.WriteLine("Второй игрок - победитель.");
                }
                else
                {
                    Console.WriteLine("Ничья.");
                }
            }
        }
        public static void PointHorizontal(ref int countOfZero, ref int countOfCross, char[,] board)
        {
            int tempCountZero;
            int tempCountCross;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                tempCountZero = 0;
                tempCountCross = 0;
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    if (board[i, j] == 'O' && tempCountCross > 0)
                    {
                        tempCountCross = 0;
                        tempCountZero++;
                    }
                    else if (board[i, j] == 'O' && tempCountZero == 2)
                    {
                        tempCountZero = 0;
                        countOfZero++;
                    }
                    else if (board[i, j] == 'O')
                    {
                        tempCountZero++;
                    }
                    else if (board[i, j] == 'X' && tempCountZero > 0)
                    {
                        tempCountZero = 0;
                        tempCountCross++;
                    }
                    else if (board[i, j] == 'X' && tempCountCross == 2)
                    {
                        tempCountCross = 0;
                        countOfCross++;
                    }
                    else if (board[i, j] == 'X')
                    {
                        tempCountCross++;
                    }
                }
            }
        }

        public static void PointVertical(ref int countOfZero, ref int countOfCross, char[,] board)
        {
            int tempCountZero;
            int tempCountCross;
            for (int j = 0; j < board.GetLength(0); j++)
            {
                tempCountZero = 0;
                tempCountCross = 0;
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    if (board[i, j] == 'O' && tempCountCross > 0)
                    {
                        tempCountCross = 0;
                        tempCountZero++;
                    }
                    else if (board[i, j] == 'O' && tempCountZero == 2)
                    {
                        tempCountZero = 0;
                        countOfZero++;
                    }
                    else if (board[i, j] == 'O')
                    {
                        tempCountZero++;
                    }
                    else if (board[i, j] == 'X' && tempCountZero > 0)
                    {
                        tempCountZero = 0;
                        tempCountCross++;
                    }
                    else if (board[i, j] == 'X' && tempCountCross == 2)
                    {
                        tempCountCross = 0;
                        countOfCross++;
                    }
                    else if (board[i, j] == 'X')
                    {
                        tempCountCross++;
                    }
                }
            }
        }

        public static void PointDiagonalRightLeft(ref int countOfZero, ref int countOfCross, char[,] board)
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
                        if (board[i, j] == 'O' && tempCountCross > 0)
                        {
                            tempCountCross = 0;
                            tempCountZero++;
                        }
                        else if (board[i, j] == 'O' && tempCountZero == 2)
                        {
                            tempCountZero = 0;
                            countOfZero++;
                        }
                        else if (board[i, j] == 'O')
                        {
                            tempCountZero++;
                        }
                        else if (board[i, j] == 'X' && tempCountZero > 0)
                        {
                            tempCountZero = 0;
                            tempCountCross++;
                        }
                        else if (board[i, j] == 'X' && tempCountCross == 2)
                        {
                            tempCountCross = 0;
                            countOfCross++;
                        }
                        else if (board[i, j] == 'X')
                        {
                            tempCountCross++;
                        }
                    }
                }

            }
        }
        public static void PointDiagonalLeftRight(ref int countOfZero, ref int countOfCross, char[,] board)
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
                    if (board[y, x] == 'O' && tempCountCross > 0)
                    {
                        tempCountCross = 0;
                        tempCountZero++;
                    }
                    else if (board[y, x] == 'O' && tempCountZero == 2)
                    {
                        tempCountZero = 0;
                        countOfZero++;
                    }
                    else if (board[y, x] == 'O')
                    {
                        tempCountZero++;
                    }
                    else if (board[y, x] == 'X' && tempCountZero > 0)
                    {
                        tempCountZero = 0;
                        tempCountCross++;
                    }
                    else if (board[y, x] == 'X' && tempCountCross == 2)
                    {
                        tempCountCross = 0;
                        countOfCross++;
                    }
                    else if (board[y, x] == 'X')
                    {
                        tempCountCross++;
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
                    if (board[x, y] == 'O' && tempCountCross > 0)
                    {
                        tempCountCross = 0;
                        tempCountZero++;
                    }
                    else if (board[x, y] == 'O' && tempCountZero == 2)
                    {
                        tempCountZero = 0;
                        countOfZero++;
                        Console.WriteLine("ОГО");
                    }
                    else if (board[x, y] == 'O')
                    {
                        tempCountZero++;
                    }
                    else if (board[x, y] == 'X' && tempCountZero > 0)
                    {
                        tempCountZero = 0;
                        tempCountCross++;
                    }
                    else if (board[x, y] == 'X' && tempCountCross == 2)
                    {
                        tempCountCross = 0;
                        countOfCross++;
                    }
                    else if (board[x, y] == 'X')
                    {
                        tempCountCross++;
                    }
                    x++;
                }
            }
        }
    }
}
