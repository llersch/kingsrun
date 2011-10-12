using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingsRun.Gameplay
{
    class Movement
    {
        Piece piece;
        Position sPosition = new Position(0,0);

        public Movement(Piece _piece)
        {
            piece = _piece;
            sPosition.X = _piece.Position.X;
            sPosition.Y = _piece.Position.Y;
        }

        public Piece Piece
        {
            get { return piece; }
        }

        public Position SPosition
        {
            get { return sPosition; }
        }
    }
}
