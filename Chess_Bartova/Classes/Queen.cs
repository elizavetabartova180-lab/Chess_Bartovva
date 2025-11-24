using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;
using System.Windows.Media;
using System.Linq;

namespace Chess_Bartova.Classes
{
    public class Queen
    {
        public int X, Y;
        public bool Select, Black;
        public Grid Figure;

        public Queen(int X, int Y, bool Black)
        {
            this.X = X;
            this.Y = Y;
            this.Black = Black;
        }

        public void SelectFigure(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow.init.OneSelectQueen(this);

            if (Select)
            {
                if (Black)
                    Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\student-A502.PERMAVIAT\Desktop\Chess_Bartova\Chess_Bartova\Images\Queen(black).png")));
                else
                    Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\student-A502.PERMAVIAT\Desktop\Chess_Bartova\Chess_Bartova\Images\Queen.png")));
                Select = false;
            }
            else
            {
                Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\student-A502.PERMAVIAT\Desktop\Chess_Bartova\Chess_Bartova\Images\Queen(select).png")));
                Select = true;
            }
        }

        public void Transform(int toX, int toY)
        {
            if (CanMoveTo(this.X, this.Y, toX, toY))
            {
                Grid.SetColumn(Figure, toX);
                Grid.SetRow(Figure, toY);
                this.X = toX;
                this.Y = toY;
            }

            SelectFigure(null, null);
        }

        private bool CanMoveTo(int fromX, int fromY, int toX, int toY)
        {
            if (fromX == toX && fromY == toY) return false;

            bool canMove = (fromX == toX) || (fromY == toY) || (Math.Abs(fromX - toX) == Math.Abs(fromY - toY));
            if (!canMove) return false;

            if (fromX == toX)
            {
                int step = fromY < toY ? 1 : -1;
                for (int y = fromY + step; y != toY; y += step)
                {
                    if (IsCellOccupied(fromX, y)) return false;
                }
            }
            else if (fromY == toY) 
            {
                int step = fromX < toX ? 1 : -1;
                for (int x = fromX + step; x != toX; x += step)
                {
                    if (IsCellOccupied(x, fromY)) return false;
                }
            }
            else
            {
                int stepX = fromX < toX ? 1 : -1;
                int stepY = fromY < toY ? 1 : -1;

                int x = fromX + stepX;
                int y = fromY + stepY;

                while (x != toX && y != toY)
                {
                    if (IsCellOccupied(x, y)) return false;
                    x += stepX;
                    y += stepY;
                }
            }

            if (IsCellOccupiedBySameColor(toX, toY)) return false;

            return true;
        }

        private bool IsCellOccupied(int x, int y)
        {
            return MainWindow.init.Pawns.Any(pawn => pawn.X == x && pawn.Y == y) ||
                   MainWindow.init.Queens.Any(queen => queen.X == x && queen.Y == y);
        }

        private bool IsCellOccupiedBySameColor(int x, int y)
        {
            return MainWindow.init.Pawns.Any(pawn => pawn.X == x && pawn.Y == y && pawn.Black == this.Black) ||
                   MainWindow.init.Queens.Any(queen => queen.X == x && queen.Y == y && queen.Black == this.Black);
        }
    }
}