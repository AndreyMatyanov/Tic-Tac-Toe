using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    public static class SettingUpTheGame
    {
        public static Options SetOptions()
        {
            return new Options(CountOfSide(), IsVersusPlayes(), PaintOfTheFirstPlayes(), IsFirstPlayerStart());
        }

        public static int CountOfSide()
        {
            try
            {
                Console.WriteLine("Введите количество сторон:");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (n < 3 || (n % 2) == 0)
                {
                    throw new ArgumentException("Сторона не может быть меньше 3.");
                }
                return n;
            }
            catch
            {
                return CountOfSide();
            }
        }

        public static bool IsVersusPlayes()
        {
            try
            {
                Console.WriteLine("Выбор: \n1. Против игрока.\n2. Против бота.\n3. Рандомно.");
                int i = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                bool twoPlayers = i switch
                {
                    1 => true,
                    2 => false,
                    3 => (new Random()).Next(100) < 50,
                    _ => throw new ArgumentException("Неверные данные.")
                };
                return twoPlayers;
            }
            catch
            {
                return IsVersusPlayes();
            }
        }

        public static char PaintOfTheFirstPlayes()
        {
            try
            {
                Console.WriteLine("Выберите чем ходит Игрок 1 - крестик или нолик:\n1. Крестик.\n2. Нолик.");
                int i = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                char paint = i switch
                {
                    1 => 'X',
                    2 => 'O',
                    _ => throw new ArgumentException("Выбор между 1 и 2!"),
                };
                return paint;
            }
            catch
            {
                Console.Clear();
                return PaintOfTheFirstPlayes();
            }
        }

        public static bool IsFirstPlayerStart()
        {
            try
            {
                Console.WriteLine("Кто ходит первым:\n1. Игрок 1.\n2. Игрок 2/бот.");
                int i = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                bool firstPlayerIsStart = i switch
                {
                    1 => true,
                    2 => false,
                    _ => throw new ArgumentException("Выбор между 1 и 2!"),
                };
                return firstPlayerIsStart;
            }
            catch
            {
                return IsFirstPlayerStart();
            }
        }
    }
}
