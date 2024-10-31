﻿using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Функции;

namespace Практическая__2_Трусов
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] matrix = new int[0, 0];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dt_Grid_Cell(object sender, DataGridCellEditEndingEventArgs e)
        {
            int indcol = e.Column.DisplayIndex;
            int indrow = e.Row.GetIndex();
            if (Int32.TryParse(((TextBox)e.EditingElement).Text, out int m))
            {
                matrix[indcol, indrow] = m;
                matrix[indrow, indcol] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
            }
            else
            {
                MessageBox.Show("Введено неправильное значение");
            }
        }


        private void Create_Click(object sender, RoutedEventArgs e)
        {
            int Rown; int Coln;
            bool f1 = Int32.TryParse(Row.Text, out Rown);
            bool f2 = Int32.TryParse(Col.Text,out Coln);
            if (f1 == true && f2 == true)
            {
                if (Rown > 0 && Coln > 0)
                {
                    matrix = new int[Rown, Coln];
                    dt_Grid.ItemsSource = Class2.ToDataTable(matrix).DefaultView;
                    Random random = new Random();
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            int x = 0;                           
                            do 
                            {
                            x = random.Next(-5, 5);

                            } 
                            while (x == 0) ;
                            matrix[i, j] = x;
                        }
                    }
                    dt_Grid.ItemsSource = Class2.ToDataTable(matrix).DefaultView;
                }
                else MessageBox.Show("Введите правильное значение");
            }
            else MessageBox.Show("Введите правильное значение");
        }

        private void Ras_Click(object sender, RoutedEventArgs e)
        {
            int[] mas = new int[matrix.Length];
            Rez.Text = Class1.Ras(matrix,mas);
        }

        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            dt_Grid.ItemsSource = null;
            matrix = null;
            Row.Clear();
            Col.Clear();
            Rez.Clear();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана целочисленная матрица размера M × N. \n Для каждой строки матрицы найти сумму её элементов.");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Class2.Save(matrix);
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            int k1 = 0; int k2 = 0; 
            Class2.Open(ref matrix, out k1, out  k2);
            dt_Grid.ItemsSource = Class2.ToDataTable(matrix).DefaultView;
        }
    }
}