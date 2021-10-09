
namespace SneakingOut
{
	partial class SneakingOut
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SneakingOut));
			this.game = new System.Windows.Forms.MenuStrip();
			this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.levelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.endGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.GameTimer = new System.Windows.Forms.Timer(this.components);
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.exit = new System.Windows.Forms.Label();
			this.player = new System.Windows.Forms.PictureBox();
			this.security1 = new System.Windows.Forms.PictureBox();
			this.security2 = new System.Windows.Forms.PictureBox();
			this.infos = new System.Windows.Forms.Label();
			this.firstLine = new System.Windows.Forms.Label();
			this.game.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.security1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.security2)).BeginInit();
			this.SuspendLayout();
			// 
			// game
			// 
			this.game.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.game.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem});
			this.game.Location = new System.Drawing.Point(0, 0);
			this.game.Name = "game";
			this.game.Size = new System.Drawing.Size(634, 24);
			this.game.TabIndex = 0;
			this.game.Text = "menuStrip1";
			// 
			// gameToolStripMenuItem
			// 
			this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.levelToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.endGameToolStripMenuItem});
			this.gameToolStripMenuItem.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
			this.gameToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
			this.gameToolStripMenuItem.Text = "Game";
			// 
			// newGameToolStripMenuItem
			// 
			this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
			this.newGameToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.newGameToolStripMenuItem.Text = "New Game";
			this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
			// 
			// levelToolStripMenuItem
			// 
			this.levelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
			this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
			this.levelToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.levelToolStripMenuItem.Text = "Level";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(82, 22);
			this.toolStripMenuItem2.Text = "1";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(82, 22);
			this.toolStripMenuItem3.Text = "2";
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(82, 22);
			this.toolStripMenuItem4.Text = "3";
			// 
			// pauseToolStripMenuItem
			// 
			this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
			this.pauseToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.pauseToolStripMenuItem.Text = "Pause ";
			this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
			// 
			// endGameToolStripMenuItem
			// 
			this.endGameToolStripMenuItem.Name = "endGameToolStripMenuItem";
			this.endGameToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.endGameToolStripMenuItem.Text = "End game";
			this.endGameToolStripMenuItem.Click += new System.EventHandler(this.endGameToolStripMenuItem_Click);
			// 
			// GameTimer
			// 
			this.GameTimer.Tick += new System.EventHandler(this.mainTimer);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.White;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox1.Location = new System.Drawing.Point(120, 386);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(53, 226);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Tag = "wall";
			this.pictureBox1.Visible = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.White;
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox2.Location = new System.Drawing.Point(342, 386);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(53, 226);
			this.pictureBox2.TabIndex = 4;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Tag = "wall";
			this.pictureBox2.Visible = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackColor = System.Drawing.Color.White;
			this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox3.Location = new System.Drawing.Point(440, -9);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(53, 226);
			this.pictureBox3.TabIndex = 5;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Tag = "wall";
			this.pictureBox3.Visible = false;
			// 
			// pictureBox4
			// 
			this.pictureBox4.BackColor = System.Drawing.Color.White;
			this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox4.Location = new System.Drawing.Point(220, -9);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(53, 226);
			this.pictureBox4.TabIndex = 6;
			this.pictureBox4.TabStop = false;
			this.pictureBox4.Tag = "wall";
			this.pictureBox4.Visible = false;
			// 
			// exit
			// 
			this.exit.AutoSize = true;
			this.exit.BackColor = System.Drawing.Color.White;
			this.exit.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.exit.Location = new System.Drawing.Point(538, 24);
			this.exit.Name = "exit";
			this.exit.Size = new System.Drawing.Size(62, 23);
			this.exit.TabIndex = 7;
			this.exit.Text = "EXIT";
			this.exit.Visible = false;
			// 
			// player
			// 
			this.player.Image = global::SneakingOut.Properties.Resources.player1;
			this.player.Location = new System.Drawing.Point(1, 538);
			this.player.Name = "player";
			this.player.Size = new System.Drawing.Size(50, 50);
			this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.player.TabIndex = 8;
			this.player.TabStop = false;
			this.player.Visible = false;
			// 
			// security1
			// 
			this.security1.Image = global::SneakingOut.Properties.Resources.security;
			this.security1.Location = new System.Drawing.Point(572, 386);
			this.security1.Name = "security1";
			this.security1.Size = new System.Drawing.Size(50, 50);
			this.security1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.security1.TabIndex = 9;
			this.security1.TabStop = false;
			this.security1.Tag = "security";
			this.security1.Visible = false;
			// 
			// security2
			// 
			this.security2.Image = global::SneakingOut.Properties.Resources.security;
			this.security2.Location = new System.Drawing.Point(164, 27);
			this.security2.Name = "security2";
			this.security2.Size = new System.Drawing.Size(50, 50);
			this.security2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.security2.TabIndex = 10;
			this.security2.TabStop = false;
			this.security2.Tag = "security";
			this.security2.Visible = false;
			// 
			// infos
			// 
			this.infos.AutoSize = true;
			this.infos.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.infos.ForeColor = System.Drawing.Color.White;
			this.infos.Location = new System.Drawing.Point(100, 220);
			this.infos.Name = "infos";
			this.infos.Size = new System.Drawing.Size(448, 180);
			this.infos.TabIndex = 13;
			this.infos.Text = resources.GetString("infos.Text");
			this.infos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// firstLine
			// 
			this.firstLine.AutoSize = true;
			this.firstLine.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.firstLine.ForeColor = System.Drawing.Color.White;
			this.firstLine.Location = new System.Drawing.Point(120, 160);
			this.firstLine.Name = "firstLine";
			this.firstLine.Size = new System.Drawing.Size(400, 23);
			this.firstLine.TabIndex = 14;
			this.firstLine.Text = "Welcome to Sneak Out the game!";
			this.firstLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SneakingOut
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(634, 611);
			this.Controls.Add(this.firstLine);
			this.Controls.Add(this.infos);
			this.Controls.Add(this.security2);
			this.Controls.Add(this.security1);
			this.Controls.Add(this.player);
			this.Controls.Add(this.exit);
			this.Controls.Add(this.game);
			this.Controls.Add(this.pictureBox4);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.MainMenuStrip = this.game;
			this.MaximumSize = new System.Drawing.Size(650, 650);
			this.MinimumSize = new System.Drawing.Size(650, 650);
			this.Name = "SneakingOut";
			this.Text = "Sneak Out the game";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
			this.game.ResumeLayout(false);
			this.game.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.security1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.security2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip game;
		private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem levelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem endGameToolStripMenuItem;
		private System.Windows.Forms.Timer GameTimer;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.Label exit;
		private System.Windows.Forms.PictureBox player;
		private System.Windows.Forms.PictureBox security1;
		private System.Windows.Forms.PictureBox security2;
		private System.Windows.Forms.Label infos;
		private System.Windows.Forms.Label firstLine;
	}
}

