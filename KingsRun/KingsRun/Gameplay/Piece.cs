using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingsRun.Gameplay
{
    class Piece
    {
        public Tuple<int, int> position = new Tuple<int, int>(0,0);
        public int status = 0;

        public Piece()
            : this(null)
        { }

        public Piece(int row, int column)
            : this(new Tuple<int,int>(row,column))
        { }

        public Piece(Tuple<int,int> initPos)
        {
            position = initPos;
        }
    }
}
