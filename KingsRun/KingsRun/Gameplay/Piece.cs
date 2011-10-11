using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingsRun.Gameplay
{
    class Piece
    {
        Tuple<byte, byte> position = new Tuple<byte, byte>(0,0);
        int status = 0;

        public Tuple<byte, byte> Position
        {
            get { return position; }
            set { position = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public byte X
        {
            get { return position.Item1; }
        }

        public byte Y
        {
            get { return position.Item2; }
        }
    }
}
