﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Collections.Generic;
using Chess_Bartova.Classes;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            for(int i = 0; i<7; i++)
            {
                Pawns.Add(new Pawn(i, 1, false));
                Pawns.Add(new Pawn(i, 6, false));
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
                    Pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:/Images/Pawn(black).png")));
                else
                    Pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Pawn.png")));
                Grid.SetColumn(Pawn.Figure, Pawn.X);
                Grid.SetRow(Pawn.Figure, Pawn.Y);
                Pawn.Figure.MouseDown += Pawn.SelectFigure;
                gameBoard.Children.Add(Pawn.Figure);
            }
        }
        public void OneSelect(Pawn pawn)
        {

        }
        public void SelectTile(object sender, MouseButtonEventArgs e)
        {

        }
    }
}