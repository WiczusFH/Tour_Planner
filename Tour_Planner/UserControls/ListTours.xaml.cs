﻿using System;
using System.Collections.Generic;
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

namespace Tour_Planner_3.View.UserControls
{
    /// <summary>
    /// Interaction logic for ToursList.xaml
    /// </summary>
    public partial class ToursList : UserControl
    {
        public ToursList()
        {
            InitializeComponent();
        }

        private void Grid_Selected(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("test");
        }
    }
}
