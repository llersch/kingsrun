using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingsRun.Gameplay
{
    class Piece
    {
        Tuple<int, int> position = new Tuple<int, int>(0,0);
        int status = 0;

        public Tuple<int, int> Position
        {
            get { return position; }
            set { position = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public int X
        {
            get { return position.Item1; }
        }

        public int Y
        {
            get { return position.Item2; }
        }
    }
}
