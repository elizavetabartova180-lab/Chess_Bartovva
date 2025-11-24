using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using Chess_Bartova.Classes;

namespace Chess_Bartova
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Pawn> Pawns = new List<Pawn>();
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;

            for(int i = 0; i<=7; i++)
            {
                Pawns.Add(new Pawn(i, 1, false));
                Pawns.Add(new Pawn(i, 6, true));
            }
            CreatFigures();
        }
        public void CreatFigures()
        {
            foreach (Pawn Pawn in Pawns) {
                Pawn.Figure = new Grid()
                {
                    Width = 50,
                    Height = 50,
                };
                if (Pawn.Black)
                    Pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\student-A502.PERMAVIAT\Desktop\Chess_Bartova\Chess_Bartova\Images\Pawn (black).png")));
                else
                    Pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\student-A502.PERMAVIAT\Desktop\Chess_Bartova\Chess_Bartova\Images\Pawn.png")));
                Grid.SetColumn(Pawn.Figure, Pawn.X);
                Grid.SetRow(Pawn.Figure, Pawn.Y);
                Pawn.Figure.MouseDown += Pawn.SelectFigure;
                gameBoard.Children.Add(Pawn.Figure);
            }
        }
        public void OneSelect(Pawn pawn)
        {
            foreach (Pawn Pawn in Pawns)
                if (Pawn != pawn)
                    if (Pawn.Select)
                        Pawn.SelectFigure(null, null);
        }
        public void SelectTile(object sender, MouseButtonEventArgs e)
        {
            Grid Tile = sender as Grid;
            int X = Grid.GetColumn(Tile);
            int Y = Grid.GetRow(Tile);

            Pawn SelectPawn = MainWindow.init.Pawns.Find(x => x.Select == true);
            if (SelectPawn != null)
                SelectPawn.Transform(X, Y);
        }
    }
}