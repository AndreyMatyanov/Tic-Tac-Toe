using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    public class Options
    {
        private readonly int n;
        private readonly bool twoPlayers;
        private readonly char paintOfTheFirstPlayer;
        private readonly char paintOfTheSecondPlayer;
        private readonly bool firstPlayerIsStart;

        public Options(int n, bool twoPlayers, char paint, bool firstPlayerIsStart)
        {
            this.n = n;
            this.twoPlayers = twoPlayers;
            this.firstPlayerIsStart = firstPlayerIsStart;
            paintOfTheFirstPlayer = paint;
            if (paintOfTheFirstPlayer == 'X')
            {
                paintOfTheSecondPlayer = 'O';
            }
            else
            {
                paintOfTheSecondPlayer = 'X';
            }
        }

        public int N
        {
            get { return n; }
        }

        public bool TwoPlayers
        {
            get { return twoPlayers; }
        }

        public char PaintOfTheFirstPlayer
        {
            get { return paintOfTheFirstPlayer; }
        }
        
        public char PaintOfTheSecondPlayer
        {
            get { return paintOfTheSecondPlayer; }
        }

        public bool FirstPlayersIsStart
        {
            get { return firstPlayerIsStart; }
        }

    }
}
