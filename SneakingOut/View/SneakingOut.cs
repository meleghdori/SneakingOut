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
	//exit megcsinalasa, a falon ne lasson at a range
	public partial class SneakingOut : Form
	{
		#region private types

		private bool goup;
		private bool godown;
		private bool goright;
		private bool goleft;
		private bool isPaused;
		private bool isPlaying;
		private bool isRightWall;
		private bool isLeftWall;
		private bool isTopWall;
		private bool isDownWall;
		private bool isRange1RightWall;
		private bool isRange1LeftWall;
		private bool isRange1TopWall;
		private bool isRange1DownWall;
		private bool isRange2RightWall;
		private bool isRange2LeftWall;
		private bool isRange2TopWall;
		private bool isRange2DownWall;
		private bool sec1isVertical;
		private bool sec2isVertical;

		private int PlayerStep;
		private int Security1Step;
		private int Security2Step;

		

		#endregion


		public SneakingOut()
		{
			InitializeComponent();
			//Optimalization
			this.SetStyle(ControlStyles.UserPaint, true);
			//2. Enable double buffer.
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			//3. Ignore a windows erase message to reduce flicker.
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		}

		#region gameTime
		private void MainTimer(object sender, EventArgs e)
		{
			PlayerMoving();

			Security1Moving();
			Security2Moving();

			Interactions();
		}

		#endregion

		#region private Components

		/// <summary>
		/// ha a nyil billentyu le van nyomva ezt tegye
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void KeyIsDown(object sender, KeyEventArgs e)
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

			//enum, a falak atirasa, 2 alakzattal valo megvalositasa
			/// <summary>
			/// ha a nyil billentyuk nincsenek lenyomva ezt tegye
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void KeyIsUp(object sender, KeyEventArgs e)
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
			private void NewGame()
			{

				PlayerStep = 5;
				Security1Step = 5;
				Security2Step = 5;

				isPaused = false;
				isPlaying = true;
				isRightWall = false;
				isLeftWall = false;
				isDownWall = false;
				isTopWall = false;
				isRange1RightWall = false;
				isRange1LeftWall = false;
				isRange1DownWall = false;
				isRange1TopWall = false;
				isRange2RightWall = false;
				isRange2LeftWall = false;
				isRange2DownWall = false;
				isRange2TopWall = false;
				sec1isVertical = true;
				sec2isVertical = false;

				security1.Left = 561;
				security1.Top = 538;
				security1range.Left = 462;
				security1range.Top = 439;
				security2.Left = 167;
				security2.Top = 27;
				security2range.Left = 66;
				security2range.Top = -57;
				firstLine.Left = 120;

				player.Left = 1;
				player.Top = 535;


				PictureBoxDisappear(true);

				LabelDisappear(false);

				exit.Visible = true;

				GameTimer.Start();
			}

			/// <summary>
			/// ha a vege a jetaknak kiirja hogy nyert e vagy sem
			/// </summary>
			/// <param name="message"></param>
			private void GameOver(string message)
			{


				GameTimer.Stop();

				PictureBoxDisappear(false);

				firstLine.Text = "" + Environment.NewLine + message;
				firstLine.Visible = true;
			}

			/// <summary>
			/// uj jatekot kezd 
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
			{
				NewGame();

			}

			/// <summary>
			/// megallitja a jatekot
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
			{
				if (isPaused == false && isPlaying == true)
				{
					isPaused = true;
					GameTimer.Stop();

					firstLine.Text = "" + Environment.NewLine + "The game is paused.\n Click pause to continue!";
					firstLine.Visible = true;

					PictureBoxDisappear(false);
				}
				else if (isPaused == true && isPlaying == true)
				{
					isPaused = false;
					isPlaying = true;
					GameTimer.Start();

					PictureBoxDisappear(true);

					firstLine.Visible = false;
				}
			}

			/// <summary>
			/// befejezi a jatekot anelkul hogy nyert vagy vesztett volna
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void EndGameToolStripMenuItem_Click(object sender, EventArgs e)
			{
				if (isPlaying == true)
				{
					GameOver("Thanks for playing!");
				}
			}

		#endregion


		#region public components

		/// <summary>
		/// atallitja a p.b lathatosagat
		/// </summary>
		/// <param name="visible"></param> 
		public void PictureBoxDisappear(bool visible)
		{
			foreach (Control x in this.Controls)
			{
				if (x is PictureBox)
				{
					x.Visible = visible;
				}
			}
		}

		/// <summary>
		/// a labelek lathatosagat valtoztatja meg
		/// </summary>
		/// <param name="visible"></param>
		public void LabelDisappear(bool visible)
		{
			foreach (Control x in this.Controls)
			{
				if (x is Label)
				{
					x.Visible = visible;
				}
			}
		}
		/// <summary>
		/// a billentyu lenyomasa alapjan hogyan mozogjon a jatekos
		/// </summary>
		public void PlayerMoving()
		{
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
		}

		/// <summary>
		/// a or1 mozgasa
		/// </summary>
		public void Security1Moving()
		{
			if (!sec1isVertical) // alapjaraton ha vizszintesen mozog
			{
				security1.Left += Security1Step;
				security1range.Left += Security1Step;
			}
			if (sec1isVertical) // ha hamis a vizszintes akk fuggolegesen mozogjon
			{
				security1.Top += Security1Step;
				security1range.Top += Security1Step;
			}
		}

		/// <summary>
		/// az or2 mozgasa
		/// </summary>
		public void Security2Moving()
		{
			if (!sec2isVertical)
			{
				security2.Left += Security2Step;
				security2range.Left += Security2Step;
			}
			if (sec2isVertical)
			{
				security2.Top += Security2Step;
				security2range.Top += Security2Step;
			}
		}
		/// <summary>
		/// a falak alaphelyzetbe allitasa
		/// </summary>
		public void SetWalls()
		{
			isRightWall = false;
			isLeftWall = false;
			isDownWall = false;
			isTopWall = false;
		}
		/// <summary>
		/// meghivja a kulonobozo erintekezeseket falakkal, orokkel, kijarattal
		/// </summary>
		public void Interactions()
		{
			foreach (Control x in this.Controls)
			{
				InteractionPictureBox(x);
				InteractionSecurity(x);
				InteractionExit(x);

			}
		}
		/// <summary>
		/// a pictureboxal valo erintkezes
		/// </summary>
		/// <param name="x"></param>
		public void InteractionPictureBox(Control x)
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
					else
					{
						SetWalls();
					}
					//melyik iranyba vannak a falak a rangnel
					if (security1range.Bounds.IntersectsWith(x.Bounds))
					{
						if (security1range.Left > x.Left  )
						{
							isRange1LeftWall = true;
						}
						if (security1range.Left < x.Left)
						{
							isRange1RightWall = true;
						}
						if (security1range.Top > x.Top)
						{
							isRange1DownWall = true;
						}
						if (security1range.Top < x.Top)
						{
							isRange1TopWall = true;
						}
					}
					else
					{
						isRange1RightWall = false;
						isRange1LeftWall = false;
						isRange1DownWall = false;
						isRange1TopWall = false;
					}
					if (security2range.Bounds.IntersectsWith(x.Bounds))
					{
						if (security2range.Left > x.Left)
						{
							isRange2LeftWall = true;
						}
						if (security2range.Left < x.Left)
						{
							isRange2RightWall = true;
						}
						if (security2range.Top > x.Top)
						{
							isRange2DownWall = true;
						}
						if (security2range.Top < x.Top)
						{
							isRange2TopWall = true;
						}
					}
					else
					{
						isRange2RightWall = false;
						isRange2LeftWall = false;
						isRange2DownWall = false;
						isRange2TopWall = false;
					}
					// or1 iranyitasa
					if (security1.Bounds.IntersectsWith(x.Bounds) || security1.Top < 24 || security1.Top > 562 || security1.Left < 0 || security1.Left > 584)
					{
						Random rand = new Random();
						int change = rand.Next(1, 4);

						if (change == 1) // ha 1 akkor megforditja az iranyat
						{
							Security1Step = -Security1Step;
						}
						if (change == 2 && !sec1isVertical) // ha 2 akk es vizszintetesen mozog akk most felfele
						{
							sec1isVertical = false;
							security1.Top += Security1Step;
							security1range.Top += Security1Step;
						}
						else if (change == 2 && sec1isVertical) // ha 2 akk es nem vizszintetesen mozog akk most jobbra
						{
							sec1isVertical = true;
							security1.Left += Security1Step;
							security1range.Left += Security1Step;
						}
						if (change == 3 && !sec1isVertical) // ha 3 akk es vizszintetesen mozog akk most lefele
						{
							sec1isVertical = false;
							security1.Top -= Security1Step;
							security1range.Top -= Security1Step;
						}
						else if (change == 3 && sec1isVertical) // ha 3 akk es nem vizszintetesen mozog akk most balra
						{
							sec1isVertical = true;
							security1.Left -= Security1Step;
							security1range.Left -= Security1Step;
						}
					}
					// a or2 iranyitasa
					if (security2.Bounds.IntersectsWith(x.Bounds) || security2.Top < 24 || security2.Top > 562 || security2.Left < 0 || security2.Left > 584)
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
							security2range.Top += Security2Step;
						}
						else if (change == 2 && sec2isVertical == false)
						{
							sec2isVertical = true;
							security2.Left += Security2Step;
							security2range.Left += Security2Step;
						}
						if (change == 3 && sec2isVertical == true)
						{
							sec2isVertical = false;
							security2.Top -= Security2Step;
							security2range.Top -= Security2Step;
						}
						else if (change == 3 && sec2isVertical == false)
						{
							sec2isVertical = true;
							security2.Left -= Security2Step;
							security2range.Left -= Security2Step;
						}
					}
				}
			}
		}

		/// <summary>
		/// a securityvel valo erintkezes
		/// </summary>
		/// <param name="x"></param>
		public void InteractionSecurity(Control x)
		{
			//azt kene h hogy ha securityhez er de ha fal van ott akk nem latja a jatekost a range
			if ((string)x.Tag == "security" )
			{
				if (player.Bounds.IntersectsWith(x.Bounds))
				{
					if (!isRange1RightWall) { GameOver("You lose."); }
					if (!isRange1LeftWall) { GameOver("You lose."); }
					if (!isRange1TopWall) { GameOver("You lose."); }
					if (!isRange1DownWall) { GameOver("You lose."); }
					if (!isRange2RightWall) { GameOver("You lose."); }
					if (!isRange2LeftWall) { GameOver("You lose."); }
					if (!isRange2TopWall) { GameOver("You lose."); }
					if (!isRange2DownWall) { GameOver("You lose."); }
					
				}
			}
		}
		/// <summary>
		/// a kijarattal valo erintkezes
		/// </summary>
		/// <param name="x"></param>
		public void InteractionExit(Control x)
		{
			if (x is Label)
			{
				if ((string)x.Name == "exit")
				{
					if (player.Bounds.IntersectsWith(x.Bounds))
					{
						GameOver("Congratulations! You sneaked out!");
					}
				}
			}
		}

		#endregion

	}
}
