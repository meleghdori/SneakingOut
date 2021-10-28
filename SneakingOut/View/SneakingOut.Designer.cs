
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
			this._menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._menuFileNewGame = new System.Windows.Forms.ToolStripMenuItem();
			this._menuFileLevel1 = new System.Windows.Forms.ToolStripMenuItem();
			this._menuFileLevel2 = new System.Windows.Forms.ToolStripMenuItem();
			this._menuFileLevel3 = new System.Windows.Forms.ToolStripMenuItem();
			this._menuFIleRestartGame = new System.Windows.Forms.ToolStripMenuItem();
			this._menuFileSaveGame = new System.Windows.Forms.ToolStripMenuItem();
			this._menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this._menuFilePause = new System.Windows.Forms.ToolStripMenuItem();
			this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this._statusStrip = new System.Windows.Forms.StatusStrip();
			this._toolLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this._toolLabelGameSteps = new System.Windows.Forms.ToolStripStatusLabel();
			this._toolLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this._toolLabelGameTime = new System.Windows.Forms.ToolStripStatusLabel();
			this._menuStrip.SuspendLayout();
			this._statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// _menuStrip
			// 
			this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this._menuStrip.Location = new System.Drawing.Point(0, 0);
			this._menuStrip.Name = "_menuStrip";
			this._menuStrip.Size = new System.Drawing.Size(634, 24);
			this._menuStrip.TabIndex = 0;
			this._menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuFileNewGame,
            this._menuFIleRestartGame,
            this._menuFileSaveGame,
            this._menuFileExit,
            this._menuFilePause});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// _menuFileNewGame
			// 
			this._menuFileNewGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuFileLevel1,
            this._menuFileLevel2,
            this._menuFileLevel3});
			this._menuFileNewGame.Name = "_menuFileNewGame";
			this._menuFileNewGame.Size = new System.Drawing.Size(132, 22);
			this._menuFileNewGame.Text = "New Game";
			// 
			// _menuFileLevel1
			// 
			this._menuFileLevel1.Name = "_menuFileLevel1";
			this._menuFileLevel1.Size = new System.Drawing.Size(110, 22);
			this._menuFileLevel1.Text = "Level 1";
			this._menuFileLevel1.Click += new System.EventHandler(this._menuFileLevel1_Click);
			// 
			// _menuFileLevel2
			// 
			this._menuFileLevel2.Name = "_menuFileLevel2";
			this._menuFileLevel2.Size = new System.Drawing.Size(110, 22);
			this._menuFileLevel2.Text = "Level 2";
			this._menuFileLevel2.Click += new System.EventHandler(this._menuFileLevel2_Click);
			// 
			// _menuFileLevel3
			// 
			this._menuFileLevel3.Name = "_menuFileLevel3";
			this._menuFileLevel3.Size = new System.Drawing.Size(110, 22);
			this._menuFileLevel3.Text = "Level 3";
			this._menuFileLevel3.Click += new System.EventHandler(this._menuFileLevel3_Click);
			// 
			// _menuFIleRestartGame
			// 
			this._menuFIleRestartGame.Name = "_menuFIleRestartGame";
			this._menuFIleRestartGame.Size = new System.Drawing.Size(132, 22);
			this._menuFIleRestartGame.Text = "Restart";
			this._menuFIleRestartGame.Click += new System.EventHandler(this.restartGameToolStripMenuItem_Click);
			// 
			// _menuFileSaveGame
			// 
			this._menuFileSaveGame.Name = "_menuFileSaveGame";
			this._menuFileSaveGame.Size = new System.Drawing.Size(132, 22);
			this._menuFileSaveGame.Text = "Save";
			this._menuFileSaveGame.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// _menuFileExit
			// 
			this._menuFileExit.Name = "_menuFileExit";
			this._menuFileExit.Size = new System.Drawing.Size(132, 22);
			this._menuFileExit.Text = "Exit";
			this._menuFileExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// _menuFilePause
			// 
			this._menuFilePause.Name = "_menuFilePause";
			this._menuFilePause.Size = new System.Drawing.Size(132, 22);
			this._menuFilePause.Text = "Pause";
			this._menuFilePause.Click += new System.EventHandler(this._menuFilePause_Click);
			// 
			// _openFileDialog
			// 
			this._openFileDialog.FileName = "openFileDialog1";
			this._openFileDialog.Filter = "Sneaking Out table  (*.stl)|*.stl";
			this._openFileDialog.Title = "Loading Sneak Out the Game";
			// 
			// _saveFileDialog
			// 
			this._saveFileDialog.Filter = "Sneaking Out table  (*.stl)|*.stl";
			this._saveFileDialog.Title = "Saving Sneaking Out the Game";
			// 
			// _statusStrip
			// 
			this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolLabel1,
            this._toolLabelGameSteps,
            this._toolLabel2,
            this._toolLabelGameTime});
			this._statusStrip.Location = new System.Drawing.Point(0, 589);
			this._statusStrip.Name = "_statusStrip";
			this._statusStrip.Size = new System.Drawing.Size(634, 22);
			this._statusStrip.TabIndex = 1;
			this._statusStrip.Text = "statusStrip1";
			// 
			// _toolLabel1
			// 
			this._toolLabel1.ForeColor = System.Drawing.Color.White;
			this._toolLabel1.Name = "_toolLabel1";
			this._toolLabel1.Size = new System.Drawing.Size(38, 17);
			this._toolLabel1.Text = "Steps:";
			// 
			// _toolLabelGameSteps
			// 
			this._toolLabelGameSteps.ForeColor = System.Drawing.Color.White;
			this._toolLabelGameSteps.Name = "_toolLabelGameSteps";
			this._toolLabelGameSteps.Size = new System.Drawing.Size(13, 17);
			this._toolLabelGameSteps.Text = "0";
			// 
			// _toolLabel2
			// 
			this._toolLabel2.ForeColor = System.Drawing.Color.White;
			this._toolLabel2.Name = "_toolLabel2";
			this._toolLabel2.Size = new System.Drawing.Size(36, 17);
			this._toolLabel2.Text = "Time:";
			// 
			// _toolLabelGameTime
			// 
			this._toolLabelGameTime.ForeColor = System.Drawing.Color.White;
			this._toolLabelGameTime.Name = "_toolLabelGameTime";
			this._toolLabelGameTime.Size = new System.Drawing.Size(43, 17);
			this._toolLabelGameTime.Text = "0:00:00";
			// 
			// SneakingOut
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(634, 611);
			this.Controls.Add(this._statusStrip);
			this.Controls.Add(this._menuStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this._menuStrip;
			this.MaximumSize = new System.Drawing.Size(650, 650);
			this.MinimumSize = new System.Drawing.Size(650, 650);
			this.Name = "SneakingOut";
			this.Text = "Sneak Out the game";
			this.Load += new System.EventHandler(this.SneakOut_Load);
			this._menuStrip.ResumeLayout(false);
			this._menuStrip.PerformLayout();
			this._statusStrip.ResumeLayout(false);
			this._statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip _menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _menuFileNewGame;
		private System.Windows.Forms.ToolStripMenuItem _menuFIleRestartGame;
		private System.Windows.Forms.ToolStripMenuItem _menuFileSaveGame;
		private System.Windows.Forms.ToolStripMenuItem _menuFileExit;
		private System.Windows.Forms.OpenFileDialog _openFileDialog;
		private System.Windows.Forms.SaveFileDialog _saveFileDialog;
		private System.Windows.Forms.StatusStrip _statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel _toolLabel1;
		private System.Windows.Forms.ToolStripStatusLabel _toolLabelGameSteps;
		private System.Windows.Forms.ToolStripStatusLabel _toolLabel2;
		private System.Windows.Forms.ToolStripStatusLabel _toolLabelGameTime;
		private System.Windows.Forms.ToolStripMenuItem _menuFileLevel1;
		private System.Windows.Forms.ToolStripMenuItem _menuFileLevel2;
		private System.Windows.Forms.ToolStripMenuItem _menuFileLevel3;
		private System.Windows.Forms.ToolStripMenuItem _menuFilePause;
	}
}

