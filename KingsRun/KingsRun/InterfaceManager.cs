using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void DrawBoard(List<Piece> p1, List<Piece> p2)
        {
        }

    }
}
