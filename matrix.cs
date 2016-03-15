using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ANDREICSLIB;
using ANDREICSLIB.ClassExtras;
using ANDREICSLIB.Helpers;

namespace SudokuSolver
{
	public class matrix
	{
		public int width;
		public int height;
		public int[][] grid;
		private int max;
		private int square;
		private static Random RN = new Random();

		public matrix clone()
		{
			var m = new matrix(width, height);
			m.grid = MatrixOps.CloneMatrix(grid, width, height);
			return m;
		}

		public void copyFrom(matrix m)
		{
			width = m.width;
			height = m.height;
			grid = null;
			grid = MatrixOps.CloneMatrix(m.grid, width, height);
			max = getMaxNumber();
			square = getSquareSize();
		}

		public enum celltype
		{
			good, bad, empty
		}

		public matrix(int w, int h, String serialised = "")
		{
			width = w;
			height = h;
			max = getMaxNumber();
			square = getSquareSize();
			grid = new int[h][];
			int count = 0;
			char[] sep = new char[] { ',' };
			String[] ser = serialised.Split(sep);

			for (int a = 0; a < h; a++)
			{
				grid[a] = new int[width];
				if (serialised.Length != 0)
				{
					for (int b = 0; b < w; b++)
					{
						try
						{
							grid[a][b] = int.Parse(ser[count]);
						}
						catch (Exception)
						{

						}

						count++;
					}
				}
			}
		}

		private int getMaxNumber()
		{
			//return width > height ? width+1 : height+1;
			return 10;
		}

		private int getSquareSize()
		{
			return 3;
		}

		private int[] getHorizPossibilities(int myX, int y)
		{
			var ret = new List<int>();
			int[] h = new int[max];
			for (int a = 0; a < width; a++)
			{
				if (a == myX)
					continue;

				h[grid[y][a]]++;
			}

			return h;
		}

		private int[] getVertPossibilities(int x, int myY)
		{
			var ret = new List<int>();
			int[] h = new int[max];
			for (int a = 0; a < height; a++)
			{
				if (myY == a)
					continue;
				h[grid[a][x]]++;
			}
			return h;
		}

		private int[] getSquarePossibilities(int x, int y)
		{
			var ret = new List<int>();
			int[] h = new int[max];
			int sqx = MathExtras.Floor(x / square);
            int sqy = MathExtras.Floor(y / square);
			sqx *= square;
			sqy *= square;

			for (int y1 = sqy; y1 < sqy + square; y1++)
			{
				for (int x1 = sqx; x1 < sqx + square; x1++)
				{
					if (y1 == y && x1 == x)
						continue;
					h[grid[y1][x1]]++;
				}
			}
			return h;
		}

		public List<int> getPossibilities(int x, int y)
		{
			int[] h = new int[max];
            var ret = new List<int>();
			var v1 = getHorizPossibilities(x, y);
			var v2 = getVertPossibilities(x, y);
			var v3 = getSquarePossibilities(x, y);


			for (int a = 1; a < max; a++)
			{
				if (v1[a] == 0 && v2[a] == 0 && v3[a] == 0)
				{
					//put random to minimise worst cast
					int rand = 0;
					if (ret.Count != 0)
						rand = RN.Next() % ret.Count;

					ret.Insert(rand, a);
				}
			}
			return ret;
		}

		private bool solve()
		{
			//do all the obvious solutions
			int unsetpieces;
		doagain:
			unsetpieces = 0;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if (grid[y][x] != 0)
						continue;

					var pos = getPossibilities(x, y);
					if (pos.Count == 0)
						return false;

					if (pos.Count == 1)
					{
						grid[y][x] = pos[0];
						goto doagain;
					}
					unsetpieces++;
				}
			}
			//if there are no blank squares, check result
			if (unsetpieces == 0)
				return true;

			//no we have to split to possible choices
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if (grid[y][x] != 0)
						continue;

					var pos = getPossibilities(x, y);

					foreach (var v in pos)
					{
						grid[y][x] = v;
						bool success = solveHead();
						if (success)
							return true;
					}
				}
			}

			return false;
		}

		public bool solveHead()
		{
			//check first -  is it complete?
			var test = checkGrid(true);
			if (test.Item2)
				return true;

			var m = clone();
			bool success = m.solve();
			if (success)
				copyFrom(m);

			return success;
		}

		//grid, is good
		public Tuple<celltype[][], bool> checkGrid(bool abortOnNotGood = false, bool allowEmpty = false)
		{
			celltype[][] ret = MatrixOps.CreateMatrix<celltype>(width, height);
			bool good = true;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if (grid[y][x] == 0)
						ret[y][x] = celltype.empty;
					else
					{
						ret[y][x] = checkSpot(x, y);
					}

					if (ret[y][x] != celltype.good)
					{
						if (allowEmpty == false || ret[y][x] == celltype.bad)
							good = false;

						if (abortOnNotGood && good == false)
							return new Tuple<celltype[][], bool>(null, good);
					}
				}
			}
			return new Tuple<celltype[][], bool>(ret, good);
		}

		private celltype checkSpot(int x, int y)
		{
			if (checkHorizontal(x, y) == false)
				return celltype.bad;

			if (checkVertical(x, y) == false)
				return celltype.bad;

			if (checkSquare(x, y) == false)
				return celltype.bad;

			return celltype.good;
		}

		private bool checkHorizontal(int myX, int y)
		{
			int me = grid[y][myX];
			for (int x = 0; x < width; x++)
			{
				if (grid[y][x] == me && x != myX)
					return false;
			}
			return true;
		}

		private bool checkVertical(int x, int myY)
		{
			int me = grid[myY][x];
			for (int y = 0; y < height; y++)
			{
				if (grid[y][x] == me && y != myY)
					return false;
			}
			return true;
		}

		private bool checkSquare(int x, int y)
		{
			//get the square
            int sqx = MathExtras.Floor(x / square);
            int sqy = MathExtras.Floor(y / square);
			sqx *= square;
			sqy *= square;
			int me = grid[y][x];

			for (int y1 = sqy; y1 < sqy + square; y1++)
			{
				for (int x1 = sqx; x1 < sqx + square; x1++)
				{
					if (y1 >= height || x1 >= width)
						continue;
					if (grid[y1][x1] == me && (y1 != y || x1 != x))
						return false;
				}
			}
			return true;
		}
	}
}
