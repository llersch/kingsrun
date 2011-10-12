using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingsRun
{
    class Piece
    {
        Position pos = new Position(0,0);
        int status = 0;

        public Piece(int _x, int _y)
        {
            pos.X = _x;
            pos.Y = _y;
        }

        public Position Position
        {
            get { return pos; }
            set { pos = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
