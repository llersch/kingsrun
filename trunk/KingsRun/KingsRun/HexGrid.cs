using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingsRun
{
    class HexGrid
    {
        const int NUM_NEIGHBORS = 6;

        int[] CORNERS_DX;
        int[] CORNERS_DY;
        int SIDE;

        int mX = 0;
        int mY = 0;

        int mI = 0;
        int mJ = 0;

        int xoff = 0;
        int yoff = 0;

        int RADIUS;
        int WIDTH;
        int HEIGHT;

        public HexGrid(int a_radius, int _xoff, int _yoff)
        {
            xoff = _xoff;
            yoff = _yoff;
            RADIUS = a_radius;
            WIDTH = a_radius * 2;
            HEIGHT = (int)((float)a_radius * Math.Sqrt(3));
            SIDE = a_radius * 3 / 2;

            int[] cdx = { RADIUS / 2, SIDE, WIDTH, SIDE, RADIUS / 2, 0 };
            CORNERS_DX = cdx;

            int[] cdy = { 0, 0, HEIGHT / 2, HEIGHT, HEIGHT, HEIGHT / 2 };
            CORNERS_DY = cdy;
        }

        public int Left
        {
            get { return mX; }
        }

        public int Top
        {
            get { return mY; }
        }

        public int CenterX
        {
            get { return mX + RADIUS; }
        }

        public int CenterY
        {
            get { return mY + HEIGHT / 2; }
        }

        public int Column
        {
            get { return mI; }
        }

        public int Row
        {
            get { return mJ; }
        }

        public void ComputeCorners(int[] cornersX, int[] cornersY)
        {
            for (int k = 0; k < NUM_NEIGHBORS; k++)
            {
                cornersX[k] = mX + CORNERS_DX[k];
                cornersY[k] = mY + CORNERS_DY[k];
            }
        }

        //Board ---> Screen
        public void SetCellIndex(int i, int j)
        {
            mI = i;
            mJ = j;
            mX = i * SIDE;
            mX += xoff;
            mY = HEIGHT * (2*j+(i%2))/2;
            mY += yoff;
        }

        //Screen ---> Board
        public void SetCellByPoint(int x, int y)
        {
            x -= xoff;
            y -= yoff;
            int ci = (int)Math.Floor((float)x / (float)SIDE);
            int cx = x - SIDE * ci;

            int ty = y - (ci % 2) * HEIGHT / 2;
            int cj = (int)Math.Floor((float)ty / (float)HEIGHT);
            int cy = ty - HEIGHT * cj;

            if (cx > Math.Abs(RADIUS / 2 - RADIUS * cy / HEIGHT))
            {
                SetCellIndex(ci, cj);
            }
            else
            {
                SetCellIndex(ci - 1, cj + (ci % 2) - ((cy < HEIGHT / 2) ? 1 : 0));
            }
        }

    }
}
