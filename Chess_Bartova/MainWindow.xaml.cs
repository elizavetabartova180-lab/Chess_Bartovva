using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using Chess_Bartova.Classes;
using System;

namespace Chess_Bartova
{
    public partial class MainWindow : Window
    {
        public List<Pawn> Pawns = new List<Pawn>();
        public List<Queen> Queens = new List<Queen>();
        public static MainWindow init;

        public MainWindow()
        {
            InitializeComponent();
            init = this;

            for (int i = 0; i <= 7; i++)
            {
                Pawns.Add(new Pawn(i, 1, false));
                Pawns.Add(new Pawn(i, 6, true));
            }

            Queens.Add(new Queen(4, 0, false));
            Queens.Add(new Queen(4, 7, true));

            CreatFigures();
        }

        public void CreatFigures()
        {
            foreach (Pawn pawn in Pawns)
            {
                pawn.Figure = new Grid()
                {
                    Width = 50,
                    Height = 50,
                };
                if (pawn.Black)
                    pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\student-A502.PERMAVIAT\Desktop\Chess_Bartova\Chess_Bartova\Images\Pawn (black).png")));
                else
                    pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\student-A502.PERMAVIAT\Desktop\Chess_Bartova\Chess_Bartova\Images\Pawn.png")));

                Grid.SetColumn(pawn.Figure, pawn.X);
                Grid.SetRow(pawn.Figure, pawn.Y);
                pawn.Figure.MouseDown += pawn.SelectFigure;
                gameBoard.Children.Add(pawn.Figure);
            }

            foreach (Queen queen in Queens)
            {
                queen.Figure = new Grid()
                {
                    Width = 50,
                    Height = 50,
                };
                if (queen.Black)
                    queen.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\student-A502.PERMAVIAT\Desktop\Chess_Bartova\Chess_Bartova\Images\Queen(black).png")));
                else
                    queen.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\student-A502.PERMAVIAT\Desktop\Chess_Bartova\Chess_Bartova\Images\Queen.png")));

                Grid.SetColumn(queen.Figure, queen.X);
                Grid.SetRow(queen.Figure, queen.Y);
                queen.Figure.MouseDown += queen.SelectFigure;
                gameBoard.Children.Add(queen.Figure);
            }
        }

        public void OneSelect(Pawn pawn)
        {
            foreach (Pawn p in Pawns)
                if (p != pawn && p.Select)
                    p.SelectFigure(null, null);

            foreach (Queen q in Queens)
                if (q.Select)
                    q.SelectFigure(null, null);
        }

        public void OneSelectQueen(Queen queen)
        {
            foreach (Queen q in Queens)
                if (q != queen && q.Select)
                    q.SelectFigure(null, null);

            foreach (Pawn p in Pawns)
                if (p.Select)
                    p.SelectFigure(null, null);
        }

        public void SelectTile(object sender, MouseButtonEventArgs e)
        {
            Grid Tile = sender as Grid;
            int X = Grid.GetColumn(Tile);
            int Y = Grid.GetRow(Tile);

            Queen SelectQueen = Queens.Find(x => x.Select == true);
            if (SelectQueen != null)
            {
                SelectQueen.Transform(X, Y);
                return;
            }

            Pawn SelectPawn = Pawns.Find(x => x.Select == true);
            if (SelectPawn != null)
            {
                SelectPawn.Transform(X, Y);
            }
        }
    }
}