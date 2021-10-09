using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SneakingOut
{
	public partial class SneakingOut : Form
	{
		private bool goup;
		private bool godown;
		private bool goright;
		private bool goleft;
		private bool isGameOver;
		private bool isPaused;
		private bool isPlaying;
		private bool isRightWall;
		private bool isLeftWall;
		private bool isTopWall;
		private bool isDownWall;
		private bool sec1isVertical;
		private bool sec2isVertical;

		private int PlayerStep;
		private int Security1Step;
		private int Security2Step;

		public SneakingOut()
		{
			InitializeComponent();
		}

		#region gameTime
		private void mainTimer(object sender, EventArgs e)
		{

			// a billentyu lenyomasa alapjan hogyan mozogjon a jatekos
			if (goleft && isLeftWall == false)
			{
				player.Left -= PlayerStep;
			}
			if (goright == true && isRightWall == false)
			{
				player.Left += PlayerStep;
			}
			if (godown == true && isDownWall == false)
			{
				player.Top += PlayerStep;
			}
			if (goup == true && isTopWall == false)
			{
				player.Top -= PlayerStep;
			}

			if (sec1isVertical) // alapjaraton ha vizszintesen mozog
			{
				security1.Left += Security1Step;
			}
			if (!sec1isVertical) // ha hamis a vizszintes akk fuggolegesen mozogjon
			{
				security1.Top += Security1Step;
			}

			if (sec2isVertical)
			{
				security2.Left += Security2Step;
			}
			if (!sec2isVertical)
			{
				security2.Top += Security2Step;
			}

			//a falak visszaallitas alaphelyzetbe
			isRightWall = false;
			isLeftWall = false;
			isDownWall = false;
			isTopWall = false;

			foreach (Control x in this.Controls)
			{
				if (x is PictureBox) 
				{

					if ((string)x.Tag == "wall") // ha fallal erintkezik a jatekos vagy az orok
					{
						if (player.Bounds.IntersectsWith(x.Bounds))
						{
							if (goleft)
							{
								isLeftWall = true;
	}
							if (goright)
							{
								isRightWall = true;
							}
							if (godown)
							{
								isDownWall = true;
							}
							if (goup)
							{
								isTopWall = true;
							}
							
						}
						// or1 iranyitasa
						if (security1.Bounds.IntersectsWith(x.Bounds))
						{
							Random rand = new Random();
							int change = rand.Next(1, 4);

							if (change == 1) // ha 1 akkor megforditja az iranyat
							{
								Security1Step = -Security1Step;
							}
							if (change == 2 && sec1isVertical == true) // ha 2 akk es vizszintetesen mozog akk most felfele
							{
								sec1isVertical = false;
								security1.Top += Security1Step;
							}
							else if (change == 2 && sec1isVertical == false) // ha 2 akk es nem vizszintetesen mozog akk most jobbra
							{
								sec1isVertical = true;
								security1.Left += Security1Step;
							}
							if (change == 3 && sec1isVertical == true) // ha 3 akk es vizszintetesen mozog akk most lefele
							{
								sec1isVertical = false;
								security1.Top -= Security1Step;
							}
							else if (change == 3 && sec1isVertical == false) // ha 3 akk es nem vizszintetesen mozog akk most balra
							{
								sec1isVertical = true;
								security1.Left -= Security1Step;
							}
						}
						// a or2 iranyitasa
						if (security2.Bounds.IntersectsWith(x.Bounds))
						{
							Random rand = new Random();
							int change = rand.Next(1, 4);

							if (change == 1)
							{
								Security2Step = -Security2Step;
							}
							if (change == 2 && sec2isVertical == true)
							{
								sec2isVertical = false;
								security2.Top += Security2Step;
							}
							else if (change == 2 && sec2isVertical == false)
							{
								sec2isVertical = true;
								security2.Left += Security2Step;
							}
							if (change == 3 && sec2isVertical == true)
							{
								sec2isVertical = false;
								security2.Top -= Security2Step;
							}
							else if (change == 3 && sec2isVertical == false)
							{
								sec2isVertical = true;
								security2.Left -= Security2Step;
							}
						}

						if ((string)x.Tag == "security")
						{
							if (player.Bounds.IntersectsWith(x.Bounds))
							{
								gameOver("You lose.");
							}
						}
					}
				}

				if (x is Label)
				{
					if ((string)x.Name == "exit")
					{
						if (player.Bounds.IntersectsWith(x.Bounds))
						{
							gameOver("Congratulations! You sneaked out!");
						}
					}
				}
			}

			

			//ha kimennenek a palyarol forduljanak vissza
			if (security1.Top < 24 || security1.Top > 562 ||security1.Left < 0 || security1.Left > 584)
			{
				Security1Step = -Security1Step;
			}

			if (security2.Top < 24 || security2.Top > 562 || security2.Left < 0 || security2.Left > 584)
			{
				Security2Step = -Security2Step;
			}
		}
			#endregion

		#region private Components

			/// <summary>
			/// ha a nyil billentyu le van nyomva ezt tegye
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void keyIsDown(object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Up)
				{
					goup = true;
				}
				if (e.KeyCode == Keys.Down)
				{
					godown = true;
				}
				if (e.KeyCode == Keys.Right)
				{
					goright = true;
				}
				if (e.KeyCode == Keys.Left)
				{
					goleft = true;
				}
			}
			/// <summary>
			/// ha a nyil billentyuk nincsenek lenyomva ezt tegye
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void keyIsUp(object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Up)
				{
					goup = false;
				}
				if (e.KeyCode == Keys.Down)
				{
					godown = false;
				}
				if (e.KeyCode == Keys.Right)
				{
					goright = false;
				}
				if (e.KeyCode == Keys.Left)
				{
					goleft = false;
				}
			}

			/// <summary>
			/// resets or starts a new game
			/// </summary>
			private void newGame()
			{

				PlayerStep = 5;
				Security1Step = 5;
				Security2Step = 5;

				isGameOver = false;
				isPaused = false;
				isPlaying = true;
				isRightWall = false;
				isLeftWall = false;
				isDownWall = false;
				isTopWall = false;
				sec1isVertical = true;
				sec2isVertical = false;

				security1.Left = 572;
				security1.Top = 386;
				security2.Left = 167;
				security2.Top = 27;
				firstLine.Left = 120;

				player.Left = 1;
				player.Top = 535;



				foreach (Control x in this.Controls)
				{
					if (x is PictureBox)
					{
						x.Visible = true;
					}
				}

				foreach (Control x in this.Controls)
				{
					if (x is Label)
					{
						x.Visible = false;
					}
				}

				exit.Visible = true;
				

				GameTimer.Start();
			}

			/// <summary>
			/// ha a vege a jetaknak kiirja hogy nyert e vagy sem
			/// </summary>
			/// <param name="message"></param>
			private void gameOver(string message)
			{

				isGameOver = true;

				GameTimer.Stop();
				foreach (Control x in this.Controls)
				{
					if (x is PictureBox)
					{
						x.Visible = false;
					}
				}

				firstLine.Text = "" + Environment.NewLine + message;
				firstLine.Visible = true;
			}

			/// <summary>
			/// uj jatekot kezd 
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
			{
				newGame();

			}

			/// <summary>
			/// megallitja a jatekot
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
			{
				if (isPaused == false && isPlaying == true)
				{
					isPaused = true;
					GameTimer.Stop();

					firstLine.Text = "" + Environment.NewLine + "The game is paused.\n Click pause to continue!";
					firstLine.Visible = true;

					foreach (Control x in this.Controls)
					{
						if (x is PictureBox)
						{
							x.Visible = false;
						}
					}
				}
				else if (isPaused == true && isPlaying == true)
				{
					isPaused = false;
					isPlaying = true;
					GameTimer.Start();
					foreach (Control x in this.Controls)
					{
						if (x is PictureBox)
						{
							x.Visible = true;
						}
					}
					firstLine.Visible = false;

				}


			}

			/// <summary>
			/// befejezi a jatekot anelkul hogy nyert vagy vesztett volna
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void endGameToolStripMenuItem_Click(object sender, EventArgs e)
			{
				if (isPlaying == true)
				{
					gameOver("Thanks for playing!");
				}
			}

			#endregion


	}
}
