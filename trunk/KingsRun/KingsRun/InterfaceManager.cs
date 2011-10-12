using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace KingsRun
{
    class InterfaceManager
    {
        HexGrid grid;
        BoardManager bManager;
        
        public InterfaceManager(int _radius, int _xoff, int _yoff, BoardManager _bmanager)
        {
            grid = new HexGrid(_radius, _xoff, _yoff);
            bManager = _bmanager;
        }

        public Position ScreenToBoard(int x, int y)
        {
            grid.SetCellByPoint(x, y);
            return new Position(grid.Column, grid.Row);
        }

        public Rectangle PieceRect(Piece _piece)
        {
            grid.SetCellIndex(_piece.Position.X, _piece.Position.Y);
            return new Rectangle(grid.CenterX - 30, grid.CenterY - 30, 60, 60);            
        }

    }
}
