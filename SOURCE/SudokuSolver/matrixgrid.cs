using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ANDREICSLIB;
using ANDREICSLIB.ClassExtras;

namespace SudokuSolver
{
	public static class matrixgrid
	{
		public static Form1 baseform;
		private static int width;
		private static int height;

		public static void clear()
		{
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					var TB = baseform.grid.getControlByName(getname(x, y));
					TB.Text = "";
				}
			}
			doCheck();
		}

		public static void generateRandom(int widthIN, int heightIN, int random)
		{
			matrix m = new matrix(widthIN, heightIN);
			m.solveHead();

			int rcount = 0;
			Random RN = new Random();

			while (rcount < random)
			{
				int x = RN.Next() % width;
				int y = RN.Next() % height;
				if (m.grid[y][x] == 0)
					continue;
				m.grid[y][x] = 0;
				rcount++;
			}

			init(widthIN, heightIN);
			deSerialise(m);
			doCheck();
		}

		public static void init(int w, int h, String serialised = "")
		{
			baseform.grid.clearControls();
			width = w;
			height = h;
			creatematrix(serialised);
		}

		public static void doCheck()
		{
			matrix m = new matrix(width, height, matrixgrid.serialise());
			var check = m.checkGrid();
			applyCheck(check.Item1);
		}

		private static void keypressfunc(object sender, KeyEventArgs e)
		{
			doCheck();
		}

		private static void creatematrix(String serialised = "")
		{
			int count = 0;
			char[] sep = new char[] { ',' };
			String ser2 = StringExtras.ReplaceAllChars(serialised, "\r\n", ",");
			String[] ser = ser2.Split(sep);

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					int gw = PanelReplacement.gap;
                    int gh = PanelReplacement.gap;
					if ((y + 1) % 3 != 0 || (y + 1) == 0)
						gh = 0;
					if ((x + 1) % 3 != 0 || (x + 1) == 0)
						gw = 0;

					var TB = new TextBox();
					TB.KeyUp += keypressfunc;
					TB.MouseHover += TB_MouseHover;

					if (serialised.Length > 0)
					{
						if (ser[count] != "0")
							TB.Text = ser[count];
						count++;
					}

					TB.TextAlign = HorizontalAlignment.Center;
					TB.MaxLength = 1;
					TB.Size = new Size(20, 20);
					TB.Name = getname(x, y);
					TB.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((0)));
					baseform.grid.addControl(TB, x != (width - 1));
				}
			}
		}

		static void TB_MouseHover(object sender, EventArgs e)
		{
			if (baseform.showPossibleMovesOnHoverToolStripMenuItem.Checked == false)
				return;

			TextBox TB = sender as TextBox;
			if (TB == null)
				return;

			var a = getLocationFromName(TB.Name);
			int x = a.Item2;
			int y = a.Item1;
			matrix m = new matrix(width, height, serialise());
			var b = m.getPossibilities(x, y);
			
            String TT =ListExtras.Serialise(b.Cast<object>().ToList());
			if (TT.Length == 0)
				TT = "No Options";
			ObjectExtras.AddToolTip(TB, TT);
		}

		public static void deSerialise(String file)
		{
			FileStream FS = new FileStream(file, FileMode.Open);
			StreamReader SR = new StreamReader(FS);
			try
			{
				//get width,height
				var x = StringExtras.SplitTwoInt(SR.ReadLine(), ',');
				//get matrix
				String y = SR.ReadToEnd();
				init(x.Item1, x.Item2, y);
			}
			catch (Exception)
			{
			}
			SR.Close();
			FS.Close();
		}

		public static void deSerialise(matrix m)
		{
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					var TB = baseform.grid.getControlByName(getname(x, y));
					if (m.grid[y][x] != 0)
						TB.Text = m.grid[y][x].ToString();
					else
						TB.Text = "";
				}
			}
		}

		public static void solve()
		{
			matrix m = new matrix(width, height, matrixgrid.serialise());

			//check its possible to start with
			var test = m.checkGrid(true, true);
			if (test.Item2 == false)
			{
				MessageBox.Show("There are errors in the puzzle to start with, impossible to solve");
				return;
			}

			bool possible = m.solveHead();

			if (possible == false)
			{
				MessageBox.Show("No solutions found");
				return;
			}
			deSerialise(m);
			var check = m.checkGrid();
			applyCheck(check.Item1);
		}

		private static void applyCheck(matrix.celltype[][] matrix)
		{
			bool whiteout = !baseform.showInvalidMovesToolStripMenuItem.Checked;

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					var TB = baseform.grid.getControlByName(getname(x, y));
					if (whiteout)
					{
						TB.BackColor = Color.White;
						continue;
					}

					SudokuSolver.matrix.celltype CT = matrix[y][x];
					switch (CT)
					{
						case SudokuSolver.matrix.celltype.bad:
							TB.BackColor = Color.Tomato;
							break;
						case SudokuSolver.matrix.celltype.empty:
							TB.BackColor = Color.LightGoldenrodYellow;
							break;

						case SudokuSolver.matrix.celltype.good:
							TB.BackColor = Color.GreenYellow;
							break;
					}
				}
			}
		}

		public static String serialise()
		{
			String ret = "";
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					ret += baseform.grid.getControlByName(getname(x, y)).Text;
					//dont put a comma if last item
					if (y != height - 1 || x != width - 1)
						ret += ",";
				}
			}
			return ret;
		}

		public static void serialise(String filename)
		{
			String s = matrixgrid.serialise();
			FileStream FS;
			StreamWriter SW;
			try
			{
				FS = new FileStream(filename, FileMode.Create);
				SW = new StreamWriter(FS);
				//write dimensions
				SW.WriteLine(width.ToString()+","+height.ToString());
				SW.Write(s);

				SW.Close();
				FS.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error saving file:" + ex.ToString());
				return;
			}
		}

		private static String getname(int x, int y)
		{
			return y.ToString() + ":" + x.ToString();
		}

		public static Tuple<int, int> getLocationFromName(String name)
		{
			return StringExtras.SplitTwoInt(name, ':');
		}
	}
}
