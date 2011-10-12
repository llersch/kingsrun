using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingsRun
{
    class InterfaceManager
    {
        HexGrid grid;
        BoardManager bmanager;
        
        public InterfaceManager(int _radius, int _xoff, int _yoff, BoardManager _bmanager)
        {
            grid = new HexGrid(_radius);
            bmanager = _bmanager;
        }

    }
}
