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
using System.Data.SqlClient;
using ItechSupEDT.Outils;
using System.Data;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutPromotion.xaml
    /// </summary>
    public partial class AjoutPromotion : UserControl
    {
        private Dictionary<String, Formation> lstFormations;
        public Dictionary<String, Formation> LstFormations
        {
            get { return this.lstFormations; }
            set { this.lstFormations = value; }
        }
        public AjoutPromotion()
        {
            InitializeComponent();
           
            this.cb_lstFormations.ItemsSource = FormationDAO.RecupererFormations();
        }

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            String nom = tb_nom.Text;
            DateTime dateDebut = (DateTime)dp_dateDebut.SelectedDate;
            DateTime dateFin = (DateTime)dp_dateFin.SelectedDate;
            Formation formation = (Formation)cb_lstFormations.SelectedItem;

            if (this.tb_nom.Text == "")
            {
                this.tbk_error.Text = "Le nom de la promotion est vide.";
                this.tbk_error.Visibility = Visibility.Visible;
            }

            else
            {
                try
                {
                    PromotionDAO.CreePromotion(nom, dateDebut, dateFin, formation);
                    this.tb_nom.Text = "";
                    this.dp_dateDebut = null;
                    this.dp_dateFin = null;
                    this.tbk_retourMessage.Text = "Promotion ajoutée";
                    this.sp_valider.Visibility = Visibility.Visible;
                    this.sp_Ajout.Visibility = Visibility.Collapsed;
                }
                catch (Exception ex)
                {
                    tbk_error.Text = "Une erreur est survenu lors de l'ajout, veuillez vérifier les information";
                    Console.WriteLine(tbk_error.Text);
                    this.tbk_error.Visibility = Visibility.Visible;
                }
            }
            
        }
        private void btn_nouveau_Click(object sender, RoutedEventArgs e)
        {
            this.sp_valider.Visibility = Visibility.Collapsed;
            this.sp_Ajout.Visibility = Visibility.Visible;
        }
    }
}
