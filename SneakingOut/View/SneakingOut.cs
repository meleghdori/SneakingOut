using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SneakingOut.Model;
using SneakingOut.Persistence;

namespace SneakingOut
{
    public partial class SneakingOut : Form
    {
        #region Fields

        private SneakingOutDataAccess _dataAccess; // adatelérés
        private SneakingOutGameModel _model; // játékmodell
        private PictureBox[,] _pictureBoxField; // gombrács
        private Timer _timer; // időzítő
        private Boolean isPaused;


        #endregion

        #region Constructors

        /// <summary>
        /// Játékablak példányosítása.
        /// </summary>
        public SneakingOut()
        {
            InitializeComponent();
        }

        #endregion

        #region Form event handlers

        /// <summary>
        /// Játékablak betöltésének eseménykezelője.
        /// </summary>
        private void SneakOut_Load(Object sender, EventArgs e)
        {
            // adatelérés példányosítása
            _dataAccess = new SneakingOutFileDataAccess();

            // modell létrehozása és az eseménykezelők társítása
            _model = new SneakingOutGameModel(_dataAccess);
            _model.GameAdvanced += new EventHandler<SneakingOutEventArgs>(Game_GameAdvanced);
            _model.GameOver += new EventHandler<SneakingOutEventArgs>(Game_GameOver);

            // időzítő létrehozása
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(Timer_Tick);


        }

        #endregion

        #region Game event handlers

        /// <summary>
        /// Játék előrehaladásának eseménykezelője.
        /// </summary>
        private void Game_GameAdvanced(Object sender, SneakingOutEventArgs e)
        {
            _toolLabelGameSteps.Text = e.GameStepCount.ToString();
            _toolLabelGameTime.Text = TimeSpan.FromSeconds(e.GameTime).ToString("g");
        }

        /// <summary>
        /// Játék végének eseménykezelője.
        /// </summary>
        private void Game_GameOver(Object sender, SneakingOutEventArgs e)
        {
            _timer.Stop();
            isPaused = true;

            _menuFileSaveGame.Enabled = false;

            if (e.IsWon) // győzelemtől függő üzenet megjelenítése
            {
                MessageBox.Show("Congratulations! You win!" + Environment.NewLine +
                                "Number of steps: " + e.GameStepCount,
                                "Sneaking Out the Game",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Sorry you lose but you did your best!",
                                "Sneaking Out the Game",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);
            }
        }


        #endregion

        #region Key eevent handlers

        /// <summary>
        /// ha a nyil billentyu le van nyomva ezt tegye
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (!isPaused)
            {
                if (e.KeyCode == Keys.Up)
                {
                    _model.PlayerMove(_model.Table._player, 0);
                }
                if (e.KeyCode == Keys.Down)
                {
                    _model.PlayerMove(_model.Table._player, 1);
                }
                if (e.KeyCode == Keys.Right)
                {
                    _model.PlayerMove(_model.Table._player, 2);
                }
                if (e.KeyCode == Keys.Left)
                {
                    _model.PlayerMove(_model.Table._player, 3);
                }
            }
        }

        #endregion

        #region Timer event handlers

        /// <summary>
        /// Időzítő eseménykeztelője.
        /// </summary>
        private void Timer_Tick(Object sender, EventArgs e)
        {
            if(!isPaused)
            _model.AdvanceTime(); // játék léptetése
        }

        #endregion


        #region private methods

        /// <summary>
        /// Új tábla létrehozása.
        /// </summary>
        private void GenerateTable()
        {
            _pictureBoxField = new PictureBox[_model.Table.Size, _model.Table.Size];
            for (Int32 i = 0; i < _model.Table.Size; i++)
                for (Int32 j = 0; j < _model.Table.Size; j++)
                {
                    _pictureBoxField[i, j] = new PictureBox();
                    _pictureBoxField[i, j].Location = new Point(5 + 50 * j, 35 + 50 * i); // elhelyezkedés
                    _pictureBoxField[i, j].Size = new Size(50, 50); // méret
                    _pictureBoxField[i, j].Enabled = false; // kikapcsolt állapot
                    _pictureBoxField[i, j].TabIndex = 100 + i * _model.Table.Size + j; // a gomb számát a TabIndex-ben tároljuk
                    _pictureBoxField[i, j].BorderStyle = BorderStyle.Fixed3D; // lapított stípus

                    Controls.Add(_pictureBoxField[i, j]);
                }
        }

        /// <summary>
        /// Tábla beállítása.
        /// </summary>
        private void SetupTable()
        {
            for (Int32 i = 0; i < _model.Table.Size; i++)
            {
                for (Int32 j = 0; j < _model.Table.Size; j++)
                {
                    if (_model.Table.GetValue(i, j) == 0)
                    {
                        _pictureBoxField[i, j].Enabled = true;
                        _pictureBoxField[i, j].BackColor = Color.Black;
                    }
                    if (_model.Table.GetValue(i, j) == 1 || _model.Table.GetValue(i, j) == 2)
                    {
                        _pictureBoxField[i, j].Image = Properties.Resources.security;
                        _pictureBoxField[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        _pictureBoxField[i, j].BackColor = Color.Transparent;
                        _pictureBoxField[i, j].Enabled = true;
                    }

                    if (_model.Table.GetValue(i, j) == 3)
                    {
                        _pictureBoxField[i, j].Image = Properties.Resources.player1;
                        _pictureBoxField[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        _pictureBoxField[i, j].BackColor = Color.Transparent;
                    }

                    if (_model.Table.GetValue(i, j) == 4)
                    {
                        _pictureBoxField[i, j].Enabled = true;
                        _pictureBoxField[i, j].BackColor = Color.Gray;
                    }

                    if (_model.Table.GetValue(i, j) == 5)
                    {
                        _pictureBoxField[i, j].Image = Properties.Resources.exit;
                        _pictureBoxField[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        _pictureBoxField[i, j].BackColor = Color.Transparent;
                    }
                }
            }

            _toolLabelGameSteps.Text = _model.GameStepCount.ToString();
            _toolLabelGameTime.Text = TimeSpan.FromSeconds(_model.GameTime).ToString("g");
        }
  

        #endregion

        #region Menu event handlers

		/// <summary>
		/// Játék mentésének eseménykezelője.
		/// </summary>
		private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
            Boolean restartTimer = _timer.Enabled;
            _timer.Stop();

            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // játé mentése
                    await _model.SaveGameAsync(_saveFileDialog.FileName);
                }
                catch (SneakingOutDataException)
                {
                    MessageBox.Show("Saving failed!" + Environment.NewLine + "The path is incorrect or the file can't be written!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (restartTimer)
                _timer.Start();
        }


        /// <summary>
        /// Kilépés eseménykezelője.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
            Boolean restartTimer = _timer.Enabled;
            _timer.Stop();

            // megkérdezzük, hogy biztos ki szeretne-e lépni
            if (MessageBox.Show("Are you sure you want to exit?", "Sneaking Out the Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // ha igennel válaszol
                Close();
            }
            else
            {
                if (restartTimer)
                    _timer.Start();
            }
        }


		
		private async void _menuFileLevel1_Click(object sender, EventArgs e)
		{
            _model.GameLevel = GameLevel.Level1;

            GenerateTable();
            _model.NewGame();


            try
            {
                // játék betöltése
                await _model.LoadGameAsync(@"C:\Digitalis oktatas\2021-2\eva\SneakingOut\SneakingOut\level1.txt");
                _menuFileSaveGame.Enabled = true;
            }
            catch (SneakingOutDataException)
            {
                MessageBox.Show("Loading failed!" + Environment.NewLine + "The path is incorrect or the file can't be written!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _model.NewGame();
                _menuFileSaveGame.Enabled = true;
            }

            _menuFileSaveGame.Enabled = true;

           
            SetupTable();

            _timer.Start();

        }

		private async void _menuFileLevel2_Click(object sender, EventArgs e)
        {
            _model.GameLevel = GameLevel.Level2;

            Boolean restartTimer = _timer.Enabled;
            _timer.Stop();

            try
            {
                // játék betöltése
                await _model.LoadGameAsync(@"C:\Digitalis oktatas\2021-2\eva\SneakingOut\SneakingOut\level2.txt");
                _menuFileSaveGame.Enabled = true;
            }
            catch (SneakingOutDataException)
            {
                MessageBox.Show("Loading failed!" + Environment.NewLine + "The path is incorrect or the file can't be written!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _model.NewGame();
                _menuFileSaveGame.Enabled = true;
            }


            GenerateTable();
            _model.NewGame();
            SetupTable();

            if (restartTimer)
                _timer.Start();
        }

		private async void _menuFileLevel3_Click(object sender, EventArgs e)
		{
            _model.GameLevel = GameLevel.Level3;

            Boolean restartTimer = _timer.Enabled;
            _timer.Stop();

            try
            {
                // játék betöltése
                await _model.LoadGameAsync(@"C:\Digitalis oktatas\2021-2\eva\SneakingOut\SneakingOut\level3.txt");
                _menuFileSaveGame.Enabled = true;
            }
            catch (SneakingOutDataException)
            {
                MessageBox.Show("Loading failed!" + Environment.NewLine + "The path is incorrect or the file can't be opened!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _model.NewGame();
                _menuFileSaveGame.Enabled = true;
            }

            GenerateTable();
            _model.NewGame();
            SetupTable();

            if (restartTimer)
                _timer.Start();
        }

		#endregion

        /// <summary>
        /// uj jatek esemenyenek kezelese
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void restartGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
            _menuFileSaveGame.Enabled = true;

            _model.NewGame();
            SetupTable();

            _timer.Start();
        }

		private void _menuFilePause_Click(object sender, EventArgs e)
		{
            if (!isPaused)
                _timer.Stop();
            else
                _timer.Start();
		}
	}
}
