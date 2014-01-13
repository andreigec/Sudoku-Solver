using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ANDREICSLIB;
using SudokuSolver.ServiceReference1;

namespace SudokuSolver
{
    public partial class Form1 : Form
    {
        private const String puzzles = "Puzzles\\";

        #region licensing

        private const string AppTitle = "Sudoku Solver";
        private const double AppVersion = 0.3;
        private const String HelpString = "";

        private readonly String OtherText =
            @"©" + DateTime.Now.Year +
            @" Andrei Gec (http://www.andreigec.net)

Licensed under GNU LGPL (http://www.gnu.org/)

Zip Assets © SharpZipLib (http://www.sharpdevelop.net/OpenSource/SharpZipLib/)
";
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void extToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void creatematrix()
        {
            int w = int.Parse(widthbox.Text);
            int h = int.Parse(heightbox.Text);
            matrixgrid.init(w, h);
            matrixgrid.doCheck();
        }

        private void creatematrixbutton_Click(object sender, EventArgs e)
        {
            creatematrix();
        }

        private void widthbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = TextboxExtras.HandleInput(TextboxExtras.InputType.Create(false, true), e.KeyChar, widthbox);
        }


        private void heightbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = TextboxExtras.HandleInput(TextboxExtras.InputType.Create(false, true), e.KeyChar, heightbox);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            matrixgrid.baseform = this;
            if (Directory.Exists(puzzles) == false)
                Directory.CreateDirectory(puzzles);

            creatematrix();
            loadpuzzles();
            Licensing.CreateLicense(this, menuStrip1, new Licensing.SolutionDetails(GetDetails, HelpString, AppTitle, AppVersion, OtherText));
        }

        public Licensing.DownloadedSolutionDetails GetDetails()
        {
            try
            {
                var sr = new ServicesClient();
                var ti = sr.GetTitleInfo(AppTitle);
                if (ti == null)
                    return null;
                return ToDownloadedSolutionDetails(ti);

            }
            catch (Exception)
            {
            }
            return null;
        }

        public static Licensing.DownloadedSolutionDetails ToDownloadedSolutionDetails(TitleInfoServiceModel tism)
        {
            return new Licensing.DownloadedSolutionDetails()
            {
                ZipFileLocation = tism.LatestTitleDownloadPath,
                ChangeLog = tism.LatestTitleChangelog,
                Version = tism.LatestTitleVersion
            };
        }

        private void clearmatrix_Click(object sender, EventArgs e)
        {
            matrixgrid.doCheck();
            matrixgrid.clear();
        }

        private void solvebutton_Click(object sender, EventArgs e)
        {
            matrixgrid.solve();
        }

        private void generaterandom_Click(object sender, EventArgs e)
        {
            int w = int.Parse(widthbox.Text);
            int h = int.Parse(heightbox.Text);
            int r = int.Parse(removepieces.Text);

            if (r > (w * h))
            {
                MessageBox.Show("Error, can't remove more pieces than possible");
                return;
            }

            matrixgrid.generateRandom(w, h, r);
        }

        private void removepieces_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = TextboxExtras.HandleInput(TextboxExtras.InputType.Create(false, true), e.KeyChar, removepieces);
        }

        private void showInvalidMovesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            matrixgrid.doCheck();
        }

        private void loadbox_Click(object sender, EventArgs e)
        {
            loadpuzzles();
        }

        private void loadpuzzles()
        {
            String rel = loadbox.Text;

            loadbox.Items.Clear();

            string[] f = Directory.GetFiles(puzzles);
            foreach (string s in f)
            {
                loadbox.Items.Add(s);
            }

            if (rel.Length > 0)
                loadbox.Text = rel;
            else if (loadbox.Items.Count > 0)
                loadbox.Text = loadbox.Items[0].ToString();
        }

        private void loadbutton_Click(object sender, EventArgs e)
        {
            if (loadbox.Text.Length == 0 || File.Exists(loadbox.Text) == false)
                return;
            loadfunc(loadbox.Text);
            matrixgrid.doCheck();
        }

        private void loadfunc(String file)
        {
            matrixgrid.deSerialise(file);
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {

            SaveFileDialog SFD = new SaveFileDialog();
            SFD.InitialDirectory = Directory.GetCurrentDirectory() + "\\" + puzzles.TrimEnd();
            SFD.Filter = SaveFileDialogExtras.createFilter("Sudoku File", "*.sudoku");
            DialogResult DR = SFD.ShowDialog();
            if (DR != DialogResult.OK)
                return;

            matrixgrid.serialise(SFD.FileName);
        }
    }
}
