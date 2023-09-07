﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utilities.QuickType;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        Player player = new Player();
        public PlayerControl()
        {
            InitializeComponent();
        }
        
        public void SetPlayer(Player p) 
        {
            player = p;
            playerNameAndNumber.Text = $"{p.Name}, {p.ShirtNumber}";
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlayerWindow pw = new PlayerWindow(player);
            pw.Show();
        }
    }
}
