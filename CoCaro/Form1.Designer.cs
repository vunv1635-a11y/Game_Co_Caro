namespace CoCaro
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlChessBoard = new Panel();
            panel2 = new Panel();
            pctlogo = new PictureBox();
            panel3 = new Panel();
            label1 = new Label();
            bttLAN = new Button();
            pctbmark = new PictureBox();
            txtIP = new TextBox();
            progressBarCooldown = new ProgressBar();
            playerName = new TextBox();
            tmCoolDown = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctlogo).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctbmark).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlChessBoard
            // 
            pnlChessBoard.Location = new Point(12, 29);
            pnlChessBoard.Name = "pnlChessBoard";
            pnlChessBoard.Size = new Size(548, 587);
            pnlChessBoard.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.Controls.Add(pctlogo);
            panel2.Location = new Point(569, 29);
            panel2.Name = "panel2";
            panel2.Size = new Size(280, 280);
            panel2.TabIndex = 1;
            // 
            // pctlogo
            // 
            pctlogo.Image = Properties.Resources.logo;
            pctlogo.Location = new Point(3, 0);
            pctlogo.Name = "pctlogo";
            pctlogo.Size = new Size(274, 274);
            pctlogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pctlogo.TabIndex = 0;
            pctlogo.TabStop = false;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(bttLAN);
            panel3.Controls.Add(pctbmark);
            panel3.Controls.Add(txtIP);
            panel3.Controls.Add(progressBarCooldown);
            panel3.Controls.Add(playerName);
            panel3.Location = new Point(569, 315);
            panel3.Name = "panel3";
            panel3.Size = new Size(280, 227);
            panel3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 20.2499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 145);
            label1.Name = "label1";
            label1.Size = new Size(254, 35);
            label1.TabIndex = 5;
            label1.Text = "5 in a line to win";
            // 
            // bttLAN
            // 
            bttLAN.Location = new Point(3, 101);
            bttLAN.Name = "bttLAN";
            bttLAN.Size = new Size(147, 23);
            bttLAN.TabIndex = 4;
            bttLAN.Text = "Connect";
            bttLAN.UseVisualStyleBackColor = true;
            bttLAN.Click += bttLAN_Click;
            // 
            // pctbmark
            // 
            pctbmark.Location = new Point(156, 14);
            pctbmark.Name = "pctbmark";
            pctbmark.Size = new Size(121, 110);
            pctbmark.SizeMode = PictureBoxSizeMode.StretchImage;
            pctbmark.TabIndex = 3;
            pctbmark.TabStop = false;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(3, 72);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(147, 23);
            txtIP.TabIndex = 2;
            txtIP.Text = "127.0.0.1";
            // 
            // progressBarCooldown
            // 
            progressBarCooldown.Location = new Point(3, 43);
            progressBarCooldown.Name = "progressBarCooldown";
            progressBarCooldown.Size = new Size(147, 23);
            progressBarCooldown.TabIndex = 1;
            // 
            // playerName
            // 
            playerName.Location = new Point(3, 14);
            playerName.Name = "playerName";
            playerName.ReadOnly = true;
            playerName.Size = new Size(147, 23);
            playerName.TabIndex = 0;
            // 
            // tmCoolDown
            // 
            tmCoolDown.Tick += tmCoolDown_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(864, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, undoToolStripMenuItem, quitToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newGameToolStripMenuItem.Size = new Size(174, 22);
            newGameToolStripMenuItem.Text = "New game";
            newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(174, 22);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            quitToolStripMenuItem.Size = new Size(174, 22);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 628);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(pnlChessBoard);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Game Caro";
            FormClosing += Form1_FormClosing;
            Shown += Form1_Shown;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pctlogo).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctbmark).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlChessBoard;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pctlogo;
        private Button bttLAN;
        private PictureBox pctbmark;
        private TextBox txtIP;
        private ProgressBar progressBarCooldown;
        private TextBox playerName;
        private Label label1;
        private System.Windows.Forms.Timer tmCoolDown;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
    }
}
