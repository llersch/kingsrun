using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingsRun
{
    class HexGrid
    {
        static int[] neighbors_C = {0, 1, 1, 0, -1, -1};
        static int[,] neighbors_R = { { -1, -1, 0, 1, 0, -1 }, { -1, 0, 1, 1, 1, 0 } };
        static int num_neighbors = 6;

        int[] corners_Dx;
        int[] corners_Dy;
        int side;

        int mX = 0;
        int mY = 0;

        int mC = 0;
        int mR = 0;

        int radius;
        int height;
        int width;

        public HexGrid(int a_radius)
        {
            radius = a_radius;
            width = a_radius * 2;
            height = (int)((float)a_radius * Math.Sqrt(3));
            side = a_radius * 3 / 2;

            int[] cdx = {radius/2, side, width, side, radius/2, 0};
            corners_Dx = cdx;

            int[] cdy = { 0, 0, height / 2, height, height, height / 2 };
            corners_Dy = cdy;
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
            get { return mX + radius; }
        }

        public int CenterY
        {
            get { return mY + height / 2; }
        }

        public int Column
        {
            get { return mC; }
        }

        public int Row
        {
            get { return mR; }
        }

        public int NeighborCol(int neighborIdx)
        {
            return mC + neighbors_C[neighborIdx];
        }

        public int NeighborRow(int neightborIdx)
        {
            return mR + neighbors_R[mC % 2, neightborIdx];
        }

        public void ComputeCorners(int[] cornersX, int[] cornersY)
        {
            for (int k = 0; k < num_neighbors; k++)
            {
                cornersX[k] = mX + corners_Dx[k];
                cornersY[k] = mY + corners_Dy[k];
            }
        }

        public void SetCellIndex(int i, int j)
        {
            mC = i;
            mR = j;
            mX = i * side;
            mY = height * (2*j+(i%2))/2;
        }

        public void SetCellByPoint(int x, int y)
        {
            int ci = (int)Math.Floor((float)x/(float)side);
            int cx = x - side * ci;

            int ty = y - (ci % 2) * height / 2;
            int cj = (int)Math.Floor((float)ty/(float)height);
            int cy = ty - height * cj;

            if (cx > Math.Abs(radius / 2 - radius * cy / height))
            {
                SetCellIndex(ci, cj);
            }
            else
            {
                SetCellIndex(ci - 1, cj + (ci % 2) - ((cy < height / 2) ? 1 : 0));
            }
        }

    }
}
