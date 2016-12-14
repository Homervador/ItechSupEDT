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
using ItechSupEDT.Ajout_UC;
using ItechSupEDT.Modele;

namespace ItechSupEDT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
        }

        private void mi_ajout_matiere_Click(object sender, RoutedEventArgs e)
        {
            AjoutMatiere ajoutMatiere = new AjoutMatiere();
            this.Ajout.Content = ajoutMatiere;
        }

        private void mi_ajout_promotion_Click(object sender, RoutedEventArgs e)
        {
            List<MultiSelectedObject> lstEleves = new List<MultiSelectedObject>();
            AjoutPromotion ajoutPromotion = new AjoutPromotion(new List<Formation>(), lstEleves);
            this.Ajout.Content = ajoutPromotion;
        }
    }
}
