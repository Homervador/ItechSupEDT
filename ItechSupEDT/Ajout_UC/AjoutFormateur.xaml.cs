using System;
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
using ItechSupEDT.Modele;
using ItechSupEDT.Ajout_UC;
using ItechSupEDT.Outils;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutFormateur.xaml
    /// </summary>
    public partial class AjoutFormateur : UserControl
    {
        public AjoutFormateur(List<Nameable> listeMatiere)
        {
            InitializeComponent();
            MutliSelectPickList multiSelect = new MutliSelectPickList(listeMatiere);
            this.MultiSelect.Content = multiSelect;
        }

        private void btn_ajoutFormation_clic(object sender, RoutedEventArgs e)
        {
            String nom = tb_nomFormateur.Text;
            String prenom = tb_prenomFormateur.Text;
            String mail = tb_mailFormateur.Text;
            String telephone = tb_numeroFormateur.Text;
            List<Matiere> listeMatiere;

            if (this.tb_nomFormateur.Text == "" || this.tb_prenomFormateur.Text == "" || this.tb_mailFormateur.Text == "" || this.tb_numeroFormateur.Text == "")
            {
                this.tbk_errorMessage.Text = "L'un des champs est vide";
                this.tbk_errorMessage.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    FormateurDAO.CreeFormateur(nom, prenom, mail, telephone, listeMatiere);
                    this.tb_nomFormateur.Text = "";
                    this.tb_prenomFormateur.Text = "";
                    this.tb_mailFormateur.Text = "";
                    this.tb_numeroFormateur.Text = "";
                }

            }
        }
    }
}
