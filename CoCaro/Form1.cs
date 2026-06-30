using System.Net.NetworkInformation;
namespace CoCaro
{
    public partial class Form1 : Form
    {
        #region Properties
        ChessBoardManager ChessBoard;

        SocketManager socket;
        #endregion
        public Form1()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

            ChessBoard = new ChessBoardManager(pnlChessBoard, playerName, pctbmark);
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;


            progressBarCooldown.Step = Cons.COOL_DOWN_STEP;
            progressBarCooldown.Maximum = Cons.COOL_DOWN_TIME;
            progressBarCooldown.Value = 0;

            tmCoolDown.Interval = Cons.COOL_DOWN_INTERVAL;

            socket = new SocketManager();

            NewGame();
        }

        #region Methods
        void EndGame()
        {
            tmCoolDown.Stop();
            pnlChessBoard.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            //MessageBox.Show("Game Over");
        }

        void NewGame()
        {
            progressBarCooldown.Value = 0;
            tmCoolDown.Stop();
            undoToolStripMenuItem.Enabled = true;
            ChessBoard.DrawChessBoard();
        }

        void Undo()
        {
            ChessBoard.Undo();
            progressBarCooldown.Value = 0;
        }

        void Quit()
        {
            Application.Exit();
        }
        void ChessBoard_PlayerMarked(object sender, ButtonClickEvent e)
        {
            tmCoolDown.Start();
            pnlChessBoard.Enabled = false;
            progressBarCooldown.Value = 0;

            socket.Send(new SocketData((int)SocketCommand.SEND_POINT,"", e.ClickedPoint));

            undoToolStripMenuItem.Enabled = false;

            Listen();
        }

        void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();

            socket.Send(new SocketData((int)SocketCommand.END_GAME, "", new Point()));
        }
        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            progressBarCooldown.PerformStep();

            if (progressBarCooldown.Value >= progressBarCooldown.Maximum)
            {
                EndGame();
                socket.Send(new SocketData((int)SocketCommand.TIME_OUT, "", new Point()));
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", new Point()));
            pnlChessBoard.Enabled = true;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
            socket.Send(new SocketData((int)SocketCommand.UNDO, "", new Point()));
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to quit?", "Notification", MessageBoxButtons.OKCancel) != DialogResult.OK)
                e.Cancel = true;
            else
            {                 
                socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
            }
        }


        private void bttLAN_Click(object sender, EventArgs e)
        {
            socket.IP = txtIP.Text;

            if (!socket.ConnectServer())
            {
                socket.isServer = true;
                pnlChessBoard.Enabled = true;
                socket.CreateServer();
            }
            else
            {
                socket.isServer = false;
                pnlChessBoard.Enabled = false;
                Listen();
            }
        }

        void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)socket.Receive();

                    ProcessData(data);
                }
                catch (Exception e)
                {
                        
                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            txtIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);

            if (string.IsNullOrEmpty(txtIP.Text))
            {
                txtIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }

        private void ProcessData(SocketData data)
        {
            switch(data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        pnlChessBoard.Enabled = false;
                    }));
                    break;
                case (int)SocketCommand.UNDO:
                    Undo();
                    progressBarCooldown.Value = 0;
                    
                    break;
                case (int)SocketCommand.QUIT:
                    tmCoolDown.Stop();
                    MessageBox.Show("Other player has quit the game", "Notification");
                    break;
                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        progressBarCooldown.Value = 0;
                        pnlChessBoard.Enabled = true;
                        tmCoolDown.Start();
                        ChessBoard.OtherPlayerMark(data.Point);
                        undoToolStripMenuItem.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.END_GAME:
                    MessageBox.Show("Game is Over!", "Notification");
                    break;
                case (int)SocketCommand.TIME_OUT:
                    MessageBox.Show("Other player has run out of time", "Notification");
                    break;
                default:
                    break;
            }

            Listen();
        }

        #endregion
    }
}
