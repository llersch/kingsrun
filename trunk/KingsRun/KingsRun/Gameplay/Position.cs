using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingsRun.Gameplay
{
    class Position
    {
        public Tuple<int, int> position;

        public Position()
            : this(0,0)
        { }

        public Position(int initColumn, int initRow)
        {
            column = initColumn;
            row = initRow;
        }
    }
}
