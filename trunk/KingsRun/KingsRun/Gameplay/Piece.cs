using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingsRun.Gameplay
{
    class Piece
    {
        Position pos = new Position(0,0);
        int status = 0;

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
