namespace CoCaro
{
    public partial class Form1 : Form
    {
        #region Properties
        ChessBoardManager ChessBoard;
        #endregion
        public Form1()
        {
            InitializeComponent();

            ChessBoard = new ChessBoardManager(pnlChessBoard, playerName, pctbmark);
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;


            progressBarCooldown.Step = Cons.COOL_DOWN_STEP;
            progressBarCooldown.Maximum = Cons.COOL_DOWN_TIME;
            progressBarCooldown.Value = 0;

            tmCoolDown.Interval = Cons.COOL_DOWN_INTERVAL;

            NewGame();
        }

        #region Methods
        void EndGame()
        {
            tmCoolDown.Stop();
            pnlChessBoard.Enabled = false;
            MessageBox.Show("Game Over");
        }

        void NewGame()
        {
            progressBarCooldown.Value = 0;
            tmCoolDown.Stop();            
            
            ChessBoard.DrawChessBoard();
        }

        void Undo()
        {

        }

        void Quit()
        { 
            Application.Exit();
        }
        void ChessBoard_PlayerMarked(object sender, EventArgs e)
        {
            tmCoolDown.Start();
            progressBarCooldown.Value = 0;
        }

        void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
        }
        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            progressBarCooldown.PerformStep();

            if (progressBarCooldown.Value >= progressBarCooldown.Maximum)
            {
                EndGame();
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }
       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to quit?", "Notification", MessageBoxButtons.OKCancel) != DialogResult.OK)
                e.Cancel = true;
        }
        
        #endregion
    }
}
