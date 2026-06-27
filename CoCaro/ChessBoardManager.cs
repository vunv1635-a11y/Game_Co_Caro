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
        private Panel ChessBoard;
        #endregion

        #region Initialization
        public ChessBoardManager(Panel ChessBoard)
        {
            this.ChessBoard = ChessBoard;
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
                    };

                    ChessBoard.Controls.Add(btn);

                    oldbutton = btn;
                }
                oldbutton.Location = new Point(0, oldbutton.Location.Y + Cons.CHESS_HEIGHT);
                oldbutton.Width = 0;
                oldbutton.Height = 0;
            }
        }
        #endregion
    }
}
