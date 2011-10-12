using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingsRun
{
    class Position
    {
        int x = 0;
        int y = 0;

        public Position(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Position pos = (Position) obj;

            if (!Object.Equals(this.X, pos.X)) return false;
            if (!Object.Equals(this.Y, pos.Y)) return false;

            if (!this.X.Equals(pos.X)) return false;
            if (!this.Y.Equals(pos.Y)) return false;

            return true;
        }
    }
}
