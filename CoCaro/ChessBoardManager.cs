using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro
{
    public class ChessBoardManager
    {
        #region Properties
        private Panel chessBoard;

        public Panel ChessBoard 
        {
            get { return chessBoard; }
            set { chessBoard = value; } 
        }

        private List<Player> player;

        public List<Player> Player
        {
            get { return player; }
            set { player = value; }
        }

        private int currentPlayer;

        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }

        private TextBox playerName;

        public TextBox PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        private PictureBox playerMark;
        public PictureBox PlayerMark { 
            get { return playerMark; }
            set { playerMark = value; }
        }

        #endregion

        #region Initialization
        public ChessBoardManager(Panel chessBoard, TextBox playerName, PictureBox mark)
        {
            this.ChessBoard = chessBoard;
            this.PlayerName = playerName;
            this.PlayerMark = mark;

            this.Player = new List<Player>() 
            {
                new Player("Player 1", global::CoCaro.Properties.Resources.X),
                new Player("Player 2", global::CoCaro.Properties.Resources.O)
            };

            CurrentPlayer = 0;

            ChangePlayer();
        }
        #endregion

        #region Methods
        public void DrawChessBoard()
        {
            Button oldbutton = new Button()
            {
                Width = 0,
                Height = 0,
                Location = new Point(0, 0),
            };
            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(oldbutton.Location.X + oldbutton.Width, oldbutton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch
                    };

                    btn.Click += btn_Click;

                    ChessBoard.Controls.Add(btn);

                    oldbutton = btn;
                }
                oldbutton.Location = new Point(0, oldbutton.Location.Y + Cons.CHESS_HEIGHT);
                oldbutton.Width = 0;
                oldbutton.Height = 0;
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.BackgroundImage != null)
                return;

            Mark(btn);

            ChangePlayer();
        }

        private void Mark(Button btn)
        {
            btn.BackgroundImage = Player[CurrentPlayer].Mark;

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
        }

        private void ChangePlayer()
        {
            PlayerName.Text = Player[CurrentPlayer].Name;
            PlayerMark.Image = Player[CurrentPlayer].Mark;
        }
        #endregion
    }
}
