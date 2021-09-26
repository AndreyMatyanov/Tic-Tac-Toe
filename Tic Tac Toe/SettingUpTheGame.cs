using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    public static class SettingUpTheGame
    {
        public static Options SetOptions()
        {
            var lengthOfSide = GetLengthOfSide();
            var versusPlayer = IsVersusPlayer();
            var paintOfTheFirstPlayer = PaintOfTheFirstPlayer();
            var firstPlayerStart = IsFirstPlayerStart();
            return new Options(lengthOfSide, versusPlayer, paintOfTheFirstPlayer, firstPlayerStart);
        }

        public static int GetLengthOfSide()
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
                return GetLengthOfSide();
            }
        }

        public static bool IsVersusPlayer()
        {
            try
            {
                Console.WriteLine("Выбор: \n" +
                    "1. Против игрока.\n" +
                    "2. Против бота.\n" +
                    "3. Рандомно.");
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
                return IsVersusPlayer();
            }
        }

        public static char PaintOfTheFirstPlayer()
        {
            try
            {
                Console.WriteLine("Выберите чем ходит Игрок 1 - крестик или нолик:\n" +
                    "1. Крестик.\n" +
                    "2. Нолик.");
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
                return PaintOfTheFirstPlayer();
            }
        }

        public static bool IsFirstPlayerStart()
        {
            try
            {
                Console.WriteLine("Кто ходит первым:\n" +
                    "1. Игрок 1.\n" +
                    "2. Игрок 2/бот.");

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
