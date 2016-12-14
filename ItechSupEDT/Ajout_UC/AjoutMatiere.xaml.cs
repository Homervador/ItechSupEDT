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

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutMatiere.xaml
    /// </summary>
    public partial class AjoutMatiere : UserControl
    {

        private List<Matiere> lstMatiere;
        public List<Matiere> LstMatiere
        {
            get { return this.lstMatiere; }
            set { this.lstMatiere = value; }
        }

        public AjoutMatiere()
        {
            InitializeComponent();
            this.LstMatiere = new List<Matiere>();
            this.sp_valider.Visibility = Visibility.Collapsed;
        }

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            if (this.tb_nomMatiere.Text == "")
            {
                this.tbk_error.Text = "Le nom de la matière est vide.";
                this.tbk_error.Visibility = Visibility.Visible;
                return;
            }
            if (tbk_error.Text != "")
            {
                this.tbk_error.Text = "";
                this.tbk_error.Visibility = Visibility.Collapsed;
            }
            this.LstMatiere.Add(new Matiere(this.tb_nomMatiere.Text));
            this.tb_nomMatiere.Text = "";
            this.tbk_retourMessage.Text = "Matière Ajoutée";
            this.sp_Ajout.Visibility = Visibility.Collapsed;
            this.sp_valider.Visibility = Visibility.Visible;
        }
        private void btn_nouveau_Click(object sender, RoutedEventArgs e)
        {
            this.sp_valider.Visibility = Visibility.Collapsed;
            this.sp_Ajout.Visibility = Visibility.Visible;
        }
    }
}
